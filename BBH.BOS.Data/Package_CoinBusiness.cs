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
                    packageCoin.PackageValue = int.Parse(reader["PackageValue"].ToString());
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
    }
}
