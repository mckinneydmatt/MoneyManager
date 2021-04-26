using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.Expense
{
    public class ExpenseCreate
    {
       
        [Key]
        public int ExpenseId { get; set; }

        public int AccountId { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }

}

