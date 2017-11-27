using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
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
        // GET: Package
        public ActionResult Index(string p)
        {
            //if (Session["UserName"] == null)
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
            IEnumerable<PackageBO> lstPackage = Packagerepository.ListAllPackage(start, end);
            ViewData["Package"] = lstPackage;
            if (lstPackage != null && lstPackage.Count() > 0)
            {
                totalRecord = lstPackage.ElementAt(0).TotalRecord;
            }
            TempData["TotalRecord"] = totalRecord;
            return View();
        }
    }
}