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

        //[Dependency]
        //protected CoinRepository coinRopository { get; set; }

        // GET: Package_Coin
        public ActionResult Index(string p)
        {
            //if (Session["Emailmember"] == null)
            //{
            //    Response.Redirect("/login");
            //}


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

            return View();
        }
    }
}