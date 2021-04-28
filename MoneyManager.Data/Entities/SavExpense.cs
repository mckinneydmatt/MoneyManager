using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class SavExpense
    {
        [Key]
        public int SavExpenseId { get; set; }

        [ForeignKey(nameof(SavingsAcct))]
        public int AccountId { get; set; }

        public virtual SavingsAcct SavingsAcct { get; set; }

        [Required]
        public decimal SavExpenseAmount { get; set; }

        [Required]
        public string SavExpenseName { get; set; }


        public DateTime SavDueDate { get; set; }
    }
}
