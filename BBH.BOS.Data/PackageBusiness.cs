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
   public class PackageBusiness : IPackgeServices
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
                    package.DeleteUser = reader["Email"].ToString();
                    package.DeleteDate = DateTime.Parse(reader["DeleteDate"].ToString());
                    //package.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
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
    }
}
