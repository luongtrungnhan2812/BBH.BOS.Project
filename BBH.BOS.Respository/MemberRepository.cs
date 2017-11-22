using BBC.Core.WebService;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Respository
{
    public class MemberRepository : WCFClient<IIMemberService>, IIMemberService
    {
        static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public MemberBO LoginAccount(string username, string password)
        {
            MemberBO objMemberBO = null;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                objMemberBO = Proxy.LoginAccount(username, password);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return objMemberBO;
        }
    }
}
