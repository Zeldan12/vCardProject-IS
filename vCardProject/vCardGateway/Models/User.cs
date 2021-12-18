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
        public string type { get; set; }
        public List<VCard> vCards { get; set; }
        public int phoneNumber { get; set; }
        public string bankUserID { get; set; }
        public bool active { get; set; }
        public string bankUrl { get; set; }

        public bool checkPhoneNumber()
        {
            if (999999999 <= phoneNumber || phoneNumber > 900000000)
            {
                return true;
            }
            return false;
        }

        public bool checkPassword()
        {
            if (50 <= password.Length || password.Length > 4)
            {
                return true;
            }
            return false;
        }

        public bool checkConfirmationCode()
        {
            if (confirmationCode.ToString().Length == 4)
            {
                return true;
            }
            return false;
        }

        public bool checkName()
        {
            if (50 <= name.Length || name.Length > 3)
            {
                return true;
            }
            return false;
        }

        public bool checkEmail() //https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}