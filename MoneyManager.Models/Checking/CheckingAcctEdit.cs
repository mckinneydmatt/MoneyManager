﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
   public class CheckingAcctEdit
    {
        public int AccountId { get; set; }

        public int UserAcctNumber { get; set; }

        public string CkAcctName { get; set; }

        public decimal CkAcctBalance { get; set; }
    }
}
