using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.Expense;
using MoneyManager.Models.RetExpense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class RetExpenseService
    {
        public bool CreateExpense(RetExpenseCreate model)
        {
            var entity =
                new RetExpense()
                {
                    RetExpenseId = model.RetExpenseId,
                    AccountId = model.AccountId,
                    RetExpenseAmount = model.RetExpenseAmount,
                    RetExpenseName = model.RetExpenseName,
                    RetDueDate = model.RetDueDate


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RetExpenses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RetExpenseListItem> GetRetExpenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RetExpenses
                        .Where(e => e.AccountId == e.AccountId)
                        .Select(
                            e =>
                                new RetExpenseListItem
                                {
                                    RetExpenseId = e.RetExpenseId,
                                    AccountId = e.AccountId,
                                    RetExpenseAmount = e.RetExpenseAmount,
                                    RetExpenseName = e.RetExpenseName,
                                    RetDueDate = e.RetDueDate
                                }
                        );

                return query.ToArray();
            }
        }
        public RetExpenseDetail GetRetExpenseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RetExpenses
                        .Single(e => e.RetExpenseId == id);
                return
                    new RetExpenseDetail
                    {
                        RetExpenseId = entity.RetExpenseId,
                        AccountId = entity.AccountId,
                        RetExpenseAmount = entity.RetExpenseAmount,
                        RetExpenseName = entity.RetExpenseName,
                        RetDueDate = entity.RetDueDate
                    };
            }
        }
        public bool UpdateRetExpense(RetExpenseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RetExpenses
                        .Single(e => e.RetExpenseId == model.RetExpenseId);

                entity.RetExpenseAmount = model.RetExpenseAmount;
                entity.RetExpenseName = model.RetExpenseName;
                entity.RetDueDate = model.RetDueDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRetExpense(int retExpenseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RetExpenses
                        .Single(e => e.RetExpenseId == retExpenseId);

                ctx.RetExpenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
