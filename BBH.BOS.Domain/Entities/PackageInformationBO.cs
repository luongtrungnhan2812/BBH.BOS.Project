using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class PackageInformationBO
    {
        [DataMember]
        public int PackageID { get; set; }
        [DataMember]
        public string PackageName { get; set; }

        [DataMember]
        public int TotalRecord { get; set; }
        [DataMember]
        public int CoinID { get; set; }
        [DataMember]
        public double PackageValue { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public int IsDelete { get; set; }
        [DataMember]
        public DateTime DeleteDate { get; set; }
        [DataMember]
        public string DeleteUser { get; set; }
        [DataMember]
        public string CoinName { get; set; }

    }
}
