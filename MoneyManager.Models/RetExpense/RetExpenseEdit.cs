using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.RetExpense
{
    public class RetExpenseEdit
    {
        public int RetExpenseId { get; set; }
        public int AccountId { get; set; }
        public decimal RetExpenseAmount { get; set; }
        public string RetExpenseName { get; set; }
        public DateTime RetDueDate { get; set; }
    }
}
