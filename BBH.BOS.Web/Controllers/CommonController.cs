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
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class CommonController : Controller
    {
        string masterKey = ConfigurationManager.AppSettings["KeyBOS"];
        string TimeExpired = ConfigurationManager.AppSettings["TimeExpired"];
        [Dependency]
        protected ITransactionWalletService objITransactionWalletService { get; set; }
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
            return PartialView();
        }
        public ActionResult PartialDashboard()
        {
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
                            bool boolCheckExistTransactionID = objITransactionWalletService.CheckExistTransactionBitcoin(item.TransactionID.ToString());
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
                                        TransactionCoinBO objTransactionCoinBO = new TransactionCoinBO();
                                        objTransactionCoinBO.CreateDate = DateTime.Now;
                                        objTransactionCoinBO.ExpireDate = DateTime.Now.AddMinutes(double.Parse(TimeExpired));
                                        objTransactionCoinBO.MemberID = member.MemberID;
                                        objTransactionCoinBO.Note = "Received Coins";
                                        objTransactionCoinBO.QRCode = "";
                                        objTransactionCoinBO.Status = 0;
                                        objTransactionCoinBO.TransactionBitcoin = item.TransactionID.ToString();
                                        objTransactionCoinBO.TransactionID = transactionCode;
                                        objTransactionCoinBO.TypeTransactionID = 0;
                                        objTransactionCoinBO.ValueTransaction = float.Parse(itemListCoins.Amount.ToString());
                                        objTransactionCoinBO.WalletAddressID = userBitPK.GetAddress().ToString();
                                        //objTransactionCoinBO.WalletID = destination.ToString();
                                        bool rs_ = objITransactionWalletService.InsertTransactionCoin(objTransactionCoinBO);
                                        if (rs_)
                                        {
                                            //double pointChange = ((double.Parse(itemListCoins.Amount.ToString())) * PointValue) / CoinValue;
                                            rs = objITransactionWalletService.UpdatePointsMemberFE(member.MemberID, double.Parse(itemListCoins.Amount.ToString()));
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
                    TransactionReceivedCoins objTransactionReceivedCoins = new TransactionReceivedCoins();
                    objTransactionReceivedCoins.ListCoins = lstCoin;
                    objTransactionReceivedCoins.TransactionID = op.TransactionId;
                    objTransactionReceivedCoins.Confirm = op.Confirmations;
                    list.Add(objTransactionReceivedCoins);
                }
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;

        }
    }
}