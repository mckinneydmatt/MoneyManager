using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.Expense;
using MoneyManager.Models.CkExpense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class CkExpenseService
    {
        public bool CreateExpense(CkExpenseCreate model)
        {
            var entity =
                new CkExpense()
                {
                    CkExpenseId = model.CkExpenseId,
                    AccountId = model.AccountId,
                    CkExpenseAmount = model.CkExpenseAmount,
                    CkExpenseName = model.CkExpenseName,
                    CkDueDate = model.CkDueDate


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CkExpenses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CkExpenseListItem> GetCkExpenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CkExpenses
                        .Where(e => e.AccountId == e.AccountId)
                        .Select(
                            e =>
                                new CkExpenseListItem
                                {
                                    CkExpenseId = e.CkExpenseId,
                                    AccountId = e.AccountId,
                                    CkExpenseAmount = e.CkExpenseAmount,
                                    CkExpenseName = e.CkExpenseName,
                                    CkDueDate = e.CkDueDate
                                }
                        );

                return query.ToArray();
            }
        }
        public CkExpenseDetail GetCkExpenseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CkExpenses
                        .Single(e => e.CkExpenseId == id);
                return
                    new CkExpenseDetail
                    {
                        CkExpenseId = entity.CkExpenseId,
                        AccountId = entity.AccountId,
                        CkExpenseAmount = entity.CkExpenseAmount,
                        CkExpenseName = entity.CkExpenseName,
                        CkDueDate = entity.CkDueDate
                    };
            }
        }
        public bool UpdateCkExpense(CkExpenseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CkExpenses
                        .Single(e => e.CkExpenseId == model.CkExpenseId);

                entity.CkExpenseAmount = model.CkExpenseAmount;
                entity.CkExpenseName = model.CkExpenseName;
                entity.CkDueDate = model.CkDueDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCkExpense(int ckExpenseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CkExpenses
                        .Single(e => e.CkExpenseId == ckExpenseId);

                ctx.CkExpenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
