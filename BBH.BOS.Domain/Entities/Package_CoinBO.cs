using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class Package_CoinBO
    {
        [DataMember]
        public int PackageID { get; set; }
        [DataMember]
        public int CoinID { get; set; }
        [DataMember]
        public int PackageValue { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public int TotalRecord { get; set; }
    }
}
