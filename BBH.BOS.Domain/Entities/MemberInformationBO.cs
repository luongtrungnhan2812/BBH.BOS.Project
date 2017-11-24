using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class MemberInformationBO : BaseEntity
    {
        [DataMember]
        public int MemberID { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Avatar { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public DateTime Birdthday { get; set; }
        [DataMember]
        public string LinkActive { get; set; }
        [DataMember]
        public DateTime ExpireTimeLink { get; set; }
        [DataMember]
        public int WalletID { get; set; }
        [DataMember]
        public int IndexWallet { get; set; }
        [DataMember]
        public float NumberCoin { get; set; }
        [DataMember]
        public int TotalRecord { get; set; }
    }
}
