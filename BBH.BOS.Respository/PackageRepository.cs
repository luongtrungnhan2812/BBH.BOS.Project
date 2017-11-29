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
    public class PackageRepository : WCFClient<IPackageService>, IPackageService
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

        public bool UpdateIsDeletePackage(PackageBO package,int packageID, int isDelete)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.UpdateIsDeletePackage(package,packageID, isDelete);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }

        public bool UpdatePackage(PackageBO package, int packageID)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.UpdatePackage(package,packageID);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }

        public bool InsertPackage(PackageBO package)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.InsertPackage(package);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }

        public bool CheckPackageNameExists(string packageName)
        {
            bool row = false;
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                row = Proxy.CheckPackageNameExists(packageName);
            }
            catch (Exception ex)
            {
                Utility.WriteLog(fileLog, ex.Message);
            }
            return row;
        }
        public IEnumerable<PackageInformationBO> ListAllPackageInformation()
        {
            string fileLog = Path.GetDirectoryName(Path.Combine(pathLog));
            try
            {
                IEnumerable<PackageInformationBO> package = Proxy.ListAllPackageInformation();
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
