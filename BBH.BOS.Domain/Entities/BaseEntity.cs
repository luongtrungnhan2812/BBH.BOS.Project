using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        //public string CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime DeleteDate { get; set; }
        public string DeleteUser { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
    }
}
