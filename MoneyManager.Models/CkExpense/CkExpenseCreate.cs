using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.CkExpense
{
    public class CkExpenseCreate
    {

        [Key]
        public int CkExpenseId { get; set; }

        public int AccountId { get; set; }

        [Required]
        public decimal CkExpenseAmount { get; set; }

        [Required]
        public string CkExpenseName { get; set; }

        [Required]
        public DateTime CkDueDate { get; set; }
    }

}

