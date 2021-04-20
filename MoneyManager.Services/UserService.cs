﻿using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
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
                    UserID = _userId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    GoalAmount = model.GoalAmount,
                    LiquidNetWorth = model.LiquidNetWorth,
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
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new UserList
                                {
                                    UserAcctNumber = e.UserAcctNumber,
                                    Name = e.Name,
                                    PhoneNumber = e.PhoneNumber,
                                    Address = e.Address,
                                    GoalAmount = e.GoalAmount,
                                    LiquidNetWorth = e.LiquidNetWorth
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
    