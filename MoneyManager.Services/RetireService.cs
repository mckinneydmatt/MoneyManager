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
    public class RetireService
    {
        public bool CreateRetireAcct(RetireCreate model)
        {
            var entity =
                new RetirementAcct()
                {
                    RtAcctNumber = model.RtAcctNumber,
                    RtAcctBalance = model.RtAcctBalance,
                    AcctType = model.AcctType,
                    UserAcctNumber =  model.UserAcctNumber

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RetirementAccts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
