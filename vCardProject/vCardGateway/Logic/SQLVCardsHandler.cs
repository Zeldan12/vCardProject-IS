using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using vCardGateway.Models;
namespace vCardGateway.Logic
{
    public class SQLVCardsHandler
    {
        string connectionString = Properties.Settings.Default.ConnStr;
        public VCard createVcard(int phoneNumber, int owner)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "INSERT INTO VCards VALUES (@phoneNumber, @balance, @owner)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@balance", 0);
                command.Parameters.AddWithValue("@owner", owner);
                int numRegistos = command.ExecuteNonQuery();

                sql = "SELECT Limit FROM MAXIMUMLIMIT WHERE Id = 1";
                command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new Exception("Server Error");
                }

                if (numRegistos > 0)
                {
                    return new VCard
                    {
                        phoneNumber = phoneNumber,
                        balance = 0,
                        ownerId = owner,
                        Transactions = new List<Transaction>(),
                        maximumLimit = (float)(double)reader["limit"]
                    };
                }
                else
                {
                    return null;
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
       
        public bool deleteVcard(int number)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "DELETE FROM VCards WHERE phoneNumber = @phoneNumber";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@phoneNumber", number);
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

        public VCard getVCard(int phoneNumber)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM VCARDS WHERE phoneNumber = @number";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@number", phoneNumber);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new VCard
                    {
                        phoneNumber = (int)reader["phoneNumber"],
                        balance = (float)(double)reader["balance"],
                        ownerId = (int)reader["owner"]
                    };
                        
                    
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

        public IEnumerable<VCard> getAllVCards()
        {
            SqlConnection connection = null;
            List<VCard> lista = new List<VCard>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM VCARDS";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    VCard v = new VCard
                    {
                        phoneNumber = (int)reader["phoneNumber"],
                        balance = (float)(double)reader["balance"],
                        ownerId = (int)reader["owner"]
                    };
                    lista.Add(v);
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

        public IEnumerable<VCard> getAllVCards(int user)
        {
            SqlConnection connection = null;
            List<VCard> lista = new List<VCard>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM VCARDS WHERE owner = @owner";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@owner", user);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VCard v = new VCard
                    {
                        phoneNumber = (int)reader["phoneNumber"],
                        balance = (float)(double)reader["balance"],
                        ownerId = (int)reader["owner"]
                    };
                    lista.Add(v);
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
    }
}