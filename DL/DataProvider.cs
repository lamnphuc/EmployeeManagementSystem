using System.Configuration;
using System;
using Microsoft.Data.SqlClient;

namespace DL
{
    public class DataProvider
    {
        public string connectionString;

        public DataProvider()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        }
        public SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                if (connection != null && connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open(); // Mở kết nối
                }
                return connection;
            }
            catch (Exception ex)
            {
                throw ex; // Đẩy lỗi lên cấp trên
            }
        }
        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Đóng kết nối
                }
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }
    }
}