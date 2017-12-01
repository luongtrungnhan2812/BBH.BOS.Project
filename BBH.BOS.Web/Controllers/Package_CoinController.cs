using BBH.BOS.Domain.Entities;
using BBH.BOS.Respository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class Package_CoinController : Controller
    {
        [Dependency]
        protected Package_CoinRepository packageCoinRepository { get; set; }

        [Dependency]
        protected PackageRepository packageRopository { get; set; }

        [Dependency]
        protected CoinRepository coinRopository { get; set; }

        // GET: Package_Coin
        public ActionResult Index(string p)
        {
            if (Session["Emailmember"] == null)
            {
                Response.Redirect("/login");
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
            IEnumerable<Package_CoinBO> lstPackageCoin = packageCoinRepository.ListAllPackageCoin(start, end);
            ViewData["PackageCoin"] = lstPackageCoin;
            if (lstPackageCoin != null && lstPackageCoin.Count() > 0)
            {
                totalRecord = lstPackageCoin.ElementAt(0).TotalRecord;
            }
            TempData["TotalRecord"] = totalRecord;

            IEnumerable<PackageBO> lstPackage = packageRopository.ListAllPackage(start, end);
            ViewData["ListPackage"] = lstPackage;

            IEnumerable<CoinBO> lstCoin = coinRopository.ListAllCoin();
            ViewData["ListCoin"] = lstCoin;

            return View();
        }

        [HttpPost]
        public string UpdateIsDeletePackageCoin(Package_CoinBO packageCoin, int packageID,int coinID, int isDelete)
        {
            string result = "";
            int statusNew = -1;
            if (isDelete == 0)
            {
                statusNew = 1;
            }
            else
            {
                statusNew = 0;
            }
            packageCoin.IsDelete = statusNew;
            packageCoin.DeleteDate = DateTime.Now;
            packageCoin.DeleteUser = (string)Session["FullName"];

            bool rs = packageCoinRepository.UpdateIsDeletePackageCoin(packageCoin, packageID, coinID, statusNew);
            if (rs)
            {
                result = "success";
            }
            return result;
        }
        [HttpPost]
        public string UpdatePackageCoin(int packageID, int coinID, double packageValue)
        {
            string result = "";
            Package_CoinBO packageCoin = new Package_CoinBO();
            //if (Session["Emailmember"] == null)
            //{
            //    Response.Redirect("/login");
            //}
            try
            {
                packageCoin.PackageValue = packageValue;
                packageCoin.PackageID = packageID;
                packageCoin.CoinID = coinID;

                bool CheckPackageID_CoinIDExist = packageCoinRepository.CheckPackageID_CoinIDExist(packageID, coinID);
                if (CheckPackageID_CoinIDExist)
                {
                    result = "PackageCoinIDExist";
                }
                else
                {
                    bool updatePackage = packageCoinRepository.UpdatePackageCoin(packageCoin, packageID, coinID);
                    if (updatePackage)
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
            return result;
        }

        [HttpPost]
        public string SavePackageCoin(int packageID,int coinID, double packageValue)
        {
            string result = "";
            Package_CoinBO packageCoin = new Package_CoinBO();

            if (Session["Emailmember"] == null)
            {
                Response.Redirect("/login");
            }
            if (packageID == 0)
            {
                try
                {
                    packageCoin.PackageValue = packageValue;
                    packageCoin.PackageID = packageID;
                    packageCoin.CoinID = coinID;

                    bool CheckPackageID_CoinIDExist = packageCoinRepository.CheckPackageID_CoinIDExist(packageID, coinID);
                    if (CheckPackageID_CoinIDExist)
                    {
                        result = "PackageCoinIDExist";
                    }
                    else
                    {
                        bool updatePackage = packageCoinRepository.UpdatePackageCoin(packageCoin, packageID, coinID);
                        if (updatePackage)
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
            else if (packageID >0)
            {
                try
                {
                    packageCoin.PackageID = packageID;
                    packageCoin.CoinID = coinID;
                    packageCoin.PackageValue = packageValue;
                    packageCoin.IsDelete = 0;
                    packageCoin.CreateDate = DateTime.Now;

                    bool CheckPackageID_CoinIDExist = packageCoinRepository.CheckPackageID_CoinIDExist(packageID, coinID);
                    if (CheckPackageID_CoinIDExist)
                    {
                        result = "PackageCoinIDExist";
                    }
                    else
                    {
                        bool insert = packageCoinRepository.InsertPackageCoin(packageCoin);
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

            return result;
        }

    }
}