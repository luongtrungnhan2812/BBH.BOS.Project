using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBH.BOS.Web.Models
{
    public class TransactionReceivedCoins
    {
        public uint256 TransactionID { get; set; }
        public int Confirm { get; set; }
        public List<Coin> ListCoins { get; set; }
    }
}