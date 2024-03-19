using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Tutorial4
{
    internal class DBAccess
    {
        public static SqlConnection connection = new SqlConnection();
        private static SqlCommand command = new SqlCommand();
        private static SqlDataReader DbReader;
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        public SqlTransaction Tutorial04;
        private static string strConnString = "Data Source=.\\sqlexpress01;Initial Catalog=Tutorial04;Integrated Security=True;";
        
        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                   // MessageBox.Show("ok");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(""+ex.Message);
                throw ex;
            }
        }

        public void closeConn()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Close();
                    //MessageBox.Show("ok");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(""+ex.Message);
                throw ex;
            }
        }


        public void readDatathroughAdapter(string query, DataTable tb1Name)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                adapter = new SqlDataAdapter(command);
                adapter.Fill(tb1Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SqlDataAdapter readDatathroughAdapter(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                adapter = new SqlDataAdapter(command);
                return adapter; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader readDatathroughReader(string query)
        {
            SqlDataReader reader;
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int executeQuery(SqlCommand dbCommand)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }
                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;
                return dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExecuteScalar(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
