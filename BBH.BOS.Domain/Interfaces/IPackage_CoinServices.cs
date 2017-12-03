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
    public interface  IPackage_CoinServices
    {
        [OperationContract]
        IEnumerable<Package_CoinBO> ListAllPackageCoin(int start, int end);

        [OperationContract]
         IEnumerable<Package_CoinBO> ListAllPackage_Coin();

        [OperationContract]
        bool InsertPackageCoin(Package_CoinBO packageCoin);

        [OperationContract]
        bool UpdatePackageCoin(Package_CoinBO packageCoin, int packageID, int coinID);
        [OperationContract]
        bool UpdateIsDeletePackageCoin(Package_CoinBO package, int packageID, int coinID, int isDelete);

        [OperationContract]
        bool CheckPackageID_CoinIDExist(int packageID, int coinID);
    }
}
