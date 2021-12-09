using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vCardGateway.Models
{
    public class Transaction
    {

        public int id { get; set; }
        public int vCardNumber { get; set; }
        public DateTime date { get; set; }
        public TransactionType transactioType { get; set; }
        public PaymentType paymentType { get; set; }
        public Transaction pairTransaction { get; set; }
        public float value { get; set; }
        public float oldValue { get; set; }
        public float newValue { get; set; }
        public float description { get; set; }
        public BankEntity bank { get; set; }

    }
}