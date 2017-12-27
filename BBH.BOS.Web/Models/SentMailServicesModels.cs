using BBH.BOS.Web.SentMailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBH.BOS.Web.Models
{
    /// <summary>
    /// Created by: Lý Kiến Đức
    /// Created date: 20.12.2017
    /// Description: Thông tin instances và domain connect Services SentMail
    /// </summary>
    public class SentMailServicesModels
    {
        const string WSPath = "SendMailSvc.svc";
        static SendMailSvcClient objWSSentMail = null;
        public static SendMailSvcClient WSSentMail
        {
            get
            {
                //Khởi tạo object Services Mail
                if (objWSSentMail == null)
                {
                    objWSSentMail = new SendMailSvcClient();
                    objWSSentMail.Endpoint.Address = new System.ServiceModel.EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["WSSentmailServices"] + "/" + WSPath);
                }

                return objWSSentMail;
            }
        }
    }
}