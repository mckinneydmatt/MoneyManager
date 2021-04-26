using Microsoft.AspNet.Identity;
using MoneyManager.Models;
using MoneyManager.Models.User;
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
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int acctNum)
        {
            UserService userService = CreateUserService();
            var user = userService.GetUserByAcctNum(acctNum);
            return Ok(user);
        }

        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id))
                return InternalServerError();

            return Ok();
        }

    }
}


