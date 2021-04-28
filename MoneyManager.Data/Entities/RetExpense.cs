using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class RetExpense
    {
        [Key]
        public int RetExpenseId { get; set; }

        [ForeignKey(nameof(RetirementAcct))]
        public int AccountId { get; set; }

        public virtual RetirementAcct RetirementAcct { get; set; }

        [Required]
        public decimal RetExpenseAmount { get; set; }

        [Required]
        public string RetExpenseName { get; set; }

        
        public DateTime RetDueDate { get; set; }
    }
}
