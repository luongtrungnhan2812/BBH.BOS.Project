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
using BBH.BOS.Web.SentMailServices;

namespace BBH.BOS.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [Dependency]
        protected IIMemberService repository { get; set; }

        string secKey = ConfigurationManager.AppSettings["SecrecKey"];
        SendMailSvcClient sentMail = new SendMailSvcClient();

        public ActionResult Index()
        {
            //if (Session["Email"] == null)
            //{
            //    Response.Redirect("/login");
            //}
            //int totalRecord = 0;
            //int intPageSize = 10;
            //int start = 0, end = 10;
            ////Int32.TryParse(ConfigurationManager.AppSettings["NumberRecordPage"], out intPageSize);

            //int page = 1;
            //try
            //{
            //    if (p != null && p != "")
            //    {
            //        page = int.Parse(p);
            //    }
            //}
            //catch
            //{

            //}
            //if (page > 1)
            //{
            //    start = (page - 1) * intPageSize + 1;
            //    end = (page * intPageSize);
            //}
            //IEnumerable<MemberBO> lstMember = repository.GetListMember(start,end);
            //    if (lstMember != null && lstMember.Count() > 0)
            //    {
            //        string Emaail = lstMember.ElementAt(0).Email;
            //    }
            //    ViewData["ListAdmin"] = lstMember;
                //IEnumerable<GroupAdminBO> lstGroupAdmin = repository.ListGroupAdmin();
                //ViewData["ListGroupAdmin"] = lstGroupAdmin;
            

            return View();
        }

        [HttpPost]
        public string RegisterMember()
 //string address, string password, string avatar, int isDelete,DateTime birthday, int isActive, int gender, DateTime updateDate, DateTime deleteDate, string updateUser, string linkActive, DateTime expireTimeLink, DateTime createDate,string deleteUser)
        {
            string result = "";
            MemberBO member = new MemberBO();
            //if (Session["Email"] == null)
            //{
            //    Response.Redirect("/login");
            //}
            //else
            //{
            //if ((int)Session["GroupID"] != 1)
            //{
            //    Response.Redirect("/");
            //}
            //if (memberID > 0)
            //{
            //    member.FullName = fullName;
            //    member.Email = email;
            //    member.Mobile = mobile;


            //    bool rs = repository.UpdateMember( member,memberID);


            //}
            //else if (memberID == 0)
            //{

            string email = Request["txtEmail"];
            string password = Request["txtPassword"];
            string mobile = Request["txtMobile"];
            string fullName = Request["txtFullName"];

            TempData["EmailRegister"] = email;
            TempData["PasswordRegister"] = password;
            TempData["FullNameRegister"] = fullName;
            TempData["MobileRegister"] = mobile;


            string response = Request.Form["g-recaptcha-response"];
            string secretKey ="6LfhJyUUAAAAAPKM6Hl87lD0mVKa-0zPKNR53W_j";
            var client = new WebClient();
            var result1 = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result1);
            var status = (bool)obj.SelectToken("success");
            if (status == false)
            {
                result = "errorCaptcha";
            }
            else
            {
               
                     member.FullName = fullName;
                    member.Email = email;
                    member.Mobile = mobile;
                member.Password = Utility.MaHoaMD5(password);
                    member.IsActive = 0;
                    member.IsDelete = 0;
                    //member.Hashkey = "1234";
                    member.CreateDate = DateTime.Now;
                    member.Gender = 1;

                  
                bool checkEmail = repository.CheckEmailExists(email);
                if (checkEmail)
                {
                    result="EmailExist";
                }
                else
                {
                    int returnAdminID = repository.InsertMember(member);
                    if (returnAdminID > 0)
                    {
                       bool rsSendMail= sentMail.SendMailByVerifyMember(email); 
                        member = repository.GetMemberDetailByEmail(email);
                        Member_WalletBO memberWallet = new Member_WalletBO();
                        if(member!=null)
                        {
                            memberWallet.IndexWallet = member.MemberID;
                            memberWallet.IsActive = 1;
                            memberWallet.IsDelete = 0;
                            memberWallet.MemberID = member.MemberID;
                            memberWallet.NumberCoin = 0;
                        }
                        bool rs_ = repository.InsertMemberWallet(memberWallet);
                       
                        result = "registerSuccess";
                       
                    }
                    else
                    {
                        result = "RegisterFaile";
                    }
                    //result = "insertsuccess";
                }
                
                
            }
            Session["Result"] = result;
            Response.Redirect("/registermember");

            return result;
        }
        [HttpPost]
        public void SetTimeoutSession()
        {
            Session["Result"] = null;
        }
        
        public ActionResult VerifyEmailMember(string email)
        {
            bool rs = false;
            rs = repository.UpdateIsActiveByEmail(email,1);
            if (rs)
            {
                MemberBO mem = repository.GetMemberDetailByEmail(email);
                if (mem != null)
                {
                    Session["Email"] = email;

                    Session["memberid"] = mem.MemberID;
                    Session["MemberInfomation"] = mem;
                    Response.Redirect("/");
                }
            }
            else
            {
                Response.Redirect("/errorpage");
            }
            return View();
        }
    }
}