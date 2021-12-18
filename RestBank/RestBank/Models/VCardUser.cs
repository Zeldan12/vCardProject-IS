using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestBank.Models
{
    public class VCardUser
    {
        public int bankId { get; set; }
        public string password { get; set; }
        public string bankPassword { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string photoURL { get; set; }
        public int confirmationCode { get; set; }
        public int phoneNumber { get; set; }
        public string bankUserID { get; set; }
        public string bankUrl { get; set; }
    }
}