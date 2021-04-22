using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.RetirementAcct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class RetirementService
    {
        private readonly Guid _userId;
        public RetirementService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRetirement(RetireCreate model)
        {
            var entity =
                new RetirementAcct()
                {
                    //UserID = _userId,
                    AccountId = model.AccountId,
                    AcctType = model.AcctType,
                    RtAcctBalance = model.RtAcctBalance,
                    RtAcctNumber = model.RtAcctNumber,
                    UserAcctNumber = model.UserAcctNumber


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RetirementAccts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RetirementAcctList> GetRetirementAcctLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RetirementAccts
                    .Where(e => e.AccountId == e.AccountId)
                    .Select(
                        e =>
                        new RetirementAcctList
                        {
                            RtAcctBalance = e.RtAcctBalance,
                            AcctType = e.AcctType,
                            AccountId = e.AccountId,
                            RtAcctNumber = e.RtAcctNumber,
                            UserAcctNumber = e.UserAcctNumber
                        }
                        );
                return query.ToArray();
            }
        }

        public bool EditRetirementAccount(RetireEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RetirementAccts
                    .Single(e => e.AccountId == model.AccountId);
                entity.AccountId = model.AccountId;
                entity.RtAcctBalance = model.RtAcctBalance;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRetirementAcct(int userAccountNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RetirementAccts.Single(e => e.AccountId == userAccountNumber );

                ctx.RetirementAccts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
