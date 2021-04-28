using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.CkExpense
{
    public class CkExpenseListItem
    {
        public int CkExpenseId { get; set; }

        public int AccountId { get; set; }

        public decimal CkExpenseAmount { get; set; }

        public string CkExpenseName { get; set; }

        public DateTime CkDueDate { get; set; }
    }
}