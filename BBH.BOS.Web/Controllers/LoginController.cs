using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class LoginController : Controller
    {
        string secretKey = ConfigurationManager.AppSettings["secretKey"];
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditAccount()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public string LoginMember()
        {
            string result = "";
            string strCapcha = Request["g-recaptcha-response"].ToString();
            var response = strCapcha;
            var client = new WebClient();
            result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            if (status == true)
            {
                result = "loginSuccess";
            }
            else
            {
                result = "loginfaile";
            }
            return result;
        }
    }
}