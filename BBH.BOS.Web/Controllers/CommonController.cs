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
            return PartialView(GenHtmlListPackage());
        }
        public ActionResult PartialDashboard()
        {
            LoadPoint();
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = member.NumberCoin.ToString();
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
                        if (item.Confirm > 5)
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
        private string GenHtmlListPackage()
        {
            List<PackageBO> lstPackageBO = new List<PackageBO>();
            StringBuilder strBuilder = new StringBuilder();
            if (lstPackageBO != null && lstPackageBO.Count > 0)
            {
                int i = 1;
                foreach (var item in lstPackageBO)
                {
                    strBuilder.Append("<tr data-id='" + i + "'>");
                    strBuilder.Append("<td> " + item.PackageName + " </td>");
                    strBuilder.Append("<td><i class='fa fa-usd'></i> " + item.PackageValue + "</td>");
                    strBuilder.Append("<td><span class='icon-clp-icon'></span> " + item.PackageValue + "</td>");
                    strBuilder.Append("</tr>");
                    i++;
                }
            }
            return strBuilder.ToString();
        }
    }
}