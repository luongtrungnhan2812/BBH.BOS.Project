using BBC.Core.Database;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace BBH.BOS.Data
{
    public class MemberBusiness : IIMemberService
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public MemberBO LoginAccount(string username, string password)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                MemberBO objMemberBO = null;
                //string sql = "select UserName,Password,ac.GroupID from admin a left join AccessRight ac on a.AdminID=ac.AdminID where UserName=@userName and Password=@pass and IsActive=1 and IsDelete=0";
                string sql = "SP_LoginManagerAccount";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@userName", username);
                pa[1] = new SqlParameter("@pass", password);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    objMemberBO = new MemberBO();
                    objMemberBO.Email = reader["UserName"].ToString();
                }
                return objMemberBO;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, "Exception login admin : " + ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }
    }
}
