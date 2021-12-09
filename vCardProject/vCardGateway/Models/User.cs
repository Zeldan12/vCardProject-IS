using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vCardGateway.Models
{
    public class User
    {
        public int id { get; set; }
        public int bankId { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string photoURL { get; set; }
        public int confirmationCode { get; set; } 
        public UserType type { get; set; }
        public List<VCard> vCards { get; set; }
        public int phoneNumber { get; set; }
        public int bankUserID { get; set; }
    }
}