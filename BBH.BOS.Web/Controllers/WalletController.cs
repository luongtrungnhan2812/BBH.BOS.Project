using BBH.BOS.Domain.Entities;
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
            if (Session["MemberInfomation"] != null)
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                ViewBag.NumberCoin = member.NumberCoin.ToString();
            }
            else
            {
                ViewBag.NumberCoin = "0";
            }
            return View();
        }
    }
}