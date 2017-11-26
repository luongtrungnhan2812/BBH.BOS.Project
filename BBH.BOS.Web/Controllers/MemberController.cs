using BBC.Core.Utils.Common;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
using BBH.BOS.Web.SentMailServices;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class MemberController : Controller
    {
        [Dependency]
        protected IIMemberService memberServices { get; set; }

        SendMailSvcClient sentMail = new SendMailSvcClient();

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string UpdatePassMember(string password)
        {
            string result = "";
            if (Session["MemberInfomation"] == null)
            {
                Response.Redirect("/login");
            }
            else
            {
                MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                if (member != null)
                {
                    string passmd5 = Utility.MaHoaMD5(password);
                    bool rs = memberServices.UpdatePasswordMember(member.Email, passmd5);
                    if (rs)
                    {
                        result = "UpdatePassSuccess";
                    }
                }
            }
            return result;
        }

       public string SendMailResetPassword(string email)
        {
            string result = "";
            if (email == "")
            {
                result = "emtry";
            }
            else
            {
                bool checkEmailexit = memberServices.CheckEmailExists(email);
                if (!checkEmailexit)
                {
                    result = "EmailNotExit";
                }
                else
                {
                    string genPass = Utility.GenCode();
                    string pass = Utility.MaHoaMD5(genPass);
                    try
                    {
                        if (pass != "")
                        {
                            memberServices.UpdatePasswordMember(email, pass);
                        }
                        bool resetPass = sentMail.SendMailResetPassword(email, genPass);
                        if (resetPass)
                        {
                            result = "ResetPassSuccess";
                        }
                        else
                        {
                            result = "ResetPassfaile";
                        }
                    }
                    catch { }
                }
                
            }
            return result;
        }
    }
}