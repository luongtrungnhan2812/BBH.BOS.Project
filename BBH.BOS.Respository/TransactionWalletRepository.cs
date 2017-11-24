using BBC.Core.WebService;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Respository
{
    public class TransactionWalletRepository : WCFClient<ITransactionWalletService>, ITransactionWalletService
    {
        public IEnumerable<TransactionCoinBO> ListTransactionWalletBySearch(int memberID, System.DateTime fromDate, System.DateTime toDate, int start, int end)
        {
            try
            {
                return Proxy.ListTransactionWalletBySearch(memberID, fromDate, toDate, start, end);
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<TransactionCoinBO> ListTransactionWalletByMember(int memberID, int start, int end)
        {
            try
            {
                return Proxy.ListTransactionWalletByMember(memberID, start, end);
            }
            catch
            {
                return null;
            }
        }
        public bool CheckExistTransactionBitcoin(string strTransactionID)
        {
            try
            {
                return Proxy.CheckExistTransactionBitcoin(strTransactionID);
            }
            catch
            {
                return false;
            }
        }
        public bool InsertTransactionCoin(TransactionCoinBO transaction)
        {
            try
            {
                return Proxy.InsertTransactionCoin(transaction);
            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePointsMemberFE(int memberID, double points)
        {
            try
            {
                return Proxy.UpdatePointsMemberFE(memberID, points);
            }
            catch
            {
                return false;
            }
        }
    }
}
