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
    public class CoinController : Controller
    {
        [Dependency]
        protected CoinRepository coinRopository { get; set; }
        // GET: Coin
        public ActionResult Index()
        {
            IEnumerable<CoinBO> lstCoin = coinRopository.ListAllCoin();
            ViewData["ListCoin"] = lstCoin;
            return View();
        }
    }
}