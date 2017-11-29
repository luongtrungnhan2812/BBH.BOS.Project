using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class CoinBO
    {
        [DataMember]
        public int CoinID { get; set; }
        [DataMember]
        public string CoinName { get; set; }
        [DataMember]
        public int IsDelete { get; set; }
    }
}
