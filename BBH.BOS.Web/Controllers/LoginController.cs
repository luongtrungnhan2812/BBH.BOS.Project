using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using BBH.BOS.Domain;
using BBH.BOS.Respository;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Domain.Entities;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BBH.BOS.Web.Controllers
{
    public class LoginController : Controller
    {
        string secretKey = ConfigurationManager.AppSettings["secretKey"];

        [Dependency]

        protected IIMemberService services { get; set; }
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
            if (status == false)
            {
                result = "loginfaile";
            }
            else
            {
                string email = Request.Form["txtEmail"];
                string pass = Request.Form["txtPassword"];

                MemberBO member = services.LoginAccount(email, pass);
                if(member!=null)
                {
                    result = "loginSuccess";
                    if (Session["username"] == null)
                    {

                        Session["username"] = member.Email;

                    }
                   
                    Session["memberid"] = member.MemberID;
                    //Session["ewallet"] = member.E_Wallet;
                    //Session["Points"] = member.Points;
                    Session["MemberInfomation"] = member;
                    Session["Emailmember"] = email;
                    Session["FullName"] = member.FullName;
                }
                else
                {
                    result = "loginfaile";
                }
            }
            Session["result"] = result;
            Response.Redirect("/");
            return result;
        }

        [HttpPost]
        public void SetTimeoutSession()
        {
            Session["result"] = null;
        }

        [HttpPost]
        public string LogoutMember(string str)
        {
           
            string result = "";
            Session["memberid"] = null;
            Session["username"] = null;
            Session["ewallet"] = null;
            Session["MemberInfomation"] = null;
            if (Request.Cookies["Login"] != null)
            {
                Response.Cookies["Login"].Expires = DateTime.Now.AddDays(-1);
            }
            result = str;
            return result;
        }
    }
}