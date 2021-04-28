using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class CkExpense
    {
        [Key]
        public int CkExpenseId { get; set; }

        [ForeignKey(nameof(CheckingAcct))]
        public int AccountId { get; set; }

        public virtual CheckingAcct CheckingAcct { get; set; }

        [Required]
        public decimal CkExpenseAmount { get; set; }

        [Required]
        public string CkExpenseName { get; set; }


        public DateTime CkDueDate { get; set; }
    }
}
