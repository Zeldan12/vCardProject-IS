using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using vCardGateway.Models;

namespace vCardGateway.Logic
{
    public class SQLUsersHandler
    {
        string connectionString = Properties.Settings.Default.ConnStr;

        public IEnumerable<User> getAllUsers()
        {
            SqlConnection connection = null;
            List<User> lista = new List<User>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, PhoneNumber, Bank, Name, Email, PhotoURL, Type, BankUserID, Active FROM USERS";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    User u = new User
                    {
                        id = (int)reader["Id"],
                        phoneNumber = (int)reader["PhoneNumber"],
                        bankId = (int)reader["Bank"],
                        name = ((string)reader["Name"]).Trim(),
                        email = ((string)reader["Email"]).Trim(),
                        photoURL = reader["PhotoURL"] == System.DBNull.Value ? "" : ((string)reader["PhotoURL"]).Trim(),
                        type = ((string)reader["Type"]).Trim(),
                        bankUserID = (string)reader["BankUserID"],
                        active = (bool)reader["Active"]
                    };
                    lista.Add(u);
                }

                reader.Close();

            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }

            return lista;
        }

        public User getUser(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, PhoneNumber, Bank, Name, Email, PhotoURL, Type, BankUserID, Active FROM USERS WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SQLVCardsHandler handler = new SQLVCardsHandler();

                    User u = new User
                    {
                        id = (int)reader["Id"],
                        phoneNumber = (int)reader["PhoneNumber"],
                        bankId = (int)reader["Bank"],
                        name = ((string)reader["Name"]).Trim(),
                        email = ((string)reader["Email"]).Trim(),
                        photoURL = reader["PhotoURL"] == System.DBNull.Value ? "" : ((string)reader["PhotoURL"]).Trim(),
                        type = ((string)reader["Type"]).Trim(),
                        bankUserID = (string)reader["BankUserID"],
                        active = (bool)reader["Active"],
                         vCards = handler.getAllVCards(id).ToList()
                    };  
                    return u;

                }

                return null;
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool createUser(User user)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(user.password);
                    byte[] hashValue = mySHA256.ComputeHash(bytes);
                    string encryptedPass = Encoding.UTF8.GetString(bytes);

                    byte[] bytes2 = Encoding.UTF8.GetBytes(user.confirmationCode.ToString());
                    byte[] hashValue2 = mySHA256.ComputeHash(bytes);
                    string encryptedCode = Convert.ToBase64String(hashValue);

                    string sql = "INSERT INTO USERS VALUES (@name, @password, @email, @photourl, @confirmationcode, @phonenumber, @bankuserid, @bank, @usertype, @active)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", user.name);
                    command.Parameters.AddWithValue("@password", encryptedPass);
                    command.Parameters.AddWithValue("@email", user.email);
                    command.Parameters.AddWithValue("@photourl", user.photoURL == null ? "" : user.photoURL);
                    command.Parameters.AddWithValue("@confirmationcode", encryptedCode);
                    command.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                    command.Parameters.AddWithValue("@bankuserid", user.bankUserID);
                    command.Parameters.AddWithValue("@bank", user.bankId);
                    command.Parameters.AddWithValue("@usertype", user.type);
                    command.Parameters.AddWithValue("@active", true);
                    int numRegistos = command.ExecuteNonQuery();

                    if (numRegistos > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool updateUser(User user)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();


                string sql = "UPDATE USERS SET Name = @name, Email = @email, PhotoURL = @photourl, Type = @usertype, Active = @active WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@photourl", user.photoURL);
                command.Parameters.AddWithValue("@usertype", user.type);
                command.Parameters.AddWithValue("@active", user.active);
                command.Parameters.AddWithValue("@id", user.id);
                int numRegistos = command.ExecuteNonQuery();

                if (numRegistos > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool updateUserPassword(string newPassword, int user)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(newPassword);
                    byte[] hashValue = mySHA256.ComputeHash(bytes);
                    string encryptedPass = Convert.ToBase64String(hashValue);


                    string sql = "UPDATE USERS SET Password = @password WHERE Id = @id";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@password", encryptedPass);
                    command.Parameters.AddWithValue("@id", user);
                    int numRegistos = command.ExecuteNonQuery();

                
                    if (numRegistos > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool updateUserCode(int newCode, int user)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(newCode.ToString());
                    byte[] hashValue = mySHA256.ComputeHash(bytes);
                    string encryptedCode = Convert.ToBase64String(hashValue);

                    string sql = "UPDATE USERS SET ConfirmationCode = @confirmationcode WHERE Id = @id";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@confirmationcode", encryptedCode);
                    command.Parameters.AddWithValue("@id", user);
                    int numRegistos = command.ExecuteNonQuery();

                    if (numRegistos > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool deleteUser(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "DELETE FROM Users WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                int numRegistos = command.ExecuteNonQuery();

                connection.Close();

                if (numRegistos > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
        }

        public User authenticate(string username, string password)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT id, Password, Type, Active FROM USERS WHERE email = @username OR CAST(phoneNumber as varchar(10)) = @username";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    using (SHA256 mySHA256 = SHA256.Create())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(password);
                        byte[] hashValue = mySHA256.ComputeHash(bytes);
                        string encryptedPass = Convert.ToBase64String(hashValue);

                        if ((string)reader["Password"] == encryptedPass)
                        {
                            return new User
                            {
                                id = (int)reader["id"],
                                name = username,
                                type = ((string)reader["Type"]).Trim(),
                                active = (bool)reader["Active"]

                            };
                        }
                    }
                }
                return null;

            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }

        public bool verifyCode(string username, int code)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT ConfirmationCode FROM USERS WHERE email = @username OR CAST(phoneNumber as varchar(10)) = @username";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    using (SHA256 mySHA256 = SHA256.Create())
                    {
                        
                        byte[] bytes = Encoding.UTF8.GetBytes(code.ToString());
                        byte[] hashValue = mySHA256.ComputeHash(bytes);
                        string encryptedCode = Convert.ToBase64String(hashValue);

                        if ((string)reader["ConfirmationCode"] == encryptedCode)
                        {
                            return true;
                        }
                    }
                }
                return false;

            }
            catch (Exception e)
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                throw new Exception(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }
    }
}