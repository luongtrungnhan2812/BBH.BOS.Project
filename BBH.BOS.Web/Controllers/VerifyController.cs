using BBH.BOS.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class VerifyController : Controller
    {
        // GET: Verify
        public ActionResult Index(string strValue="")
        {
            string key = ConfigurationManager.AppSettings["KeyCode"];
            string hostVerify = ConfigurationManager.AppSettings["HostSite"];
            string linkAction = strValue.Replace(hostVerify, "");
            linkAction = strValue.Replace("_", "+").Replace("@", "/");
            string linkDecrypt = Utility.DecryptText(linkAction, key);
            string linkVerify = hostVerify + linkDecrypt;
            Response.Redirect(linkVerify);
            return View();
        }
    }
}