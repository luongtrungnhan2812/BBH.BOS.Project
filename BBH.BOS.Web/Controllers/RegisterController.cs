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

        string secretKey = ConfigurationManager.AppSettings["secretKey"];
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

        //       [HttpPost]
        //       public string RegisterMember()
        ////string address, string password, string avatar, int isDelete,DateTime birthday, int isActive, int gender, DateTime updateDate, DateTime deleteDate, string updateUser, string linkActive, DateTime expireTimeLink, DateTime createDate,string deleteUser)
        //       {
        //           string result = "";
        //           MemberBO member = new MemberBO();

        //           string email = Request["txtEmail"];
        //           string password = Request["txtPassword"];
        //           //string mobile = Request["txtMobile"];
        //           string fullName = Request["txtFullName"];

        //           TempData["EmailRegister"] = email;
        //           TempData["PasswordRegister"] = password;
        //           TempData["FullNameRegister"] = fullName;
        //           //TempData["MobileRegister"] = mobile;


        //           string strCaptcha = Request["g-recaptcha-response"].ToString();
        //          // string secretKey = secKey;/*"6LfhJyUUAAAAAPKM6Hl87lD0mVKa-0zPKNR53W_j";*/
        //           var client = new WebClient();
        //           var response = strCaptcha;
        //           var result1 = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
        //           var obj = JObject.Parse(result1);
        //           var status = (bool)obj.SelectToken("success");
        //           if (status == false)
        //           {
        //               result = "errorCaptcha";
        //           }
        //           else
        //           {

        //               member.FullName = fullName;
        //               member.Email = email;
        //               member.Mobile = "";
        //               member.Password = Utility.MaHoaMD5(password);
        //               member.IsActive = 0;
        //               member.IsDelete = 0;
        //               member.CreateDate = DateTime.Now;
        //               member.Gender = 1;
        //               member.Avatar = "";

        //               bool checkEmail = repository.CheckEmailExists(email);
        //               if (checkEmail)
        //               {
        //                   result="EmailExist";
        //               }
        //               else
        //               {

        //                   int returnAdminID = repository.InsertMember(member);
        //                   if (returnAdminID > 0)
        //                   {
        //                       try
        //                       {
        //                           bool rsSendMail = sentMail.SendMailByVerifyMember(email);

        //                           member = repository.GetMemberDetailByEmail(email);
        //                           Member_WalletBO memberWallet = new Member_WalletBO();
        //                           if (member != null)
        //                           {
        //                               memberWallet.IndexWallet = member.MemberID;
        //                               memberWallet.IsActive = 1;
        //                               memberWallet.IsDelete = 0;
        //                               memberWallet.MemberID = member.MemberID;
        //                               memberWallet.NumberCoin = 0;
        //                           }
        //                           bool rs_ = repository.InsertMemberWallet(memberWallet);
        //                           if (rs_)
        //                           {
        //                               result = "registerSuccess";
        //                           }
        //                       }
        //                       catch { }
        //                   }
        //                   else
        //                   {
        //                       result = "RegisterFaile";
        //                   }

        //               }

        //           }
        //           Session["Result"] = result;
        //           Response.Redirect("/registermember");

        //           return result;
        //       }
        [HttpPost]
        public JsonResult RegisterMember(string strEmail, string strPassword, string strFullName, string strCaptcha)
        {
            try
            {
                // Email null 
                if (strEmail == null || strEmail.Trim().Length == 0)
                {
                    return Json(new { intTypeError = 1, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }
                //Email maxlength > 50
                else if (strEmail.Trim().Length > 50)
                {
                    return Json(new { intTypeError = 2, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }
                //password null || error
                if (strPassword == null || strPassword.Trim().Length == 0)
                {
                    return Json(new { InputType = 3, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }
                //password maxlenght >=8
                else if (strPassword.Trim().Length < 8)
                {
                    return Json(new { InputType = 4, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }
                //fullname error || null
                if (strFullName == null || strFullName.Trim().Length == 0)
                {
                    return Json(new { intTypeError = 5, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }
                //Captcha error || null
                if (strCaptcha == null || strCaptcha.Trim().Length == 0)
                {
                    return Json(new { intTypeError = 6, result = "", email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
                }

                string strResult = "";
                MemberBO member = new MemberBO();

                TempData["EmailRegister"] = strEmail;
                TempData["PasswordRegister"] = strPassword;
                TempData["FullNameRegister"] = strFullName;
                //TempData["MobileRegister"] = mobile;


                //string strCaptcha = Request["g-recaptcha-response"].ToString();
                // string secretKey = secKey;/*"6LfhJyUUAAAAAPKM6Hl87lD0mVKa-0zPKNR53W_j";*/
                var client = new WebClient();
                var response = strCaptcha;
                var result1 = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result1);
                var status = (bool)obj.SelectToken("success");
                if (status == false)
                {
                    strResult = "errorCaptcha";
                }
                else
                {

                    member.FullName = strFullName;
                    member.Email = strEmail;
                    member.Mobile = "";
                    member.Password = Utility.MaHoaMD5(strPassword);
                    member.IsActive = 0;
                    member.IsDelete = 0;
                    member.CreateDate = DateTime.Now;
                    member.Gender = 1;
                    member.Avatar = "";

                    bool checkEmail = repository.CheckEmailExists(strEmail);
                    if (checkEmail)
                    {
                        strResult = "EmailExist";
                    }
                    else
                    {

                        int returnAdminID = repository.InsertMember(member);
                        if (returnAdminID > 0)
                        {
                            try
                            {
                                bool rsSendMail = BBH.BOS.Web.Models.SentMailServicesModels.WSSentMail.SendMailByVerifyMember(strEmail);

                                member = repository.GetMemberDetailByEmail(strEmail);
                                Member_WalletBO memberWallet = new Member_WalletBO();
                                if (member != null)
                                {
                                    memberWallet.IndexWallet = member.MemberID;
                                    memberWallet.IsActive = 1;
                                    memberWallet.IsDelete = 0;
                                    memberWallet.MemberID = member.MemberID;
                                    memberWallet.NumberCoin = 0;
                                }
                                bool rs_ = repository.InsertMemberWallet(memberWallet);
                                if (rs_)
                                {
                                    strResult = "registerSuccess";
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            strResult = "RegisterFaile";
                        }

                    }

                }
                return Json(new { intTypeError = 0, result = strResult, email = strEmail, password = strPassword, fullname = strFullName }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception objEx)
            {
                return Json(new { intTypeError = 0, result = "RegisterFaile", email = strEmail, password = strPassword, fullname = strFullName, messageError = objEx.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public void SetTimeoutSession()
        {
            Session["Result"] = null;
        }

        public ActionResult VerifyEmailMember(string email)
        {
            bool rs = false;
            rs = repository.UpdateIsActiveByEmail(email, 1);
            if (rs)
            {
                //MemberInformationBO mem = repository.GetMemberDetailByEmail(email);
                MemberBO mem = repository.GetMemberDetailByEmail(email);
                if (mem != null)
                {
                    Session["Email"] = email;
                    Session["Avatar"] = mem.Avatar;
                    Session["FullName"] = mem.FullName;
                    //Session["Mobile"] = mem.Mobile;
                    Session["memberid"] = mem.MemberID;
                    //Session["MemberInfomation"] = mem;
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