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
        [Dependency]
        protected ITransactionPackageService transactionPackage { get; set; }
        // GET: Wallet
        public ActionResult WalletBTC()
        {
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = double.Parse(member.NumberCoin.ToString()).ToString();
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
        public ActionResult WalletEU()
        {
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = double.Parse(member.NumberCoin.ToString()).ToString();
            }
            else
            {
                ViewBag.NumberCoin = "0";

            }
            ViewBag.strHtmlTransactionPackage = GenHtml_TractionPackage();
            return View();
        }
        public string GenHtml_TractionPackage()
        {
            StringBuilder strBuilder = new StringBuilder();
            int memberID = -1;
            try
            {
                IEnumerable<TransactionPackageBO> lstTransactionPackageBO = null;
                if (Session["MemberInfomation"] != null)
                {
                    MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                    memberID = member.MemberID;
                }
                lstTransactionPackageBO = transactionPackage.ListTransactionPackageByMember(memberID);
                if (lstTransactionPackageBO != null && lstTransactionPackageBO.Count() > 0)
                {
                    foreach (var item in lstTransactionPackageBO)
                    {
                        strBuilder.Append("<tr>");
                        strBuilder.Append("<td><span class='badge green'>" + (item.Status == 1 ? "Active" : "InActive") + "</span></td>");
                        strBuilder.Append("<td> " + item.PackageName + " </ td >");
                        strBuilder.Append("<td> " + item.Note + " </ td >");
                        strBuilder.Append("<td class='hour'><small><span class='grey-text'><i class='fa fa-clock-o' aria-hidden='true'></i> " + item.CreateDate.ToString("dd/MM/yyyy hh:ss:mm") + "</span></small></td>");
                        strBuilder.Append("<td><a class='blue-text' data-toggle='tooltip' data-placement='top' data-toggle='modal' data-target='#myModalDetailTransactionPackage' title='' data-original-title='See results' onclick=\"ShowTransactionPackageDetail('" + memberID + "','" + item.TransactionCode + "')\"><i class='fa fa-eye'></i></a></td>");
                        strBuilder.Append("</tr>");
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
        public string DetailTransactionPackage(int memberID, string strTransactionCode)
        {
            string json = "";
            TransactionPackageBO objTransactionPackageBO = new TransactionPackageBO();
            objTransactionPackageBO = transactionPackage.DetailTransactionPackage(memberID, strTransactionCode);
            if (objTransactionPackageBO != null && objTransactionPackageBO.TransactionCode != null && objTransactionPackageBO.TransactionCode != "")
            {
                json = JsonConvert.SerializeObject(objTransactionPackageBO);
            }
            return json.ToString();
        }
    }
}