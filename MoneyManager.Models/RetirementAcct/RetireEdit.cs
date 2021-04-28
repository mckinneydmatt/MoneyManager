using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MoneyManager.Models.RetirementAcct
{
    public class RetireEdit
    {
        public decimal RtAcctBalance { get; set; }
        public string AcctType { get; set; }
        [Key]
        public int AccountId { get; set; }
        public string RtAcctNumber { get; set; }
        public int UserAcctNumber { get; set; }
    }
}