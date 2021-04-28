using MoneyManager.Models.Expense;
using MoneyManager.Models.CkExpense;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class CkExpenseController : ApiController
    {
        private CkExpenseService CreateCkExpenseService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var ckExpenseService = new CkExpenseService(/*userId*/);
            return ckExpenseService;
        }

        public IHttpActionResult Get()
        {
            CkExpenseService ckExpenseService = CreateCkExpenseService();
            var ckExpenses = ckExpenseService.GetCkExpenses();
            return Ok(ckExpenses);
        }

        public IHttpActionResult Post(CkExpenseCreate ckExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCkExpenseService();

            if (!service.CreateExpense(ckExpense))
                return InternalServerError();

            return Ok();

        }
        public IHttpActionResult Get(int id)
        {
            CkExpenseService ckExpenseService = CreateCkExpenseService();
            var ckExpense = ckExpenseService.GetCkExpenseById(id);
            return Ok(ckExpense);
        }
        public IHttpActionResult Put(CkExpenseEdit ckExpense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCkExpenseService();

            if (!service.UpdateCkExpense(ckExpense))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCkExpenseService();

            if (!service.DeleteCkExpense(id))
                return InternalServerError();

            return Ok();
        }
    }
}
