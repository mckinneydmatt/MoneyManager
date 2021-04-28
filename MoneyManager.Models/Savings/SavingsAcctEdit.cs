using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
   public class SavingsAcctEdit
    {
        public int AccountId { get; set; }

        public int UserAcctNumber { get; set; }

        public string SvAcctName { get; set; }

        public decimal SvAcctBalance { get; set; }
    }
}
