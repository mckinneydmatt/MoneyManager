using MoneyManager.Data.Entities;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class RetirementController : ApiController
    {
        private readonly MoneyManagerDbContext _context = new MoneyManagerDbContext();
        [HttpPost]

        public async Task<IHttpActionResult> CreateRetirementAccount([FromBody] RetirementAcct model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retireEntity = await _context.Users.FindAsync(model.UserAcctNumber);
            if (retireEntity is null)
                return BadRequest($"The target game with the ID of {model.UserAcctNumber} does not exist.");

            retireEntity.RetirementAcct.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok();
            return InternalServerError();
        }
    }
}
