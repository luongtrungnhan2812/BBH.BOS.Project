using BBH.BOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BBH.BOS.Domain.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionPackage" in both code and config file together.
    [ServiceContract]
    public interface ITransactionPackageService
    {
        [OperationContract]
        bool InsertTransactionPackage(TransactionPackageBO objTransactionPackageBO);
        [OperationContract]
        IEnumerable<TransactionPackageBO> ListTransactionPackageByMember(int memberID);
        [OperationContract]
        TransactionPackageBO DetailTransactionPackage(int memberID, string strTransactionCode);
    }
}
