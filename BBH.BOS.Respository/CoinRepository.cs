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
    public class CoinRepository : WCFClient<ICoinServices>, ICoinServices
    {
        static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<CoinBO> ListAllCoin()
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                IEnumerable<CoinBO> package = Proxy.ListAllCoin();
                return package;
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
                return null;
            }
        }

    }
}
