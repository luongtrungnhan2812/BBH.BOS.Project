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
    public class Package_CoinRepository : WCFClient<IPackage_CoinServices>, IPackage_CoinServices
    {
        static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<Package_CoinBO> ListAllPackageCoin(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                IEnumerable<Package_CoinBO> packageCoin = Proxy.ListAllPackageCoin(start, end);
                return packageCoin;
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
                return null;
            }
        }
    }
}
