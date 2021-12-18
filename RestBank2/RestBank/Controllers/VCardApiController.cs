using RestBank.Models;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestBank.Controllers
{
    public class VCardApiController : ApiController
    {
        private object textBoxUsername;

        [HttpPost]
        [Route("api/users/{email}/vcard")]
        public IHttpActionResult CreateVCardUser(string email, [FromBody] VCardUser info)
        {
            if (info.bankPassword == null || info.confirmationCode == 0 || info.password == null || info.phoneNumber == 0)
            {
                return BadRequest();
            }

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Properties.Settings.Default.ConnStr);
                connection.Open();
                string sql = "SELECT Name, Password FROM Users WHERE Email = @email";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                        if ((string)reader["Password"] == info.bankPassword)
                        {
                            info.bankUserID = email;
                            info.email = email;
                            info.bankPassword = null;
                            info.name = (string)reader["Name"];
                            info.bankUrl = "http://localhost:53173/";

                            RestSharp.RestClient client;

                            client = new RestSharp.RestClient(@"http://localhost:57975/");
                            var request = new RestSharp.RestRequest("api/users", RestSharp.Method.POST);
                            request.AddJsonBody(info);
                            connection.Close();
                            return Ok();
                         }
                    
                }
                return Unauthorized();

            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }

        }
    }
}
