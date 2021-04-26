using MoneyManager.Models.Expense;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class ExpenseController : ApiController
    {
        private ExpenseService CreateExpenseService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var expenseService = new ExpenseService(/*userId*/);
            return expenseService;
        }

        public IHttpActionResult Post(ExpenseCreate expense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateExpenseService();

            if (!service.CreateExpense(expense))
                return InternalServerError();

            return Ok();

        }
    }
}
