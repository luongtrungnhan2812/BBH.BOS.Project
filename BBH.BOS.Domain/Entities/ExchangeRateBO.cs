using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class ExchangeRateBO : BaseEntity
    {
        [DataMember]
        public int ExchangeRateID { get; set; }
        [DataMember]
        public string ExchangeRateName { get; set; }
        [DataMember]
        public int ExchangeValue { get; set; }
      
    }
}
