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
    public class TransactionPackageRepository: WCFClient<ITransactionPackageService>, ITransactionPackageService
    {
        public bool InsertTransactionPackage(TransactionPackageBO objTransactionPackageBO)
        {
            try
            {
                return Proxy.InsertTransactionPackage(objTransactionPackageBO);
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<TransactionPackageBO> ListTransactionPackageByMember(int memberID)
        {
            try
            {
                return Proxy.ListTransactionPackageByMember(memberID);
            }
            catch
            {
                return null;
            }
        }
    }
}
