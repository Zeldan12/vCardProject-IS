using RestBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Web.Http;

namespace RestBank.Controllers
{
    public class UserController : ApiController
    {
        string connectionString = Properties.Settings.Default.ConnStr;

        // GET: api/users
        [Route("api/users")]
        public IEnumerable<User> GetAllUsers()
        {
            List<User> listaUsers = new List<User>();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sql = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User u = new User
                    {
                        Id = (int)reader["Id"],
                        Password = (string)reader["Password"],
                        Balance = reader["Balance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Balance"])
                    };

                    listaUsers.Add(u);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return listaUsers;
        }
    
        // GET: api/users/1
        [Route("api/users/{id:int}")]
        public IHttpActionResult GetUserById(int id)
        {
            User user = null;
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sql = "SELECT * FROM Users WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    User u = new User
                    {
                        Id = (int)reader["Id"],
                        Password = (string)reader["Password"],
                        Balance = reader["Balance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Balance"])
                    };
                }

                reader.Close();
                connection.Close();

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return InternalServerError();
            }
        }

        // POST: api/users
        [Route("api/users")]
        public IHttpActionResult PostUser([FromBody] User value)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sql = "INSERT INTO Users VALUES (@password, @balance)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@password", value.Password);
                command.Parameters.AddWithValue("@balance", value.Balance);
                int numRegistos = command.ExecuteNonQuery();

                connection.Close();

                if (numRegistos > 0)
                {
                    return Ok(value);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                return InternalServerError();
            }
        }

        // PUT: api/users/1
        [Route("api/users/{id:int}")]
        public IHttpActionResult PutUser(int id, [FromBody] User value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Users SET Password=@password, Balance=@balance WHERE Id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@passsword", value.Password);
                        command.Parameters.AddWithValue("@balance", value.Balance);
                        command.Parameters.AddWithValue("@id", id);

                        int numRegistos = command.ExecuteNonQuery();
                        if (numRegistos == 1)
                            return Ok(value);
                        else
                            return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/users/1
        [Route("api/users/{id:int}")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Users WHERE Id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int numRegistos = command.ExecuteNonQuery();
                        if (numRegistos == 1)
                            return Ok();
                        else
                            return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}