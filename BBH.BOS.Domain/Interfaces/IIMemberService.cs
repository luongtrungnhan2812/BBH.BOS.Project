﻿using BBH.BOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BBH.BOS.Domain.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIMemberService" in both code and config file together.
    [ServiceContract]
    public interface IIMemberService
    {
        [OperationContract]
        MemberBO LoginAccount(string username, string password);
        [OperationContract]
        IEnumerable<MemberBO> GetListMember(int start, int end);
        [OperationContract]
        bool UpdateMember(MemberBO member, int memberID);
        [OperationContract]
        int InsertMember(MemberBO member);
        [OperationContract]
        bool CheckEmailExists(string email);
        [OperationContract]
        MemberBO GetMemberDetailByEmail(string email);
        [OperationContract]
        bool InsertMemberWallet(Member_WalletBO objMember_WalletBO);



    }
}
