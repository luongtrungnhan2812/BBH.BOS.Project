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
                    objMemberBO = new MemberInformationBO
                    {
                        Address = reader["Address"].ToString(),
                        Avatar = reader["Avatar"].ToString(),
                        //objMemberBO.Birdthday = DateTime.Parse(reader["Birdthday"].ToString());
                        //objMemberBO.CreateDate = DateTime.Parse((reader["CreateDate"].ToString()));
                        //objMemberBO.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                        DeleteUser = reader["DeleteUser"].ToString(),
                        Email = reader["Email"].ToString(),
                        //objMemberBO.ExpireTimeLink = DateTime.Parse(reader["ExpireTimeLink"].ToString());
                        FullName = reader["FullName"].ToString(),
                        Gender = int.Parse(reader["Gender"].ToString()),
                        IndexWallet = int.Parse(reader["IndexWallet"].ToString()),
                        IsActive = int.Parse(reader["IsActive"].ToString()),
                        IsDelete = int.Parse(reader["IsDelete"].ToString()),
                        LinkActive = reader["LinkActive"].ToString(),
                        MemberID = int.Parse(reader["MemberID"].ToString()),
                        Mobile = reader["Mobile"].ToString(),
                        NumberCoin = float.Parse(reader["NumberCoin"].ToString()),
                        //objMemberBO.TotalRecord = int.Parse(reader["TotalRecord"].ToString());
                        //objMemberBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                        UpdateUser = reader["UpdateUser"].ToString(),
                        WalletID = int.Parse(reader["WalletID"].ToString())
                    };
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
                
                SqlParameter[] pa = new SqlParameter[9];
                string sql = "SP_InsertMember";
                pa[0] = new SqlParameter("@email", member.Email);
                pa[1] = new SqlParameter("@password", member.Password);
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
                pa[8] = new SqlParameter("@avatar", member.Avatar);

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
                    MemberBO member = new MemberBO
                    {
                        MemberID = int.Parse(reader["MemberID"].ToString()),
                        Password = reader["Password"].ToString(),
                        Email = reader["Email"].ToString(),
                        CreateDate = DateTime.Parse(reader["CreateDate"].ToString()),
                        Address = reader["Address"].ToString(),
                        Avatar = reader["Avatar"].ToString(),
                        Birdthday = DateTime.Parse(reader["Birdthday"].ToString()),
                        DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString()),
                        DeleteUser = reader["DeleteUser"].ToString(),
                        ExpireTimeLink = DateTime.Parse(reader["ExpireTimeLink"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        Gender = int.Parse(reader["Gender"].ToString()),
                        IsActive = int.Parse(reader["IsActive"].ToString()),
                        IsDelete = int.Parse(reader["IsDelete"].ToString()),
                        LinkActive = reader["LinkActive"].ToString(),
                        Mobile = reader["Mobile"].ToString(),
                        UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString()),
                        UpdateUser = reader["UpdateUser"].ToString(),
                        TotalRecord = int.Parse(reader["TOTALROWS"].ToString())
                    };

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
                SqlParameter[] pa = new SqlParameter[10];
                string sql = "SP_UpdateMember";
                pa[0] = new SqlParameter("@email", member.Email);
                pa[1] = new SqlParameter("@password", member.Password);
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
                pa[8] = new SqlParameter("@avatar", member.Avatar);
                pa[9] = new SqlParameter("@memberID", member.MemberID);

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
                    member = new MemberBO
                    {
                        MemberID = int.Parse(reader["MemberID"].ToString()),
                        Email = reader["Email"].ToString(),
                        IsActive = int.Parse(reader["IsActive"].ToString()),
                        IsDelete = int.Parse(reader["IsDelete"].ToString())
                    };
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
        public bool UpdateIsActive(int memberID, int isActive)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_UpdateActive";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@isActive", isActive);
                pa[1] = new SqlParameter("@memberID", memberID);

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

        public bool UpdateIsActiveByEmail(string email, int isActive)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_UpdateActiveByEmail";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@isActive", isActive);
                pa[1] = new SqlParameter("@email", email);

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
        public bool UpdatePasswordMember(string email, string password)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_UpdatePasswordMember";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@email", email);
                pa[1] = new SqlParameter("@password", password);
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
        public MemberInformationBO GetInformationMemberByID(int MemberId)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                MemberInformationBO objMemberBO = null;
                //string sql = "select UserName,Password,ac.GroupID from admin a left join AccessRight ac on a.AdminID=ac.AdminID where UserName=@userName and Password=@pass and IsActive=1 and IsDelete=0";
                string sql = "SP_GetInformationMemberByID";
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@memberid", MemberId);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    objMemberBO = new MemberInformationBO
                    {
                        Address = reader["Address"].ToString(),
                        Avatar = reader["Avatar"].ToString(),
                        //objMemberBO.Birdthday = DateTime.Parse(reader["Birdthday"].ToString());
                        //objMemberBO.CreateDate = DateTime.Parse((reader["CreateDate"].ToString()));
                        //objMemberBO.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                        DeleteUser = reader["DeleteUser"].ToString(),
                        Email = reader["Email"].ToString(),
                        //objMemberBO.ExpireTimeLink = DateTime.Parse(reader["ExpireTimeLink"].ToString());
                        FullName = reader["FullName"].ToString(),
                        Gender = int.Parse(reader["Gender"].ToString()),
                        IndexWallet = int.Parse(reader["IndexWallet"].ToString()),
                        IsActive = int.Parse(reader["IsActive"].ToString()),
                        IsDelete = int.Parse(reader["IsDelete"].ToString()),
                        LinkActive = reader["LinkActive"].ToString(),
                        MemberID = int.Parse(reader["MemberID"].ToString()),
                        Mobile = reader["Mobile"].ToString(),
                        NumberCoin = float.Parse(reader["NumberCoin"].ToString()),
                        //objMemberBO.TotalRecord = int.Parse(reader["TotalRecord"].ToString());
                        //objMemberBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                        UpdateUser = reader["UpdateUser"].ToString(),
                        WalletID = int.Parse(reader["WalletID"].ToString())
                    };
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

    }
}
