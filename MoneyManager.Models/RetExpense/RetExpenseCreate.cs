using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.Expense
{
    public class RetExpenseCreate
    {
       
        [Key]
        public int RetExpenseId { get; set; }

        public int AccountId { get; set; }

        [Required]
        public decimal RetExpenseAmount { get; set; }

        [Required]
        public string RetExpenseName { get; set; }

        public DateTime RetDueDate { get; set; }
    }

}

