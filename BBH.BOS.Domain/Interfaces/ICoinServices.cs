using BBH.BOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BBH.BOS.Domain.Interfaces
{
    [ServiceContract]
    public interface ICoinServices
    {
        [OperationContract]
        IEnumerable<CoinBO> ListAllCoin();
      

    }
}
