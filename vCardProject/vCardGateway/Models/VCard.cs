using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vCardGateway.Models
{
    public class VCard
    {
        public int phoneNumber { get; set; }
        public float balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int ownerId { get; set; }
        public float maximumLimit { get; set; }

        public bool checkPhoneNumber()
        {
            if (999999999 <= phoneNumber || phoneNumber > 900000000)
            {
                return true;
            }
            return false;
        }
    }
}