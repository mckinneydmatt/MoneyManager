using Microsoft.AspNet.Identity;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
using MoneyManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyManager.Controllers
{
    public class CheckingAcctController : ApiController
    {
        public IHttpActionResult Get()
        {
            CheckingAcctService checkingAcctService = CreateCheckingAcctService();
            var checkingAcct = checkingAcctService.GetCheckingAcct();
            return Ok(checkingAcct);
        }

        public IHttpActionResult Get(int UserAccountNumber)
        {
            CheckingAcctService checkingAcctService = CreateCheckingAcctService();
            var checkingAcct = checkingAcctService.GetCheckingAcctByAcctNumber(UserAccountNumber);
            return Ok(checkingAcct);
        }


        public IHttpActionResult Post(CheckingAcctCreate checkingAcct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCheckingAcctService();

            if (!service.CreateCheckingAcct(checkingAcct))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CheckingAcctEdit checkingAcct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCheckingAcctService();

            if (!service.UpdateCheckingAcct(checkingAcct))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int UserAccountNumber)
        {
            var service = CreateCheckingAcctService();

            if (!service.DeleteCheckingAcct(UserAccountNumber))
                return InternalServerError();

            return Ok();
        }

        private CheckingAcctService CreateCheckingAcctService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var checkingAcctService = new CheckingAcctService(userId);
            return checkingAcctService;
        }
    }
}
