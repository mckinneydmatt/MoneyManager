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


        //[ForeignKey(nameof(User))]
        [Display(Name = "Savings Account Number")]
        public int UserAccountNumber { get; set; }

       // public virtual User Users { get; set; }
       [Display(Name = "Savings Account Name")]
        public string SvAcctName { get; set; }

        public decimal SvAcctBalance { get; set; }
    }
}
