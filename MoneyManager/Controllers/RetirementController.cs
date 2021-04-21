using Microsoft.AspNet.Identity;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
using MoneyManager.Models.RetirementAcct;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class RetirementController : ApiController
    {

        private RetirementService CreateRetirement()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var retirementService = new RetirementService(userId);
            return retirementService;
        }

       public IHttpActionResult Post(RetireCreate retire)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetirement();

            if (!service.CreateRetirement(retire))
                return InternalServerError();

            return Ok();
        }

        //public IHttpActionResult Get()
        //{
        //    RetirementService retirementService = CreateRetirement();
        //    var retire = retirementService.
        //}
    }
}
