using MoneyManager.Models.Expense;
using MoneyManager.Models.SavExpense;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class SavExpenseController : ApiController
    {
        private SavExpenseService CreateSavExpenseService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var savExpenseService = new SavExpenseService(/*userId*/);
            return savExpenseService;
        }

        public IHttpActionResult Post(SavExpenseCreate savExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSavExpenseService();

            if (!service.CreateExpense(savExpense))
                return InternalServerError();

            return Ok();

        }
        public IHttpActionResult Get(int id)
        {
            SavExpenseService savExpenseService = CreateSavExpenseService();
            var savExpense = savExpenseService.GetSavExpenseById(id);
            return Ok(savExpense);
        }
        public IHttpActionResult Put(SavExpenseEdit savExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSavExpenseService();

            if (!service.UpdateSavExpense(savExpense))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSavExpenseService();

            if (!service.DeleteSavExpense(id))
                return InternalServerError();

            return Ok();
        }
    }
}
