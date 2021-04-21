using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
using MoneyManager.Models.Savings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class SavingsAcctService
    {

        private readonly Guid _userId;

        public SavingsAcctService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSavingsAcct(SavingsAcctCreate model)
        {
            var entity = new SavingsAcct()
            {
                AccountId = model.AccountId,

                UserAccountNumber = model.UserAccountNumber,

                SvAcctName = model.SvAcctName,

                SvAcctBalance = model.SvAcctBalance
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SavingsAccts.Add(entity);
                return ctx.SaveChanges() == 1;

            }

        }

        public IEnumerable<SavingsAcctListItem> GetSavingsAcct()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .SavingsAccts
                        .Where(e => e.AccountId == e.AccountId)
                        .Select(
                            e =>
                                new SavingsAcctListItem
                                {


                                    AccountId = e.AccountId,

                                    UserAccountNumber = e.UserAccountNumber,

                                    SvAcctName = e.SvAcctName,

                                    SvAcctBalance = e.SvAcctBalance

                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateSavingsAcct(SavingsAcctEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      
                       .SavingsAccts
                        .Single(e => e.AccountId == model.AccountId);

                                    entity.AccountId = model.AccountId;

                                    entity.UserAccountNumber = model.UserAccountNumber;

                                    entity.SvAcctName = model.SvAcctName;

                                    entity.SvAcctBalance = model.SvAcctBalance;

                return ctx.SaveChanges() == 1;
            }
        }

        public SavingsAcctDetail GetSavingsAcctByAcctNumber(int UserAccountNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        
                        .SavingsAccts
                        .Single
                        (e => e.UserAccountNumber == UserAccountNumber);
                
                return
                    new SavingsAcctDetail
                    { 
                        AccountId = entity.AccountId,

                        UserAccountNumber = entity.UserAccountNumber,

                        SvAcctName = entity.SvAcctName,

                        SvAcctBalance = entity.SvAcctBalance


                    };
            }
        }

        public bool DeleteSavingsAcct(int UserAccountNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        
                        .SavingsAccts
                        .Single(e => e.UserAccountNumber == UserAccountNumber);

                ctx.SavingsAccts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }
    }
}
