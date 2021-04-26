﻿using System;
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

        [ForeignKey(nameof(RetirementAcct))]
        public int AccountId { get; set; }

        public virtual RetirementAcct RetirementAcct { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        
        public DateTime DueDate { get; set; }
    }
}
