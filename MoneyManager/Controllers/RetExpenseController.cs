using MoneyManager.Models.Expense;
using MoneyManager.Models.RetExpense;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class RetExpenseController : ApiController
    {
        private RetExpenseService CreateRetExpenseService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var retExpenseService = new RetExpenseService(/*userId*/);
            return retExpenseService;
        }

        public IHttpActionResult Get()
        {
            RetExpenseService retExpenseService = CreateRetExpenseService();
            var retExpenses = retExpenseService.GetRetExpenses();
            return Ok(retExpenses);
        }

        public IHttpActionResult Post(RetExpenseCreate retExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetExpenseService();

            if (!service.CreateExpense(retExpense))
                return InternalServerError();

            return Ok();

        }
        public IHttpActionResult Get(int id)
        {
            RetExpenseService retExpenseService = CreateRetExpenseService();
            var retExpense = retExpenseService.GetRetExpenseById(id);
            return Ok(retExpense);
        }
        public IHttpActionResult Put(RetExpenseEdit retExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetExpenseService();

            if (!service.UpdateRetExpense(retExpense))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRetExpenseService();

            if (!service.DeleteRetExpense(id))
                return InternalServerError();

            return Ok();
        }
    }
}
