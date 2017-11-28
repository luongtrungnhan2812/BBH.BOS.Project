using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class TransactionPackageBO
    {
        [DataMember]
        public int ExchangeRateID { get; set; }
        [DataMember]
        public int PackageID { get; set; }
        [DataMember]
        public int CoinID { get; set; }
        [DataMember]
        public int MemberID { get; set; }
        [DataMember]
        public string TransactionCode { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public DateTime ExpireDate { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public string TransactionBitcoin { get; set; }
    }
}
