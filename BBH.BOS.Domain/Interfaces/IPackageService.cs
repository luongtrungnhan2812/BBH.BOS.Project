using BBH.BOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Interfaces
{
    [ServiceContract]
    public interface IPackageService
    {
        [OperationContract]
        IEnumerable<PackageBO> ListAllPackage(int start, int end);

        [OperationContract]
        bool UpdateIsDeletePackage(PackageBO package,int packageID, int isDelete);

        [OperationContract]
        bool UpdatePackage(PackageBO package, int packageID);

        [OperationContract]
        bool InsertPackage(PackageBO package);
        [OperationContract]
        bool CheckPackageNameExists(string packageName);
        [OperationContract]
        IEnumerable<PackageInformationBO> ListAllPackageInformation();



    }
}
