using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DL;
using System.Xml.Linq;
using TL;

namespace DL
{
    public class DashboardData
    {
        private readonly DataProvider _dataProvider;

        public DashboardData()
        {
            _dataProvider = new DataProvider(); // Sử dụng lớp DataProvider để quản lý kết nối
        }

        public DashboardTranfer GetEmployeeStats()
        {
            DashboardTranfer stats = new DashboardTranfer();

            // Mở kết nối
            using (var connection = _dataProvider.OpenConnection())
            {
                string query = @"
                    SELECT
                        (SELECT COUNT(*) FROM Employees WHERE Position != 'Manager') AS TotalEmployees,
                        (SELECT COUNT(*) FROM Employees WHERE Status = 'Active'AND Position != 'Manager') AS ActiveEmployees,
                        (SELECT COUNT(*) FROM Employees WHERE Status = 'Not Active'AND Position != 'Manager') AS InactiveEmployees";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats.TotalEmployees = reader.GetInt32(0);     // Tổng số nhân viên
                            stats.ActiveEmployees = reader.GetInt32(1);    // Số nhân viên hoạt động
                            stats.InactiveEmployees = reader.GetInt32(2);  // Số nhân viên không hoạt động
                        }
                    }
                }
            }

            return stats;
        }

        public List<AddEmployeeTranfer> GetAllEmployees()
        {
            List<AddEmployeeTranfer> employees = new List<AddEmployeeTranfer>();

            using (var connection = _dataProvider.OpenConnection())
            {
                string query = "SELECT EmployeeId, FullName, Gender, Phone, Position, Email, Status, HireDate, Salary FROM Employees WHERE Position != 'Manager'"; // Trừ vị trí Manager

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new AddEmployeeTranfer
                            {
                                EmployeeId = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Position = reader.GetString(4),
                                Email = reader.GetString(5),
                                Status = reader.GetString(6),
                                HireDate = reader.GetDateTime(7),
                                Salary = reader.GetInt32(8)
                            });
                        }
                    }
                }
            }

            return employees;
        }
    }
}
