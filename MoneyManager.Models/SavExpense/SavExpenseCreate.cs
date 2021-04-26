using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.Expense
{
    public class SavExpenseCreate
    {

        [Key]
        public int SavExpenseId { get; set; }

        public int AccountId { get; set; }

        [Required]
        public decimal SavExpenseAmount { get; set; }

        [Required]
        public string SavExpenseName { get; set; }

        [Required]
        public DateTime SavDueDate { get; set; }
    }

}

