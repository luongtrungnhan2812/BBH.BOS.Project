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
        bool LockAndUnlockPackage(int packageID, int isActive);

        [OperationContract]
        bool UpdateMember(PackageBO package, int packageID);

        [OperationContract]
        bool InsertPackage(PackageBO package);



    }
}
