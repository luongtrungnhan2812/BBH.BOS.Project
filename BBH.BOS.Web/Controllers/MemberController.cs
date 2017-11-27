using BBC.Core.Utils.Common;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
using BBH.BOS.Web.SentMailServices;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
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

        [HttpPost]
        public string UpdatePrototypeMember(int memberID,string email, string fullName, string mobile, string avatar, HttpPostedFileBase fileup)
        {
            string result = "";
            Random r = new Random();
            string s = r.Next(100000).ToString() + DateTime.Now.ToString() + "" + DateTime.Now.Ticks.ToString();
            MemberBO member = new MemberBO();

            member.Email = email;
            member.FullName = fullName;
            member.Mobile = mobile;
            //member.Avatar = avatar;
            if (fileup != null)
            {
                string years = string.Format("{0:yyyy}", System.DateTime.Now);
                string mon = string.Format("{0:MM}", System.DateTime.Now);
                string day = string.Format("{0:dd}", System.DateTime.Now);

                string filePath = Server.MapPath("~/imageAvatar/" + years + "/" + mon + "/" + day + "/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string img = s + fileup.FileName;
                img =Utility.EncodeString(img) + ".jpg";
                string images = filePath + img;
                fileup.SaveAs(images);
                avatar = "~/imageAvatar/" + years + "/" + mon + "/" + day + "/" + img;
                //string filePath = Server.MapPath("~/Areas/Admin/ImagePost/" + fileup.FileName);
                //fileup.SaveAs(filePath);
                //imageUrl = "/Areas/Admin/ImagePost/" + fileup.FileName;


            }

            bool  memberUpdate =memberServices.UpdateMember(member, memberID);
            if(memberUpdate)
            {
                result = "UpdateSuccess";
            }
            
            return result;
        }

    }
}