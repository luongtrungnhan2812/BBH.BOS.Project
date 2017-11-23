using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
   public class Member_WalletBO : BaseEntity
    {
        [DataMember]
        public int WalletID { get; set; }
        [DataMember]
        public int MemberID { get; set; }
        [DataMember]
        public int IndexWallet { get; set; }
        [DataMember]
        public int NumberCoin { get; set; }
        
    }
}
