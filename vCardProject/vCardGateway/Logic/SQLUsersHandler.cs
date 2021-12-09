using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                string sql = "SELECT u.Id AS Id, PhoneNumber, Bank, u.Name AS Name, Email, PhotoURL, t.Name AS Type, BankUserID FROM USERS u JOIN UserType t ON u.UserTypeID = t.Id";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    User u = new User
                    {
                        id = (int)reader["Id"],
                        phoneNumber = (int)reader["PhoneNumber"],
                        bankId = (int)reader["Bank"],
                        name = (string)reader["Name"],
                        email = (string)reader["Email"],
                        photoURL = (string)reader["PhotoURL"],
                        type = (UserType)Enum.Parse(typeof(UserType), reader["Type"].ToString()),
                        bankUserID = (int)reader["BankUserID"],

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
                string sql = "SELECT u.Id AS Id, PhoneNumber, Bank, u.Name AS Name, Email, PhotoURL, t.Name AS Type, BankUserID FROM USERS u JOIN UserType t ON u.UserTypeID = t.Id WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    SQLVCardsHandler handler = new SQLVCardsHandler();

                    User u = new User
                    {
                        id = (int)reader["Id"],
                        phoneNumber = (int)reader["PhoneNumber"],
                        bankId = (int)reader["Bank"],
                        name = (string)reader["Name"],
                        email = (string)reader["Email"],
                        photoURL = (string)reader["PhotoURL"],
                        type = (UserType)Enum.Parse(typeof(UserType), reader["Type"].ToString()),
                        bankUserID = (int)reader["BankUserID"],
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
                string sql = "SELECT Name FROM UserType WHERE Name = @name";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", user.type.ToString());
                
                SqlDataReader reader = command.ExecuteReader();
                int usertypeid = 0;

                if (reader.Read())
                {
                    usertypeid = (int)reader["Id"];
                }
                else
                {
                    throw new Exception("User Type does not exist");
                }
                
                sql = "INSERT INTO USERS VALUES (@name, @password, @email, @photourl, @confirmationcode, @phonenumber, @bankuserid, @usertypeid, @bank)";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", user.name);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@emails", user.email);
                command.Parameters.AddWithValue("@photourl", user.photoURL);
                command.Parameters.AddWithValue("@confirmationcode", user.confirmationCode);
                command.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                command.Parameters.AddWithValue("@bankuserid", user.bankUserID);
                command.Parameters.AddWithValue("@usertypeid", usertypeid);
                command.Parameters.AddWithValue("@bank", user.bankId);
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
    }
}