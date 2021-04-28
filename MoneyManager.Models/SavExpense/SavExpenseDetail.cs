using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.SavExpense
{
    public class SavExpenseDetail
    {

        public int SavExpenseId { get; set; }

        public int AccountId { get; set; }

        public decimal SavExpenseAmount { get; set; }

        public string SavExpenseName { get; set; }

        public DateTime SavDueDate { get; set; }
    }
}
