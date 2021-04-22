using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models.RetirementAcct;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                    
                    AccountId = model.AccountId,
                    UserAcctNumber = model.UserAcctNumber,
                    AcctType = model.AcctType,
                    RtAcctBalance = model.RtAcctBalance

                };
            using (var ctx = new ApplicationDbContext())
            {

                {
                    ctx.RetirementAccts.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            } 
        }


        public IEnumerable<RetirementAcctList> GetRetirementAcct()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RetirementAccts
                    .Where(e => e.AccountId == e.AccountId)
                    .Select(
                        e => new RetirementAcctList
                        {
                            UserAcctNumber = e.UserAcctNumber,
                            RtAcctNumber = e.RtAcctNumber,
                            AcctType = e.AcctType,
                            RtAcctBalance = e.RtAcctBalance,

                        }
                        );
                return query.ToArray();
            }
        }


    }
}
