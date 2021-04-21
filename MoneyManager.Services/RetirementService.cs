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
                    UserID = _userId,
                    AccountId = model.AccountId,
                    AcctType = model.AcctType,
                    RtAcctBalance = model.RtAcctBalance

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RetirementAccts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<RetirementAcctList> GetRetirementAcctLists()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .RetirementAccts
        //            .Where(e => e.AccountId == _accountId)
        //            .select(
        //                e =>
        //                {
        //                    RtAccountBalance = e.
        //                }
        //                );
        //    }
        //}
    }
}
