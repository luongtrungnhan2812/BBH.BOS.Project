using BBC.Core.Utils.Common;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
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
    }
}