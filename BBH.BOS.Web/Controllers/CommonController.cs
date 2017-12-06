using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
using BBH.BOS.Web.Models;
using Microsoft.Practices.Unity;
using NBitcoin;
using QBitNinja.Client;
using QBitNinja.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class CommonController : Controller
    {
        string masterKey = ConfigurationManager.AppSettings["KeyBOS"];
        string TimeExpired = ConfigurationManager.AppSettings["TimeExpired"];
        [Dependency]
        protected ITransactionWalletService ObjITransactionWalletService { get; set; }
        [Dependency]
        protected IPackageService ObjIPackgeServices { get; set; }
        [Dependency]
        protected IIMemberService ObjIIMemberService { get; set; }
        [Dependency]
        protected ITransactionPackageService ObjITransactionPackageService { get; set; }
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepositBTC()
        {
            try
            {
                if (Session["MemberInfomation"] != null)
                {
                    MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                    int intIndexWallet = member.IndexWallet;
                    string strClientExtKey = masterKey;
                    RandomUtils.Random = new UnsecureRandom();
                    ExtKey masterPubKey = new BitcoinExtKey(strClientExtKey, Network.TestNet);
                    ExtKey pubkey = masterPubKey.Derive(intIndexWallet, hardened: true);
                    var strWalletAddress = pubkey.PrivateKey.GetBitcoinSecret(Network.TestNet).GetAddress().ToString();
                    ViewBag.WalletAddress = strWalletAddress;
                    string strQRCode = Utility.GenQRCode(strWalletAddress);
                    ViewBag.DataQRCode = "data:image/png;base64," + strQRCode + "";
                }
                else
                {
                    ViewBag.WalletAddress = "00000000000000";
                    ViewBag.DataQRCode = "data:image/png;base64," + 00000000000000 + "";
                }
            }
            catch
            {
                ViewBag.WalletAddress = "00000000000000";
                ViewBag.DataQRCode = "data:image/png;base64," + 00000000000000 + "";
            }
            return PartialView();
        }
        public ActionResult BuyPackage()
        {
            List<string> lststrHtml = new List<string>();
            lststrHtml = GenHtmlListPackage();
            if (lststrHtml.Count > 1)
            {
                ViewBag.strHtmlPackage = lststrHtml[0];
                ViewBag.strHtmlRadioCheck = lststrHtml[1];
            }
            else
            {
                ViewBag.strHtmlPackage = "";
                ViewBag.strHtmlRadioCheck = "";
            }
            return PartialView();
        }
        public ActionResult PartialDashboard()
        {
            LoadPoint();
            LoadEuVallet();
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = double.Parse(member.NumberCoin.ToString()).ToString();
            }
            else
            {
                ViewBag.NumberCoin = "0";
            }
            return PartialView();
        }
        public void LoadPoint()
        {
            string transactionCode = "";
            string strClientExtKey = masterKey;
            RandomUtils.Random = new UnsecureRandom();
            ExtKey masterPubKey = new BitcoinExtKey(strClientExtKey, Network.TestNet);
            MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
            bool rs = true;
            if (member != null)
            {
                ExtKey pubkey = masterPubKey.Derive(member.IndexWallet, hardened: true);
                var clientBitPrivateKey = masterPubKey.PrivateKey;
                var destination = clientBitPrivateKey.PubKey.GetAddress(Network.TestNet);
                //check valid amount
                var userBitPK = pubkey.PrivateKey.GetBitcoinSecret(Network.TestNet);
                List<TransactionReceivedCoins> LstUserCoin = GetListTransaction(userBitPK);
                if (LstUserCoin != null && LstUserCoin.Count > 0)
                {
                    foreach (TransactionReceivedCoins item in LstUserCoin)
                    {
                        if (item.Confirm >= 0)
                        {
                            bool boolCheckExistTransactionID = ObjITransactionWalletService.CheckExistTransactionBitcoin(item.TransactionID.ToString());
                            if (!boolCheckExistTransactionID)
                            {
                                if (item.ListCoins != null && item.ListCoins.Count > 0)
                                {
                                    foreach (var itemListCoins in item.ListCoins)
                                    {
                                        ////Change bitcoin to point
                                        //float pointChange = ((float.Parse(strPoint)) * CoinValue) / PointValue;
                                        string strCode = Utility.GenCode();
                                        string tick = DateTime.Now.Ticks.ToString();
                                        transactionCode = Utility.MaHoaMD5(strCode + tick);
                                        TransactionCoinBO objTransactionCoinBO = new TransactionCoinBO
                                        {
                                            CreateDate = DateTime.Now,
                                            ExpireDate = DateTime.Now.AddMinutes(double.Parse(TimeExpired)),
                                            MemberID = member.MemberID,
                                            Note = "Received Coins",
                                            QRCode = "",
                                            Status = 0,
                                            TransactionBitcoin = item.TransactionID.ToString(),
                                            TransactionID = transactionCode,
                                            TypeTransactionID = 0,
                                            ValueTransaction = float.Parse(itemListCoins.Amount.ToString()),
                                            WalletAddressID = userBitPK.GetAddress().ToString(),
                                            WalletID = destination.ToString()
                                        };
                                        //objTransactionCoinBO.WalletID = destination.ToString();
                                        bool rs_ = ObjITransactionWalletService.InsertTransactionCoin(objTransactionCoinBO);
                                        if (rs_)
                                        {
                                            //double pointChange = ((double.Parse(itemListCoins.Amount.ToString())) * PointValue) / CoinValue;
                                            rs = ObjITransactionWalletService.UpdatePointsMemberFE(member.MemberID, double.Parse(itemListCoins.Amount.ToString()));
                                            if (!rs)
                                            {
                                                break;
                                            }
                                        }
                                    }


                                }
                            }

                        }
                    }
                }
                //if (rs)
                //{
                //    double memeberPoints = objMemberRepository.GetPointsMember(member.MemberID);
                //    result = memeberPoints.ToString();
                //}

                MemberInformationBO ọbjMemberInformationBO = new MemberInformationBO();
                ọbjMemberInformationBO = ObjIIMemberService.GetInformationMemberByID(member.MemberID);
                if (ọbjMemberInformationBO != null)
                {
                    Session["MemberInfomation"] = ọbjMemberInformationBO;
                }

            }
        }
        private static List<TransactionReceivedCoins> GetListTransaction(BitcoinSecret sonBitPrivateKey)
        {

            List<TransactionReceivedCoins> list = new List<TransactionReceivedCoins>();
            try
            {
                var address = sonBitPrivateKey.GetAddress();

                QBitNinjaClient client = new QBitNinjaClient(Network.TestNet);
                BalanceModel myBalance = client.GetBalance(address, unspentOnly: true).Result;
                foreach (BalanceOperation op in myBalance.Operations)
                {
                    List<Coin> lstCoin = new List<Coin>();
                    var receivedCoins = op.ReceivedCoins;
                    foreach (Coin e in receivedCoins)
                    {
                        lstCoin.Add(e);
                    }
                    TransactionReceivedCoins objTransactionReceivedCoins = new TransactionReceivedCoins
                    {
                        ListCoins = lstCoin,
                        TransactionID = op.TransactionId,
                        Confirm = op.Confirmations
                    };
                    list.Add(objTransactionReceivedCoins);
                }
            }
            catch
            {
                list = null;
            }
            return list;

        }
        //private string GenHtmlListPackage()
        //{
        //    IEnumerable<PackageBO> lstPackageBO = null;
        //    StringBuilder strBuilder = new StringBuilder();
        //    lstPackageBO = ObjIPackgeServices.ListAllPackage(1, 10);
        //    if (lstPackageBO != null && lstPackageBO.Count() > 0)
        //    {
        //        int i = 1;
        //        foreach (var item in lstPackageBO)
        //        {
        //            strBuilder.Append("<tr data-id='" + i + "'>");
        //            strBuilder.Append("<td> " + item.PackageName + " </td>");
        //            strBuilder.Append("<td><i class='fa fa-usd'></i> " + item.PackageName + "</td>");
        //            strBuilder.Append("<td><span class='icon-clp-icon'></span> " + item.PackageName + "</td>");
        //            strBuilder.Append("</tr>");
        //            i++;
        //        }
        //    }
        //    return strBuilder.ToString();
        //}
        private List<string> GenHtmlListPackage()
        {
            List<string> lststrHtml = new List<string>();
            IEnumerable<PackageInformationBO> lstPackageInformationBO = null;
            StringBuilder strBuilder = new StringBuilder();
            StringBuilder strBuilderRadioCheck = new StringBuilder();
            lstPackageInformationBO = ObjIPackgeServices.ListAllPackageInformation();
            if (lstPackageInformationBO != null && lstPackageInformationBO.Count() > 0)
            {
                List<string> lstPackageID = new List<string>();
                List<string> lstCoinID = new List<string>();
                List<string> lstCoinName = new List<string>();
                List<string> lstCoin = new List<string>();
                foreach (PackageInformationBO item in lstPackageInformationBO)
                {
                    string strCoin = "";
                    if (lstPackageID.IndexOf(item.PackageID.ToString()) == -1)
                    {
                        lstPackageID.Add(item.PackageID.ToString());
                    }
                    if (lstCoinID.IndexOf(item.CoinID.ToString()) == -1)
                    {
                        lstCoinID.Add(item.CoinID.ToString());
                        strCoin += item.CoinID.ToString() + ";";
                    }
                    if (lstCoinName.IndexOf(item.CoinName.ToString()) == -1)
                    {
                        lstCoinName.Add(item.CoinName.ToString());
                        strCoin += item.CoinName.ToString();
                    }
                    if (strCoin != "")
                    {
                        lstCoin.Add(strCoin);
                    }
                }
                if (lstPackageID.Count > 0 && lstCoinID.Count > 0 && lstCoinName.Count > 0)
                {
                    IEnumerable<PackageInformationBO> lstPackageInformationBOTemp = null;
                    strBuilder.Append("<thead>");
                    strBuilder.Append("<tr id = 'table_th' >");
                    strBuilder.Append("<th> Package </th>");
                    strBuilder.Append("<th> Coin </th>");
                    for (int k = 0; k < lstCoinName.Count; k++)
                    {
                        strBuilder.Append("<th> " + lstCoinName[k] + " </th>");
                    }
                    strBuilder.Append("</tr>");
                    strBuilder.Append("</thead>");
                    strBuilder.Append("<tbody>");
                    for (int i = 0; i < lstPackageID.Count; i++)
                    {
                        strBuilder.Append("<tr data-id='" + lstPackageID[i] + "'>");
                        lstPackageInformationBOTemp = lstPackageInformationBO.Where(x => x.PackageID == int.Parse(lstPackageID[i])).ToList();
                        if (lstPackageInformationBOTemp.Count() > 0)
                        {
                            foreach (var item in lstPackageInformationBOTemp)
                            {
                                strBuilder.Append("<td> " + item.PackageName + " </td>");
                                strBuilder.Append("<td> " + item.PackageValue + " </td>");
                                break;
                            }
                        }
                        for (int j = 0; j < lstCoinID.Count; j++)
                        {
                            if (lstPackageInformationBOTemp.Count() > 0)
                            {
                                foreach (var item in lstPackageInformationBOTemp)
                                {
                                    if (lstCoinID[j] == item.CoinID.ToString())
                                    {
                                        strBuilder.Append("<td> " + item.Price + " </td>");
                                    }
                                }
                            }
                        }
                        strBuilder.Append("</tr>");
                    }
                    strBuilder.Append("</tbody>");
                }

                if (lstCoin.Count > 0)
                {
                    string strChecked = "checked";
                    foreach (var item in lstCoin)
                    {
                        string[] strArray = item.Split(';');
                        if (strArray.Count() > 1)
                        {
                            strBuilderRadioCheck.Append("<div class='form-group'>");
                            strBuilderRadioCheck.Append("<input name = 'groupCheckPackage' type='radio' data-value='" + strArray[0] + "' id='chk" + strArray[1] + "' checked='" + strChecked + "' class='with-gap'>");
                            strBuilderRadioCheck.Append("<label for='chk" + strArray[1] + "'>By " + strArray[1] + "</label>");
                            strBuilderRadioCheck.Append("</div>");
                            strChecked = "";
                        }
                    }
                }
            }
            lststrHtml.Add(strBuilder.ToString());
            lststrHtml.Add(strBuilderRadioCheck.ToString());
            return lststrHtml;
        }
        public void LoadEuVallet()
        {
            IEnumerable<TransactionPackageBO> lstTransactionPackageBO = null;
            ViewBag.EuCoin = "0";
            int memberID = -1;
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                memberID = member.MemberID;
            }
            lstTransactionPackageBO = ObjITransactionPackageService.ListTransactionPackageByMember(memberID);
            if (lstTransactionPackageBO != null && lstTransactionPackageBO.Count() > 0)
            {
                double numberCoin = 0;
                foreach (var item in lstTransactionPackageBO)
                {
                    numberCoin += item.PackageValue;
                }
                ViewBag.EuCoin = double.Parse(numberCoin.ToString()).ToString(); ;
            }

        }
    }
}