using BBC.Core.WebService;
using BBH.BOS.Shared;
using BBH.BOSCMS.Domain;
using BBH.BOSCMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOSCMS.Repository
{
    public class PackageRepository : WCFClient<IPackgeServices>, IPackgeServices
    {
        static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        public IEnumerable<PackageBO> ListAllPackage(int start, int end)
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                IEnumerable<PackageBO> package = Proxy.ListAllPackage(start, end);
                return package;
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
                return null;
            }
        }

        //public IEnumerable<MemberBO> GetListMember(int start, int end)
        //{
        //    string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
        //    try
        //    {
        //        IEnumerable<MemberBO> objMemberBO = Proxy.GetListMember(start, end);
        //        return objMemberBO;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.WriteLog(fileLog, ex.Message);
        //        return null;
        //    }
        //}

        //public int InsertMember(MemberBO member)
        //{
        //    int row = 0;
        //    string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
        //    try
        //    {
        //        row = Proxy.InsertMember(member);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.WriteLog(fileLog, ex.Message);
        //    }
        //    return row;
        //}
    }
}
