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
using BBH.BOS.Shared;

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
            //ViewBag.Username = "-1";
            //ViewBag.Password = "-1";
            //ViewBag.Result = "-1";
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
        //[HttpPost]
        //public ActionResult LoginMember()
        //{
        //    ViewBag.Result = "-1";
        //    string result = "";
        //    string strCapcha = Request["g-recaptcha-response"].ToString();
        //    string email = Request.Form["txtEmail"];
        //    string pass = Request.Form["txtPassword"];
        //    var response = strCapcha;
        //    var client = new WebClient();
        //    result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
        //    var obj = JObject.Parse(result);
        //    var status = (bool)obj.SelectToken("success");
        //    if (status == false)
        //    {
        //        ViewBag.Result = "captchafaile";
        //    }
        //    else
        //    {
        //        bool checkNotActive = services.CheckEmailNotActive(email);
        //        if (!checkNotActive)
        //        {
        //            ViewBag.Result = "EmailNotActive";
        //        }
        //        else
        //        {
        //            string strpass = Utility.MaHoaMD5(pass);
        //            MemberInformationBO member = services.LoginAccount(email, strpass);
        //            if (member != null)
        //            {
        //                ViewBag.Result = "loginSuccess";
        //                if (Session["username"] == null)
        //                {

        //                    Session["username"] = member.Email;

        //                }

        //                Session["memberid"] = member.MemberID;
        //                Session["Avatar"] = member.Avatar;
        //                Session["FullName"] = member.FullName;
        //                Session["Mobile"] = member.Mobile;
        //                Session["MemberInfomation"] = member;
        //                Session["Emailmember"] = email;
        //            }
        //            else
        //            {
        //                ViewBag.Result = "loginfaile";
        //            }
        //        }
        //        ViewBag.Username = email;
        //        ViewBag.Password = pass;
        //    }

        //    return View("Index");
        //}

        [HttpPost]
        public JsonResult LoginMember(string strEmail, string strPassword, string strCaptcha)
        {
            try
            {
                if (strEmail == null || strEmail.Trim().Length == 0)
                {
                    return Json(new { intTypeError = 1, result = "", email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
                }
                if (strEmail.Trim().Length >50)
                {
                    return Json(new { intTypeError = 4, result = "", email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
                }
                if (strPassword==null || strPassword.Trim().Length==0)
                {
                    return Json(new { intTypeError = 2, result = "", email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
                }
                if (strPassword.Trim().Length < 8)
                {
                    return Json(new { intTypeError = 5, result = "", email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
                }
                if (strCaptcha == null || strCaptcha.Trim().Length==0)
                {
                    return Json(new { intTypeError = 3, result = "", email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
                }

                string strResult = "";
                TempData["EmailRegister"] = strEmail;
                TempData["PasswordRegister"] = strPassword;

                var response = strCaptcha;
                var client = new WebClient();
               var strResult1 = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(strResult1);
                var status = (bool)obj.SelectToken("success");
                if (status == false)
                {
                    strResult = "captchafaile";
                }
                else
                {
                    bool checkEmailExit = services.CheckEmailExists(strEmail);
                    if (!checkEmailExit)
                    {
                        strResult = "EmailNotExits";
                    }
                    else
                    {
                        bool checkNotActive = services.CheckEmailNotActive(strEmail);
                        if (!checkNotActive)
                        {
                            strResult = "EmailNotActive";
                        }
                        else
                        {
                            string strpass = Utility.MaHoaMD5(strPassword);
                            MemberInformationBO member = services.LoginAccount(strEmail, strpass);
                            if (member != null)
                            {
                                strResult = "loginSuccess";
                                if (Session["username"] == null)
                                {
                                    Session["username"] = member.Email;
                                }
                                Session["memberid"] = member.MemberID;
                                Session["Avatar"] = member.Avatar;
                                Session["FullName"] = member.FullName;
                                Session["Mobile"] = member.Mobile;
                                Session["MemberInfomation"] = member;
                                Session["Emailmember"] = strEmail;
                            }
                            else
                            {
                                strResult = "loginfaile";
                            }
                        }
                    }
                    //ViewBag.Username = email;
                    //ViewBag.Password = pass;
                }
                return Json(new { intTypeError = 0, result = strResult, email = strEmail, password = strPassword }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { intTypeError = 0, result = "loginfaile", email = strEmail, password = strPassword,messageError=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public void SetTimeoutSession()
        {
            Session["result"] = null;
        }

        [HttpPost]
        public string LogoutMember(string tr)
        {
            Session.RemoveAll();
            string result = "";
            Session["Emailmember"] = null;
            Session["memberid"] = null;
            Session["username"] = null;
            Session["ewallet"] = null;
            Session["MemberInfomation"] = null;
            if (Request.Cookies["Login"] != null)
            {
                Response.Cookies["Login"].Expires = DateTime.Now.AddDays(-1);
            }
            result = tr;
            return result;
        }
    }
}