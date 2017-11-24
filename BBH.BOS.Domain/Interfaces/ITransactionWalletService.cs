using BBH.BOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BBH.BOS.Domain.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionWalletService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionWalletService
    {
        [OperationContract]
        IEnumerable<TransactionCoinBO> ListTransactionWalletBySearch(int memberID, DateTime fromDate, DateTime toDate, int start, int end);
        [OperationContract]
        IEnumerable<TransactionCoinBO> ListTransactionWalletByMember(int memberID, int start, int end);
        [OperationContract]
        bool CheckExistTransactionBitcoin(string strTransactionID);
        [OperationContract]
        bool InsertTransactionCoin(TransactionCoinBO transaction);
        [OperationContract]
        bool UpdatePointsMemberFE(int memberID, double points);
    }
}
