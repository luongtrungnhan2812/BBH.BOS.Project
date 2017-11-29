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
    public interface ICoinServices
    {
        [OperationContract]
        IEnumerable<CoinBO> ListAllCoin();

    }
}
