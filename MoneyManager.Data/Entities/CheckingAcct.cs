using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class CheckingAcct
    {

        [Key]
        public int AccountId { get; set; }

        [ForeignKey(nameof(User))]
        [Display(Name = "Checking Account Number")]
        public int UserAcctNumber { get; set; }

        public virtual User User { get; set; }

        [Display(Name = "Checking Account Name")]
        public string CkAcctName { get; set; }

        public decimal CkAcctBalance { get; set; }

        


    }
}
