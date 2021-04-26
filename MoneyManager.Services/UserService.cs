using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
using MoneyManager.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    UserAcctNumber = model.UserAcctNumber,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    GoalAmount = model.GoalAmount,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserList> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new UserList
                                {
                                    UserAcctNumber = e.UserAcctNumber,
                                    Name = e.Name,
                                    PhoneNumber = e.PhoneNumber,
                                    Address = e.Address,
                                    GoalAmount = e.GoalAmount,

                                }
                        );

                return query.ToArray();
            }
        }
        public UserDetail GetUserByAcctNum(int acctNum)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserAcctNumber == acctNum && e.UserID == _userId);
                return
                    new UserDetail
                    {
                        UserAcctNumber = entity.UserAcctNumber,
                        Name = entity.Name,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        GoalAmount = entity.GoalAmount,
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserAcctNumber == model.UserAcctNumber && e.UserID == _userId);

                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;
                entity.GoalAmount = model.GoalAmount;

                return ctx.SaveChanges() == 1;
            }
        }
        public UserDetail GetUserByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Name == name && e.UserID == _userId);
                return
                    new UserDetail
                    {
                        UserAcctNumber = entity.UserAcctNumber,
                        Name = entity.Name,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        GoalAmount = entity.GoalAmount,
                    };
            }
        }
        public bool DeleteUser(int acctNum)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserAcctNumber == acctNum && e.UserID == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
    
