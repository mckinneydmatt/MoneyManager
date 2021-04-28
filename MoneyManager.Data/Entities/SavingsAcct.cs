using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class SavingsAcct
    {
        [Key]
        public int AccountId { get; set; }


        [ForeignKey(nameof(User))]
        public int UserAcctNumber { get; set; }

        public virtual User User { get; set; }

      
        public string SvAcctName { get; set; }

        public decimal SvAcctBalance { get; set; }
    }
}
