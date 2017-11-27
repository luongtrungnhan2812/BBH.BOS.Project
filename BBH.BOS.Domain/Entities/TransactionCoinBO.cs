using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class TransactionCoinBO
    {
        [DataMember]
        public string TransactionID { get; set; }
        [DataMember]
        public string WalletAddressID { get; set; }
        [DataMember]
        public int MemberID { get; set; }
        [DataMember]
        public double ValueTransaction { get; set; }
        [DataMember]
        public string QRCode { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public DateTime ExpireDate { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public string WalletID { get; set; }
        [DataMember]
        public int TypeTransactionID { get; set; }
        [DataMember]
        public string TransactionBitcoin { get; set; }
        [DataMember]
        public double TotalRecord { get; set; }
    }
}
