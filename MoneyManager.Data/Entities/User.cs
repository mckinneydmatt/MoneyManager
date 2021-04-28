using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Data.Entities
{
    public class User 
    {
        [Key]
        public int UserAcctNumber { get; set; }

        [Required]

        public Guid UserId { get; set; }
        // [Required]
        public string Name { get; set; }
       // [Required]
        public string PhoneNumber { get; set; }
       // [Required]
=
        public Guid UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]

        public string Address { get; set; }

        public double GoalAmount { get; set; }

        


        public double LiquidNetWorth { get; set; }

    }
}

