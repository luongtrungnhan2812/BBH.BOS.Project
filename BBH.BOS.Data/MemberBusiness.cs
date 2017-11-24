using BBC.Core.Database;
//using BBH.BOS.Domain;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace BBH.BOS.Data
{
    public class MemberBusiness : IIMemberService
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public MemberInformationBO LoginAccount(string username, string password)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                MemberInformationBO objMemberBO = null;
                //string sql = "select UserName,Password,ac.GroupID from admin a left join AccessRight ac on a.AdminID=ac.AdminID where UserName=@userName and Password=@pass and IsActive=1 and IsDelete=0";
                string sql = "SP_LoginAccount";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@email", username);
                pa[1] = new SqlParameter("@pass", password);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    objMemberBO = new MemberInformationBO();
                    objMemberBO.Address = reader["Address"].ToString();
                    objMemberBO.Avatar = reader["Avatar"].ToString();
                    //objMemberBO.Birdthday = DateTime.Parse(reader["Birdthday"].ToString());
                    //objMemberBO.CreateDate = DateTime.Parse((reader["CreateDate"].ToString()));
                    //objMemberBO.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                    objMemberBO.DeleteUser = reader["DeleteUser"].ToString();
                    objMemberBO.Email = reader["Email"].ToString();
                    //objMemberBO.ExpireTimeLink = DateTime.Parse(reader["ExpireTimeLink"].ToString());
                    objMemberBO.FullName = reader["FullName"].ToString();
                    objMemberBO.Gender = int.Parse(reader["Gender"].ToString());
                    objMemberBO.IndexWallet = int.Parse(reader["IndexWallet"].ToString());
                    objMemberBO.IsActive = int.Parse(reader["IsActive"].ToString());
                    objMemberBO.IsDelete = int.Parse(reader["IsDelete"].ToString());
                    objMemberBO.LinkActive = reader["LinkActive"].ToString();
                    objMemberBO.MemberID = int.Parse(reader["MemberID"].ToString());
                    objMemberBO.Mobile = reader["Mobile"].ToString();
                    objMemberBO.NumberCoin = float.Parse(reader["NumberCoin"].ToString());
                    //objMemberBO.TotalRecord = int.Parse(reader["TotalRecord"].ToString());
                    //objMemberBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                    objMemberBO.UpdateUser = reader["UpdateUser"].ToString();
                    objMemberBO.WalletID = int.Parse(reader["WalletID"].ToString());
                }
                return objMemberBO;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, "Exception login Member : " + ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }

        public int InsertMember(MemberBO member)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                
                SqlParameter[] pa = new SqlParameter[8];
                string sql = "SP_InsertMember";
                pa[0] = new SqlParameter("@email", member.Email);
                pa[1] = new SqlParameter("@password", member.Password);
                //pa[2] = new SqlParameter("@avatar", member.Avatar);
                pa[2] = new SqlParameter("@isActive", member.IsActive);
                pa[3] = new SqlParameter("@createDate", member.CreateDate);
                pa[4] = new SqlParameter("@fullName", member.FullName);
                pa[5] = new SqlParameter("@gender", member.Gender);
                pa[6] = new SqlParameter("@mobile", member.Mobile);
                //pa[8] = new SqlParameter("@addRess", member.Address);
              //  pa[9] = new SqlParameter("@updateDate", member.UpdateDate);
                //pa[10] = new SqlParameter("@deleteDate", member.DeleteDate);
                //pa[9] = new SqlParameter("@linkActive", member.LinkActive);
                //pa[12] = new SqlParameter("@deleteUser", member.DeleteUser);
              //  pa[10] = new SqlParameter("@expireTimeLink", member.ExpireTimeLink);
               // pa[11] = new SqlParameter("@birdthday", member.Birdthday);
                //pa[15] = new SqlParameter("@updateUser", member.UpdateUser);
                pa[7] = new SqlParameter("@isDelete", member.IsDelete);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                int memberID = Convert.ToInt32(command.ExecuteScalar());
                return memberID;
                //int row = command.ExecuteNonQuery();
                //bool rs = false;
                //if (row > 0)
                //{
                //    rs = true;
                //}
                //return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, "Exception insert admin : " + ex.Message);
                return 0;
            }
            finally
            {
                helper.destroy();
            }
        }

        public IEnumerable<MemberBO> GetListMember(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<MemberBO> lstMember = new List<MemberBO>();
                string sql = "SP_GetListMember";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@start", start);
                pa[1] = new SqlParameter("@end", end);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MemberBO member = new MemberBO();

                    member.MemberID = int.Parse(reader["MemberID"].ToString());
                    member.Password = reader["Password"].ToString();
                    member.Email = reader["Email"].ToString();
                    member.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    member.Address = reader["Address"].ToString();
                    member.Avatar = reader["Avatar"].ToString();
                    member.Birdthday = DateTime.Parse(reader["Birdthday"].ToString());
                    member.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                    member.DeleteUser = reader["DeleteUser"].ToString();
                    member.ExpireTimeLink = DateTime.Parse(reader["ExpireTimeLink"].ToString());
                    member.FullName = reader["FullName"].ToString();
                    member.Gender = int.Parse(reader["Gender"].ToString());
                    member.IsActive = int.Parse(reader["IsActive"].ToString());
                    member.IsDelete = int.Parse(reader["IsDelete"].ToString());
                    member.LinkActive = reader["LinkActive"].ToString();
                    member.Mobile = reader["Mobile"].ToString();
                    member.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                    member.UpdateUser = reader["UpdateUser"].ToString();
                    member.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());

                    lstMember.Add(member);

                }
                return lstMember;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }

        public bool UpdateMember(MemberBO member, int memberID)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                SqlParameter[] pa = new SqlParameter[18];
                string sql = "SP_UpdateMember";
                pa[0] = new SqlParameter("@email", member.Email);
                pa[1] = new SqlParameter("@pass", member.Password);
                pa[2] = new SqlParameter("@avatar", member.Avatar);
                pa[3] = new SqlParameter("@isActive", member.IsActive);
                pa[4] = new SqlParameter("@createDate", member.CreateDate);
                pa[5] = new SqlParameter("@fullName", member.FullName);
                pa[6] = new SqlParameter("@gender", member.Gender);
                pa[7] = new SqlParameter("@mobile", member.Mobile);
                pa[8] = new SqlParameter("@address", member.Address);
                pa[9] = new SqlParameter("@updateDate", member.UpdateDate);
                pa[10] = new SqlParameter("@deleteDate", member.DeleteDate);
                pa[11] = new SqlParameter("@linkActive", member.LinkActive);
                pa[12] = new SqlParameter("@deleteUser", member.DeleteUser);
                pa[13] = new SqlParameter("@expireTimeLink", member.ExpireTimeLink);
                pa[14] = new SqlParameter("@birdthday", member.Birdthday);
                pa[15] = new SqlParameter("@updateUser", member.UpdateUser);
                pa[16] = new SqlParameter("@isDelete", member.IsDelete);
                pa[17] = new SqlParameter("@memberID", member.MemberID);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                //adminID = Convert.ToInt32(command.ExecuteScalar());
                //return adminID;
                int row = command.ExecuteNonQuery();
                bool rs = false;
                if (row > 0)
                {
                    rs = true;
                }
                return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, "Exception insert admin : " + ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }

        public bool CheckEmailExists(string email)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_CheckEmailExistsFE";
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@email", email);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    rs = true;
                }
                return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }
        public MemberBO GetMemberDetailByEmail(string email)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));

            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                MemberBO member = null;
                string sql = "SP_GetMemberByEmail";
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@email", email);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    member = new MemberBO();
                    member.MemberID = int.Parse(reader["MemberID"].ToString());
                    member.Email = reader["Email"].ToString();
                    member.IsActive = int.Parse(reader["IsActive"].ToString());
                    member.IsDelete = int.Parse(reader["IsDelete"].ToString());
                }
                return member;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }
        public bool InsertMemberWallet(Member_WalletBO objMember_WalletBO)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_InsertMemberWallet";
                SqlParameter[] pa = new SqlParameter[5];
             
                pa[0] = new SqlParameter("@IndexWallet", objMember_WalletBO.IndexWallet);
                pa[1] = new SqlParameter("@IsActive", objMember_WalletBO.IsActive);
                pa[2] = new SqlParameter("@IsDelete", objMember_WalletBO.IsDelete);
                pa[3] = new SqlParameter("@MemberID", objMember_WalletBO.MemberID);
                pa[4] = new SqlParameter("@NumberCoin", objMember_WalletBO.NumberCoin);
              
                SqlCommand command = helper.GetCommand(sql, pa, true);
                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    rs = true;
                }
                return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }

    }
}
