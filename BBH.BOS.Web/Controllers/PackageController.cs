﻿using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class PackageController : Controller
    {
        [Dependency]
        protected IPackageService Packagerepository { get; set; }
        [Dependency]
        protected ITransactionPackageService TransactionPackageRepository { get; set; }
        [Dependency]
        protected IPackage_CoinServices IPackage_CoinServices { get; set; }
        // GET: Package
        public ActionResult Index(string p)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/");
            }


            int totalRecord = 0;
            int intPageSize = 10;
            int start = 0, end = 10;

            int page = 1;
            try
            {
                if (p != null && p != "")
                {
                    page = int.Parse(p);
                }
            }
            catch
            {

            }
            if (page > 1)
            {
                start = (page - 1) * intPageSize + 1;
                end = (page * intPageSize);
            }
            IEnumerable<PackageBO> lstPackage = Packagerepository.ListAllPackage(start, end);
            ViewData["Package"] = lstPackage;
            if (lstPackage != null && lstPackage.Count() > 0)
            {
                totalRecord = lstPackage.ElementAt(0).TotalRecord;
            }
            TempData["TotalRecord"] = totalRecord;
            return View();
        }
        [HttpPost]
        public string UpdateIsDeletePackage(PackageBO package, int packageID, int isDelete)
        {
            string result = "";
            //PackageBO package = new PackageBO();
            int statusNew = -1;
            if (isDelete == 1)
            {
                statusNew = 0;
            }
            else
            {
                statusNew = 1;
            }
            package.IsDelete = statusNew;
            package.DeleteDate = DateTime.Now;
            package.DeleteUser = (string)Session["FullName"];

            bool rs = Packagerepository.UpdateIsDeletePackage(package, packageID, statusNew);
            if (rs)
            {

                result = "success";
            }
            return result;
        }

        [HttpPost]
        public string SavePackage(int packageID, string packageName, double packageValue)
        {
            string result = "";
            PackageBO package = new PackageBO();

            if (Session["Emailmember"] == null)
            {
                Response.Redirect("/login");
            }
            if (packageID > 0)
            {
                try
                {
                    package.PackageName = packageName;
                    package.PackageValue = packageValue;
                    package.IsActive = 1;
                    package.UpdateDate = DateTime.Now;
                    package.UpdateUser = (string)Session["FullName"];

                    bool updatePackage = Packagerepository.UpdatePackage(package, packageID);
                    if (updatePackage)
                    {
                        result = "Updatesuccess";
                    }
                    else
                    {
                        result = "Updatefaile";
                    }
                }
                catch { result = "Erorr"; }
            }
            else if (packageID == 0)
            {
                try
                {
                    package.PackageName = packageName;
                    package.PackageValue = packageValue;
                    package.IsActive = 1;
                    package.IsDelete = 0;
                    package.CreateDate = DateTime.Now;
                    package.CreateUser = (string)Session["FullName"];
                    //package.DeleteDate = DateTime.Parse("1/1/1990");
                    //package.DeleteUser = "";
                    //package.UpdateDate = DateTime.Parse("1/1/1990");
                    //package.UpdateUser = "";

                    bool checkExitsPackageName = Packagerepository.CheckPackageNameExists(packageName);
                    if (checkExitsPackageName)
                    {
                        result = "PackageNameExist";
                    }
                    else
                    {
                        bool insert = Packagerepository.InsertPackage(package);
                        if (insert)
                        {
                            result = "Updatesuccess";
                        }
                        else
                        {
                            result = "Updatefaile";
                        }
                    }
                }
                catch { result = "Erorr"; }
            }
            //else if(result=="delete")
            //{
            //    try
            //    {
            //        package.PackageName = packageName;
            //        package.IsDelete = 0;
            //        package.DeleteDate = DateTime.Now;
            //        package.DeleteUser = (string)Session["FullName"];

            //        bool updatePackage = Packagerepository.UpdatePackage(package, packageID);
            //        if (updatePackage)
            //        {
            //            result = "Updatesuccess";
            //        }
            //        else
            //        {
            //            result = "Updatefaile";
            //        }
            //    }
            //    catch { result = "Erorr"; }
            //}
            return result;
        }

        [HttpPost]
        public string InsertTransactionPackage(string packageId, string coinId)
        {
            MemberInformationBO member = new MemberInformationBO();
            Package_CoinBO objPackage_CoinBO = new Package_CoinBO();
            double NumberCoin = 0;
            double PackageValue = 0;
            string result = "Fail";
            if (Session["MemberInfomation"] != null)
            {
                member = (MemberInformationBO)Session["MemberInfomation"];
                NumberCoin = member.NumberCoin;
            }
            else
            {
                Response.Redirect("/");
            }
            objPackage_CoinBO = IPackage_CoinServices.GetCoinValueByID(int.Parse(packageId), int.Parse(coinId));
            if(objPackage_CoinBO != null)
            {
                PackageValue = objPackage_CoinBO.PackageValue;
            }
            if (NumberCoin > 0)
            {
                if (NumberCoin >= PackageValue)
                {
                    string strCode = Utility.GenCode();
                    string tick = DateTime.Now.Ticks.ToString();
                    string transactionCode = Utility.MaHoaMD5(strCode + tick);
                    bool rs = TransactionPackageRepository.InsertTransactionPackage(new TransactionPackageBO
                    {
                        CoinID = int.Parse(coinId),
                        CreateDate = DateTime.Now,
                        ExpireDate = DateTime.Now.AddDays(30),
                        ExchangeRateID = -1,
                        MemberID = member.MemberID,
                        Note = "Buy package",
                        PackageID = int.Parse(packageId),
                        Status = 1,
                        TransactionCode = transactionCode,
                        TransactionBitcoin = "",
                        PackageValue = PackageValue
                    });
                    if (rs)
                    {
                        result = "success";
                    }
                }
                else
                {
                    result = "You do not enough coin.";
                }
            }
            else
            {
                result = "Please recharge your wallet.";
            }
            return result;

        }
    }
}