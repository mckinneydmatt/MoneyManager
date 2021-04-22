using MoneyManager.Data;
using MoneyManager.Data.Entities;
using MoneyManager.Models;
using MoneyManager.Models.Checking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
   public class CheckingAcctService
    {
        private readonly Guid _userId;

        public CheckingAcctService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCheckingAcct(CheckingAcctCreate model)
        {
            var entity = new CheckingAcct()
            {
                AccountId = model.AccountId,

                UserAcctNumber = model.UserAcctNumber,

                CkAcctName = model.CkAcctName,

                CkAcctBalance = model.CkAcctBalance
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CheckingAccts.Add(entity);
                return ctx.SaveChanges() == 1;

            }

        }

        public IEnumerable<CheckingAcctListItem> GetCheckingAcct()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx

                        .CheckingAccts
                        .Where(e => e.AccountId == e.AccountId)
                        .Select(
                            e =>
                                new CheckingAcctListItem
                                {


                                    AccountId = e.AccountId,

                                    UserAcctNumber = e.UserAcctNumber,

                                    CkAcctName = e.CkAcctName,

                                    CkAcctBalance = e.CkAcctBalance

                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCheckingAcct(CheckingAcctEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                       .CheckingAccts
                        .Single(e => e.UserAcctNumber == model.UserAcctNumber);

                //entity.AccountId = model.AccountId;

                entity.UserAcctNumber = model.UserAcctNumber;

                entity.CkAcctName = model.CkAcctName;

                entity.CkAcctBalance = model.CkAcctBalance;

                return ctx.SaveChanges() == 1;
            }
        }

        public CheckingAcctDetail GetCheckingAcctByAcctNumber(int UserAccountNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                        .CheckingAccts
                        .Single
                        (e => e.UserAcctNumber == UserAccountNumber);

                return
                    new CheckingAcctDetail
                    {
                        AccountId = entity.AccountId,

                        UserAcctNumber = entity.UserAcctNumber,

                        CkAcctName = entity.CkAcctName,

                        CkAcctBalance = entity.CkAcctBalance


                    };
            }
        }

        public bool DeleteCheckingAcct(int UserAcctNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                        .CheckingAccts
                        .Single(e => e.UserAcctNumber == UserAcctNumber);

                ctx.CheckingAccts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }


        }
    }
}
