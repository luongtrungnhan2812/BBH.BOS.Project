using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class WalletController : Controller
    {
        [Dependency]
        protected ITransactionWalletService transactionWallet { get; set; }
        // GET: Wallet
        public ActionResult WalletBTC()
        {
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = member.NumberCoin.ToString();
            }
            else
            {
                ViewBag.NumberCoin = "0";
            }
            ViewBag.strHtmlTransactionCoin = GenHtml_TractionCoin();
            return View();
        }
        public string GenHtml_TractionCoin()
        {
            StringBuilder strBuilder = new StringBuilder();
            int memberID = -1;
            try
            {
                IEnumerable<TransactionCoinBO> lstTransactionPointsBO = null;
                if (Session["MemberInfomation"] != null)
                {
                    MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                    memberID = member.MemberID;
                }
                lstTransactionPointsBO = transactionWallet.ListTransactionWalletByMember(memberID, 1, 100);
                if (lstTransactionPointsBO != null && lstTransactionPointsBO.Count() > 0)
                {
                    foreach (var item in lstTransactionPointsBO)
                    {
                        string color = "#fff";
                        strBuilder.Append(@"<tr class='none-top-border' style='cursor:pointer; background-color:" + color + "' onclick=\"ShowTransactionWalletDetail('" + item.TransactionID + "')\">");
                        strBuilder.Append(@"<td> " + item.TransactionID + " </td>");
                        strBuilder.Append(@"<td> " + item.WalletAddressID + " </td>");
                        strBuilder.Append(@"<td>" + item.ValueTransaction.ToString() + "</td>");
                        strBuilder.Append(@"<td>" + item.CreateDate.ToString("dd/MM/yyyy") + "</td>");
                        strBuilder.Append(@"<td><a class='blue-text' data-toggle='tooltip' data-placement='top' title='' data-original-title='See results'><i class='fa fa-eye'></i></a></td>");
                        strBuilder.Append(@"</ tr >");
                    }

                }
                return strBuilder.ToString();
            }
            catch
            {
                return "";
            }

        }
        [HttpPost]
        public string DetailWallet(string strTransactionId)
        {
            string json = "";
            TransactionCoinBO objTransactionCoinBO = new TransactionCoinBO();
            objTransactionCoinBO = transactionWallet.transactionCoinByID(strTransactionId.Trim());
            if (objTransactionCoinBO != null)
            {
                json = JsonConvert.SerializeObject(objTransactionCoinBO);
            }
            return json.ToString();
        }
    }
}