using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [ForeignKey(nameof(User))]
        public int AccountId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public decimal ExpenseAmmount { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
