using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class MemberBO : BaseEntity
    {
        public int MemberID { get; set; }
        public string Email { get; set; }
        public string E_Wallet { get; set; }
        public string Password { get; set; }
        public double Points { get; set; }
        public int TotalRecord { get; set; }
        public int TotalNewMember { get; set; }
        public int TotalAllMember { get; set; }
    }
}
