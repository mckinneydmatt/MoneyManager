using MoneyManager.Models.RetirementAcct;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class RetirementController : ApiController
    {
        private RetireService CreateRetireService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var retireService = new RetireService(/*userId*/);
            return retireService;
        }

        public IHttpActionResult Post(RetireCreate retirementAcct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetireService();

            if (!service.CreateRetireAcct(retirementAcct))
                return InternalServerError();

            return Ok();

        }
    }
}
