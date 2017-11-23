using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        public ActionResult WalletBTC()
        {
            return View();
        }
    }
}