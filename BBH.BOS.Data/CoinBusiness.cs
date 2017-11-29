using BBC.Core.Database;
using BBH.BOS.Domain.Entities;
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
    public class CoinBusiness
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<CoinBO> ListAllCoin()
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<CoinBO> lstPackage = new List<CoinBO>();
                string sql = "SP_ListAllCoin";


                SqlCommand command = helper.GetCommandNonParameter(sql, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CoinBO packageCoin = new CoinBO();

                    packageCoin.CoinID = int.Parse(reader["CoinID"].ToString());
                    packageCoin.CoinName = reader["PackageValue"].ToString();
                    packageCoin.IsDelete = int.Parse(reader["CreateDate"].ToString());

                    //packageCoin.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
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
