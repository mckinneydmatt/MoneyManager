using MoneyManager.Services;
using MoneyManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoneyManager.Data;

namespace MoneyManager.Controllers
{
    public class SavingsAcctController : ApiController
    {
        public IHttpActionResult Get()
        {
            SavingsAcctService savingsAcctService = CreateSavingsAcctService();
            var savingsAcct = savingsAcctService.GetSavingsAcct();
            return Ok(savingsAcct);
        }

        public IHttpActionResult Get(int UserAccountNumber)
        {
            SavingsAcctService savingsAcctService = CreateSavingsAcctService();
            var savingsAcct = savingsAcctService.GetSavingsAcctByAcctNumber(UserAccountNumber);
            return Ok(savingsAcct);
        }


        public IHttpActionResult Post(SavingsAcctCreate savingsAcct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSavingsAcctService();

            if (!service.CreateSavingsAcct(savingsAcct))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SavingsAcctEdit savingsAcct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSavingsAcctService();

            if (!service.UpdateSavingsAcct(savingsAcct))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int UserAccountNumber)
        {
            var service = CreateSavingsAcctService();

            if (!service.DeleteSavingsAcct(UserAccountNumber))
                return InternalServerError();

            return Ok();
        }

        private SavingsAcctService CreateSavingsAcctService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var savingsAcctService = new SavingsAcctService(userId);
            return savingsAcctService;
        }
    }
}
