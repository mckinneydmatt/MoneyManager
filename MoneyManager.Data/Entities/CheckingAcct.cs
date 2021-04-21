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
        public int UserAccountNumber { get; set; }

        public virtual User Users { get; set; }

        public string CkAcctName { get; set; }

        public decimal CkAcctBalance { get; set; }
    }
}
