using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.Expense;
using MoneyManager.Models.SavExpense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class SavExpenseService
    {
        public bool CreateExpense(SavExpenseCreate model)
        {
            var entity =
                new SavExpense()
                {
                    SavExpenseId = model.SavExpenseId,
                    AccountId = model.AccountId,
                    SavExpenseAmount = model.SavExpenseAmount,
                    SavExpenseName = model.SavExpenseName,
                    SavDueDate = model.SavDueDate


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SavExpenses.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<SavExpenseListItem> GetSavExpenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SavExpenses
                        .Where(e => e.AccountId == e.AccountId)
                        .Select(
                            e =>
                                new SavExpenseListItem
                                {
                                    SavExpenseId = e.SavExpenseId,
                                    AccountId = e.AccountId,
                                    SavExpenseAmount = e.SavExpenseAmount,
                                    SavExpenseName = e.SavExpenseName,
                                    SavDueDate = e.SavDueDate
                                }
                        );

                return query.ToArray();
            }
        }
        public SavExpenseDetail GetSavExpenseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SavExpenses
                        .Single(e => e.SavExpenseId == id);
                return
                    new SavExpenseDetail
                    {
                        SavExpenseId = entity.SavExpenseId,
                        AccountId = entity.AccountId,
                        SavExpenseAmount = entity.SavExpenseAmount,
                        SavExpenseName = entity.SavExpenseName,
                        SavDueDate = entity.SavDueDate
                    };
            }
        }
        public bool UpdateSavExpense(SavExpenseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SavExpenses
                        .Single(e => e.SavExpenseId == model.SavExpenseId);

                entity.SavExpenseAmount = model.SavExpenseAmount;
                entity.SavExpenseName = model.SavExpenseName;
                entity.SavDueDate = model.SavDueDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSavExpense(int savExpenseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SavExpenses
                        .Single(e => e.SavExpenseId == savExpenseId);

                ctx.SavExpenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
