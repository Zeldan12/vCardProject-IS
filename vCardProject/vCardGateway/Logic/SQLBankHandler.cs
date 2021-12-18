using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vCardGateway.Models;

namespace vCardGateway.Logic
{
    public class SQLBankHandler
    {
        string connectionString = Properties.Settings.Default.ConnStr;

        public IEnumerable<BankEntity> getAllBanks()
        {
            SqlConnection connection = null;
            List<BankEntity> lista = new List<BankEntity>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, Name, EarningPercentage, url FROM BankEntity";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    BankEntity b = new BankEntity
                    {
                        id = (int)reader["Id"],
                        name = (string)reader["Name"],
                        earningPercentage = (double)reader["EarningPercentage"],
                        url = (string)reader["url"]
                    };
                    lista.Add(b);
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

        public BankEntity getBank(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, Name, EarningPercentage, url FROM BankEntity WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    BankEntity b = new BankEntity
                    {
                        id = (int)reader["Id"],
                        name = (string)reader["Name"],
                        earningPercentage = (double)reader["EarningPercentage"],
                        url = (string)reader["url"]
                    };
                    return b;

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

        public BankEntity getBank(string url)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, Name, EarningPercentage, url FROM BankEntity WHERE url = @url";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@url", url);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    BankEntity b = new BankEntity
                    {
                        id = (int)reader["Id"],
                        name = (string)reader["Name"],
                        earningPercentage = (double)reader["EarningPercentage"],
                        url = (string)reader["url"]
                    };
                    return b;

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

        public bool createBank(BankEntity bank)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();


                string sql = "INSERT INTO BANKENTITY VALUES (@name, @url, @earningpercentage)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", bank.name);
                command.Parameters.AddWithValue("@url", bank.url);
                command.Parameters.AddWithValue("@earningpercentage", bank.earningPercentage);
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

        public bool updateBank(BankEntity bank)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();


                string sql = "UPDATE BANKENTITY SET Name = @name, url = @url, EarningPercentage = @earningPercentage" +
                    " WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", bank.name);
                command.Parameters.AddWithValue("@url", bank.url);
                command.Parameters.AddWithValue("@earningPercentage", bank.earningPercentage);
                command.Parameters.AddWithValue("@id", bank.id);
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

        public bool deleteBank(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "DELETE FROM BANKENTITY WHERE id = @id";
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