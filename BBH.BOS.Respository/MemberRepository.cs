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
        public MemberInformationBO LoginAccount(string username, string password)
        {
            MemberInformationBO objMemberBO = null;
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

        public IEnumerable<MemberBO> GetListMember(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                IEnumerable<MemberBO> objMemberBO = Proxy.GetListMember(start, end);
                return objMemberBO;
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
                return null;
            }
        }

        public int InsertMember(MemberBO member)
        {
            int row = 0;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.InsertMember(member);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }

        public bool UpdateMember(MemberBO member, int memberID)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.UpdateMember(member,memberID);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
        public bool CheckEmailExists(string email)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.CheckEmailExists(email);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
        public MemberBO GetMemberDetailByEmail(string email)
        {
            MemberBO objMemberBO = null;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                objMemberBO = Proxy.GetMemberDetailByEmail(email);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return objMemberBO;
        }
        public bool InsertMemberWallet(Member_WalletBO member)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.InsertMemberWallet(member);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
        public bool UpdateIsActive(int memberID, int isActive)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.UpdateIsActive(memberID,isActive);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
        public bool UpdateIsActiveByEmail(string email, int isActive)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.UpdateIsActiveByEmail(email, isActive);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
    }
}
