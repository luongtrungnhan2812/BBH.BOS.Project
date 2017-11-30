using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBH.BOS.Domain.Entities;
using System.IO;
using BBC.Core.Database;
using System.Data.SqlClient;
using BBH.BOS.Domain.Interfaces;

namespace BBH.BOS.Data
{
     public class Package_CoinBusiness : IPackage_CoinServices
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<Package_CoinBO> ListAllPackageCoin(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<Package_CoinBO> lstPackage = new List<Package_CoinBO>();
                string sql = "SP_ListAllPackageCoin";

                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@start", start);
                pa[1] = new SqlParameter("@end", end);

                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Package_CoinBO packageCoin = new Package_CoinBO();
                    packageCoin.PackageID = int.Parse(reader["PackageID"].ToString());

                    packageCoin.CoinID = int.Parse(reader["CoinID"].ToString());
                    packageCoin.PackageValue = double.Parse(reader["PackageValue"].ToString());
                    packageCoin.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());

                    packageCoin.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
                    lstPackage.Add(packageCoin);

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
        public bool InsertPackageCoin(Package_CoinBO packageCoin)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                SqlParameter[] pa = new SqlParameter[5];
                string sql = "SP_InsertPackageCoin";

                pa[0] = new SqlParameter("@packageID", packageCoin.PackageID);
                pa[1] = new SqlParameter("@coinID", packageCoin.CoinID);
                pa[2] = new SqlParameter("@packageValue", packageCoin.PackageValue);
                pa[3] = new SqlParameter("@createDate", packageCoin.CreateDate);
                pa[4] = new SqlParameter("@isDelete", packageCoin.IsDelete);
                //pa[5] = new SqlParameter("@updateDate", package.UpdateDate);
                //pa[6] = new SqlParameter("@updateUser", package.UpdateUser);
                //pa[7] = new SqlParameter("@deleteDate", package.DeleteDate);
                //pa[8] = new SqlParameter("@deleteUser", package.DeleteUser);

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
        public bool UpdatePackageCoin(Package_CoinBO packageCoin, int packageID,int coinID)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                SqlParameter[] pa = new SqlParameter[4];
                string sql = "SP_UpdatePackageCoin";

                pa[0] = new SqlParameter("@packageID", packageID);
                pa[1] = new SqlParameter("@coinID", coinID);

                pa[2] = new SqlParameter("@packageValue", packageCoin.PackageValue);
                //pa[3] = new SqlParameter("@createDate", packageCoin.CreateDate);
                //pa[2] = new SqlParameter("@isDelete", package.IsDelete);
                //pa[3] = new SqlParameter("@createDate", package.CreateDate);
                //pa[4] = new SqlParameter("@createUser", package.CreateUser);
                //pa[3] = new SqlParameter("@updateDate", package.UpdateDate);
                //pa[4] = new SqlParameter("@updateUser", package.UpdateUser);
                //pa[7] = new SqlParameter("@deleteDate", package.DeleteDate);
                //pa[8] = new SqlParameter("@deleteUser", package.DeleteUser);


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
        public bool UpdateIsDeletePackageCoin(Package_CoinBO package, int packageID,int coinID, int isDelete)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_DeletePackageCoin";
                SqlParameter[] pa = new SqlParameter[6];

                pa[0] = new SqlParameter("@packageID", packageID);
                pa[1] = new SqlParameter("@coinID", package.CoinID);
                pa[2] = new SqlParameter("@packageValue", package.PackageValue);

                pa[3] = new SqlParameter("@isDelete", isDelete);
                pa[4] = new SqlParameter("@deleteDate", package.DeleteDate);
                pa[5] = new SqlParameter("@deleteUser", package.DeleteUser);
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
