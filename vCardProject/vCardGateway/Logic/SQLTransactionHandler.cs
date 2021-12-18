using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vCardGateway.Models;

namespace vCardGateway.Logic
{
    public class SQLTransactionHandler
    {
        string connectionString = Properties.Settings.Default.ConnStr;

        public IEnumerable<Transaction> getAllTransactions()
        {
            SqlConnection connection = null;
            List<Transaction> lista = new List<Transaction>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, vCardNumber, transactionAcomplice, date, paymentType, pairTransaction, value, oldValue, newValue, description, transactionType FROM [Transaction]";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string sql2 = "SELECT name FROM PAYMENTTYPE WHERE Id = @id";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", (int)reader["pairTransaction"]);
                    SqlDataReader reader2 = command.ExecuteReader();


                    Transaction b = new Transaction
                    {
                        id = (int)reader["Id"],
                        vCardNumber = (int)reader["vCardNumber"],
                        transactionAcomplice = (string)reader["transactionAcomplice"],
                        date = (DateTime)reader["date"],
                        paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), (string)reader2["paymentType"]),
                        pairTransaction = (int)reader["pairTransaction"],
                        value = (int)reader["value"],
                        oldValue = (int)reader["oldValue"],
                        newValue = (int)reader["newValue"],
                        description = (int)reader["description"],
                        transactionType = (string)reader["transactionType"]
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

        public IEnumerable<Transaction> getAllTransactions(int vcard)
        {
            SqlConnection connection = null;
            List<Transaction> lista = new List<Transaction>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, vCardNumber, transactionAcomplice, date, paymentType, pairTransaction, value, oldValue, newValue, description, transactionType FROM [Transaction] WHERE vCardNumber = @vcard";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vcard", vcard);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    sql = "SELECT name FROM PAYMENTTYPE WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", (int)reader["pairTransaction"]);
                    SqlDataReader reader2 = command.ExecuteReader();


                    Transaction b = new Transaction
                    {
                        id = (int)reader["Id"],
                        vCardNumber = (int)reader["vCardNumber"],
                        transactionAcomplice = (string)reader["transactionAcomplice"],
                        date = (DateTime)reader["date"],
                        paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), (string)reader2["paymentType"]),
                        pairTransaction = (int)reader["pairTransaction"],
                        value = (int)reader["value"],
                        oldValue = (int)reader["oldValue"],
                        newValue = (int)reader["newValue"],
                        description = (int)reader["description"],
                        transactionType = (string)reader["transactionType"]
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

        public Transaction getTransaction(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT Id, vCardNumber, transactionAcomplice, date, paymentType, pairTransaction, value, oldValue, newValue, description, transactionType FROM [Transaction] WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    sql = "SELECT name FROM PAYMENTTYPE WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", (int)reader["pairTransaction"]);
                    SqlDataReader reader2 = command.ExecuteReader();


                    Transaction b = new Transaction
                    {
                        id = (int)reader["Id"],
                        vCardNumber = (int)reader["vCardNumber"],
                        transactionAcomplice = (string)reader["transactionAcomplice"],
                        date = (DateTime)reader["date"],
                        paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), (string)reader2["paymentType"]),
                        pairTransaction = (int)reader["pairTransaction"],
                        value = (int)reader["value"],
                        oldValue = (int)reader["oldValue"],
                        newValue = (int)reader["newValue"],
                        description = (int)reader["description"],
                        transactionType = (string)reader["transactionType"]
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

        public bool createVcardTransactions(Transaction transaction, Transaction pair)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();


                string sql = "INSERT INTO [TRANSACTION](VCARDNUMBER, TRANSACTIONACOMPLICE, DATE, PAYMENTTYPE, VALUE, OLDVALUE, NEWVALUE, TRANSACTIONTYPE) output INSERTED.ID " +
                    "VALUES (@vCardNumber, @transactionAcomplice, @date, @paymentType, @value, @oldValue, @newValue,@transactionType)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vCardNumber", transaction.vCardNumber);
                command.Parameters.AddWithValue("@transactionAcomplice", transaction.transactionAcomplice);
                command.Parameters.AddWithValue("@date", transaction.date);
                command.Parameters.AddWithValue("@paymentType", transaction.paymentType);
                command.Parameters.AddWithValue("@value", transaction.value);
                command.Parameters.AddWithValue("@oldValue", transaction.oldValue);
                command.Parameters.AddWithValue("@newValue", transaction.newValue);
                command.Parameters.AddWithValue("@transactionType", transaction.transactionType);
                int modified = (int)command.ExecuteScalar();

                sql = "INSERT INTO [TRANSACTION](VCARDNUMBER, TRANSACTIONACOMPLICE, DATE, PAYMENTTYPE, PAIRTRANSACTION, VALUE, OLDVALUE, NEWVALUE, TRANSACTIONTYPE) output INSERTED.ID VALUES " +
                    "(@vCardNumber, @transactionAcomplice, @date, @paymentType,@pairTransaction, @value, @oldValue, @newValue,@transactionType)";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vCardNumber", pair.vCardNumber);
                command.Parameters.AddWithValue("@transactionAcomplice", pair.transactionAcomplice);
                command.Parameters.AddWithValue("@date", pair.date);
                command.Parameters.AddWithValue("@paymentType", pair.paymentType);
                command.Parameters.AddWithValue("@pairTransaction", modified);
                command.Parameters.AddWithValue("@value", pair.value);
                command.Parameters.AddWithValue("@oldValue", pair.oldValue);
                command.Parameters.AddWithValue("@newValue", pair.newValue);
                command.Parameters.AddWithValue("@transactionType", pair.transactionType);
                int modified2 = (int)command.ExecuteScalar();

                sql = "UPDATE [TRANSACTION] SET pairTransaction = @pair WHERE Id = @id";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@pair", modified2);
                command.Parameters.AddWithValue("@id",modified);
                int numRegistos = command.ExecuteNonQuery();

                if (modified != 0 && modified2 != 0 && numRegistos > 0)
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

        public bool updateTransaction(int id, string description)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();


                string sql = "UPDATE [TRANSACTION] SET Description = @description WHERE Id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@id", id);
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

    }
}