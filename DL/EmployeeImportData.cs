using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TL;

namespace DL
{
    public class EmployeeImportData
    {
        private readonly DataProvider _dataProvider;

        public EmployeeImportData()
        {
            _dataProvider = new DataProvider();
        }

        public void InsertEmployees(List<Employee> employees)
        {
            using (var connection = _dataProvider.OpenConnection())
            {
                foreach (var employee in employees)
                {
                    using (var command = new SqlCommand("INSERT INTO Employees (FullName, Gender, Position, Salary, Phone, Email, HireDate, Status) VALUES (@FullName, @Gender, @Position, @Salary, @Phone, @Email, @HireDate, @Status)", connection))
                    {
                        command.Parameters.AddWithValue("@FullName", employee.FullName);
                        command.Parameters.AddWithValue("@Gender", employee.Gender);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        command.Parameters.AddWithValue("@Phone", employee.Phone);
                        command.Parameters.AddWithValue("@Email", employee.Email);
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        command.Parameters.AddWithValue("@Status", employee.Status);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
