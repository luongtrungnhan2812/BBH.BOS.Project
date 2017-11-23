using BBH.BOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Deposit(string strWalletAddress = "18BVEnR3F3T4pwt83Yyu6q8w5F5Mf2hknx")
        {
            ViewBag.WalletAddress = strWalletAddress;
            string strQRCode = Utility.GenQRCode(strWalletAddress);
            ViewBag.DataQRCode = "data:image/png;base64," + strQRCode + "";
            return PartialView();
        }
    }
}