using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Data
{
    public class MemberBusiness : IIMemberService
    {
        public MemberBO LoginManagerAccount(string username, string password)
        {
            MemberBO objMemberBO = new MemberBO();
            return objMemberBO;
        }
    }
}
