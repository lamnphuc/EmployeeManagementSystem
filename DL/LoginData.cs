using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DL
{
    public class LoginData
    {
        private readonly DataProvider _dataProvider;

        public LoginData()
        {
            _dataProvider = new DataProvider();
        }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="employeeName">Tên nhân viên nếu đăng nhập thành công</param>
        /// <returns>True nếu thông tin hợp lệ, False nếu không</returns>
        public (bool isSuccess, string employeeName, string message) VerifyCredentials(string username, string password)
        {
            var connection = _dataProvider.OpenConnection();
            try
            {
                string query = "SELECT Position, FullName FROM Employees WHERE EmployeeID = @EmployeeID AND Phone = @Phone";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", username);
                    command.Parameters.AddWithValue("@Phone", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string position = reader["Position"].ToString();
                            string fullName = reader["FullName"].ToString();

                            if (position.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                            {
                                return (true, fullName,"Đăng nhập thành công!"); // Đăng nhập thành công với quyền Manager
                            }
                            else
                            {
                                return (false, null, "Bạn không có quyền để đăng nhập."); // Không phải Manager
                            }
                        }
                        else
                        {
                            return (false, null, "Tên đăng nhập hoặc mật khẩu không hợp lệ."); // Sai thông tin đăng nhập
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra thông tin đăng nhập: {ex.Message}");
                return (false, null, "Lỗi khi kiểm tra thông tin đăng nhập.");
            }
            finally
            {
                _dataProvider.CloseConnection(connection);
            }
        }
    }
}
