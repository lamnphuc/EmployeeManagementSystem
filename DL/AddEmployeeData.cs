using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using Microsoft.Data.SqlClient;

namespace DL
{
    public class EmployeeData
    {
        private readonly DataProvider _dataProvider;

        public EmployeeData()
        {
            _dataProvider = new DataProvider();
        }

        public bool AddEmployee(AddEmployeeTranfer employee)
        {
            var connection = _dataProvider.OpenConnection();
            try
            {
                string query = @"
                INSERT INTO Employees (FullName, Gender, Phone, Position, Email, Status, HireDate, Salary)
                VALUES (@FullName, @Gender, @Phone, @Position, @Email, @Status, @HireDate, @Salary)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", employee.FullName);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Status", employee.Status);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}"); // Ghi lại thông báo lỗi
                throw; // Ném lỗi lên lớp Business
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}"); // Ghi lại thông báo lỗi
                throw; // Ném lỗi lên lớp Business
            }
            finally
            {
                _dataProvider.CloseConnection(connection);
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            var connection = _dataProvider.OpenConnection();

            try
            {
                // Kiểm tra vị trí của nhân viên
                string checkPositionQuery = "SELECT Position FROM Employees WHERE EmployeeId = @EmployeeId";
                using (var checkCommand = new SqlCommand(checkPositionQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    var position = checkCommand.ExecuteScalar()?.ToString();

                    // Nếu vị trí là Manager, không thực hiện xóa
                    if (position == "Manager")
                    {
                        return false;
                    }
                }

                // Xóa nhân viên nếu không phải Manager
                string deleteQuery = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                using (var deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            finally
            {
                _dataProvider.CloseConnection(connection);
            }
        }

        // Phương thức lấy vị trí của nhân viên
        public string GetEmployeePosition(int employeeId)
        {
            var connection = _dataProvider.OpenConnection();

            try
            {
                string query = "SELECT Position FROM Employees WHERE EmployeeId = @EmployeeId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    return command.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            finally
            {
                _dataProvider.CloseConnection(connection);
            }
        }
        public bool UpdateEmployeeDynamic(AddEmployeeTranfer employee)
        {
            var connection = _dataProvider.OpenConnection();
            try
            {
                // Xây dựng câu lệnh SQL động
                StringBuilder queryBuilder = new StringBuilder("UPDATE Employees SET ");
                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(employee.FullName))
                {
                    queryBuilder.Append("FullName = @FullName, ");
                    parameters.Add(new SqlParameter("@FullName", employee.FullName));
                }
                if (!string.IsNullOrEmpty(employee.Gender))
                {
                    queryBuilder.Append("Gender = @Gender, ");
                    parameters.Add(new SqlParameter("@Gender", employee.Gender));
                }
                if (!string.IsNullOrEmpty(employee.Phone))
                {
                    queryBuilder.Append("Phone = @Phone, ");
                    parameters.Add(new SqlParameter("@Phone", employee.Phone));
                }
                if (!string.IsNullOrEmpty(employee.Position))
                {
                    queryBuilder.Append("Position = @Position, ");
                    parameters.Add(new SqlParameter("@Position", employee.Position));
                }
                if (!string.IsNullOrEmpty(employee.Email))
                {
                    queryBuilder.Append("Email = @Email, ");
                    parameters.Add(new SqlParameter("@Email", employee.Email));
                }
                if (!string.IsNullOrEmpty(employee.Status))
                {
                    queryBuilder.Append("Status = @Status, ");
                    parameters.Add(new SqlParameter("@Status", employee.Status));
                }
                if (employee.HireDate != default)
                {
                    queryBuilder.Append("HireDate = @HireDate, ");
                    parameters.Add(new SqlParameter("@HireDate", employee.HireDate));
                }
                if (employee.Salary > 0)
                {
                    queryBuilder.Append("Salary = @Salary, ");
                    parameters.Add(new SqlParameter("@Salary", employee.Salary));
                }

                // Loại bỏ dấu phẩy cuối cùng
                queryBuilder.Length -= 2;

                queryBuilder.Append(" WHERE EmployeeId = @EmployeeId");
                parameters.Add(new SqlParameter("@EmployeeId", employee.EmployeeId));

                using (var command = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            finally
            {
                _dataProvider.CloseConnection(connection);
            }
        }

    }
}
