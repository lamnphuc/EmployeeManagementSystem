using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TL;

namespace DL
{
    public class PrintData
    {
        private DataProvider dataProvider;

        public PrintData()
        {
            dataProvider = new DataProvider();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection connection = dataProvider.OpenConnection();

            string query = "SELECT FullName, Gender, Position, Salary, Phone, Email, HireDate, Status FROM Employees";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            FullName = reader["FullName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Position = reader["Position"].ToString(),
                            Salary = (int)reader["Salary"],
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            HireDate = (DateTime)reader["HireDate"],
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            dataProvider.CloseConnection(connection); // Đóng kết nối sau khi truy xuất xong
            return employees;
        }
    }
}
