using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class ExpenseService
    {
        public bool CreateExpense(ExpenseCreate model)
        {
            var entity =
                new Expense()
                {
                    ExpenseId = model.ExpenseId,
                    AccountId = model.AccountId,
                    ExpenseAmount = model.ExpenseAmount,
                    ExpenseName = model.ExpenseName,
                    DueDate = model.DueDate


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Expenses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
