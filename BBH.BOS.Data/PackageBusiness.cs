using BBC.Core.Database;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Data
{
   public class PackageBusiness : IPackageService
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<PackageBO> ListAllPackage(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<PackageBO> lstPackage = new List<PackageBO>();
                string sql = "SP_ListAllPackage";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@start", start);
                pa[1] = new SqlParameter("@end", end);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PackageBO package = new PackageBO();
                    package.PackageID = int.Parse(reader["PackageID"].ToString());

                    package.PackageName = reader["PackageName"].ToString();
                    package.IsActive = int.Parse(reader["IsActive"].ToString());
                    package.IsDelete = int.Parse(reader["IsDelete"].ToString());

                    package.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    package.CreateUser = reader["CreateUser"].ToString();
                    package.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                    package.UpdateUser = reader["UpdateUser"].ToString();
                    package.DeleteUser = reader["DeleteUser"].ToString();
                    package.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                    package.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
                    lstPackage.Add(package);

                }
                return lstPackage;
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

        public bool InsertPackage(PackageBO package)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                SqlParameter[] pa = new SqlParameter[9];
                string sql = "SP_InsertPackage";
                pa[0] = new SqlParameter("@packageName", package.PackageName);
                pa[1] = new SqlParameter("@isActive", package.IsActive);
                pa[2] = new SqlParameter("@isDelete", package.IsDelete);
                pa[3] = new SqlParameter("@createDate", package.CreateDate);
                pa[4] = new SqlParameter("@createUser", package.CreateUser);
                pa[5] = new SqlParameter("@updateDate", package.UpdateDate);
                pa[6] = new SqlParameter("@updateUser", package.UpdateUser);
                pa[7] = new SqlParameter("@deleteDate", package.DeleteDate);
                pa[8] = new SqlParameter("@deleteUser", package.DeleteUser);

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
                Utilitys.WriteLog(fileLog, "Exception insert Package : " + ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }


        public bool UpdateMember(PackageBO package, int packageID)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                SqlParameter[] pa = new SqlParameter[10];
                string sql = "SP_UpdatePackage";
                pa[0] = new SqlParameter("@packageName", package.PackageName);
                pa[1] = new SqlParameter("@isActive", package.IsActive);
                pa[2] = new SqlParameter("@isDelete", package.IsDelete);
                pa[3] = new SqlParameter("@createDate", package.CreateDate);
                pa[4] = new SqlParameter("@createUser", package.CreateUser);
                pa[5] = new SqlParameter("@updateDate", package.UpdateDate);
                pa[6] = new SqlParameter("@updateUser", package.UpdateUser);
                pa[7] = new SqlParameter("@deleteDate", package.DeleteDate);
                pa[8] = new SqlParameter("@deleteUser", package.DeleteUser);
                pa[9] = new SqlParameter("@packageID", package.PackageID);

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
                Utilitys.WriteLog(fileLog, "Exception update package : " + ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }
        public bool LockAndUnlockPackage(int packageID, int isActive)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_LockAndUnlockPackage";
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@isActive", isActive);
                pa[1] = new SqlParameter("@packageID", packageID);
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
