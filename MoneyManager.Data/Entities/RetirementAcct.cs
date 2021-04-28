using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class RetirementAcct
    {
        [Key]
        public int AccountId { get; set; }



      
        public Guid UserID { get; set; }


        [ForeignKey(nameof(User))]
        public int UserAcctNumber { get; set; }

        public virtual User User { get; set; }


       // [Required]
        public string RtAcctNumber { get; set; }


       //[Required]
        public decimal RtAcctBalance { get; set; }

       // [Required]

       
        public string RtAcctNumber { get; set; }

    
        public decimal RtAcctBalance { get; set; }

    

        public string AcctType { get; set; }

    }
}
