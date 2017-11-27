using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOSCMS.Domain
{
    public class PackageBO
    {
        [DataMember]
        public int PackageID { get; set; }

        [DataMember]
        public string PackageName { get; set; }

        [DataMember]
        public int IsActive { get; set; }

        [DataMember]
        public int IsDelete { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string CreateUser { get; set; }

        [DataMember]
        public DateTime UpdateDate { get; set; }

        [DataMember]
        public string UpdateUser { get; set; }

        [DataMember]
        public DateTime DeleteDate { get; set; }

        [DataMember]
        public string DeleteUser { get; set; }
    }
}
