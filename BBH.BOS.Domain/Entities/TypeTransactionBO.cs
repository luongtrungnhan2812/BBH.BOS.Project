using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class TypeTransactionBO
    {
        [DataMember]
        public int TypeTransactionID { get; set; }
        [DataMember]
        public string TypeTransactionName { get; set; }
        [DataMember]
        public int IsActive { get; set; }
    }
}
