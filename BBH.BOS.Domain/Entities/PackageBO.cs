using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
   public class PackageBO :BaseEntity
    {
        [DataMember]
        public int PackageID { get; set; }
        [DataMember]
        public string PackageName { get; set; }
        
        [DataMember]
        public int TotalRecord { get; set; }
    }
}
