using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vCardGateway.Models
{
    public class VCard
    {
        //public int id { get; set; }
        public int phoneNumber { get; set; }
        public float balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int ownerId { get; set; }
        public float maximumLimit { get; set; }
    }
}