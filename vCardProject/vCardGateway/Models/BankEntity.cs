﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vCardGateway.Models
{
    public class BankEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public double earningPercentage { get; set; }
    }
}