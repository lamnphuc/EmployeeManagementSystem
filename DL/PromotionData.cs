using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using Microsoft.Data.SqlClient;

namespace DL
{
    public class PromotionData
    {
        private readonly DataProvider _dataProvider;

        public PromotionData()
        {
            _dataProvider = new DataProvider();
        }

        public AddEmployeeTranfer GetEmployeeById(int employeeId)
        {
            using (var connection = _dataProvider.OpenConnection())
            {
                string query = "SELECT EmployeeId, Position FROM Employees WHERE EmployeeId = @EmployeeId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AddEmployeeTranfer // Đảm bảo Employee là lớp đại diện cho dữ liệu nhân viên
                            {
                                EmployeeId = reader.GetInt32(0),
                                Position = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null; // Nếu không tìm thấy nhân viên
        }

        public bool UpdateEmployeePosition(int employeeId, string newPosition)
        {
            // Gọi hàm CalculateSalary từ lớp AddEmployeeBussiness
            int newSalary =  Salary(newPosition);

            using (var connection = _dataProvider.OpenConnection())
            {
                // Câu lệnh SQL cập nhật cả vị trí và mức lương
                string query = @"
            UPDATE Employees 
            SET Position = @NewPosition, Salary = @NewSalary 
            WHERE EmployeeId = @EmployeeId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPosition", newPosition);
                    command.Parameters.AddWithValue("@NewSalary", newSalary); // Thêm tham số mức lương mới
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
            }
        }
        public void InsertPromotionRecord(PromotionTransfer promotion)
        {
            using (var connection = _dataProvider.OpenConnection())
            {
                string query = "INSERT INTO Promotions (EmployeeId, OldPosition, NewPosition, PromotionDate, Reason) VALUES (@EmployeeId, @OldPosition, @NewPosition, @PromotionDate, @Reason)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", promotion.EmployeeId);
                    command.Parameters.AddWithValue("@OldPosition", promotion.OldPosition);
                    command.Parameters.AddWithValue("@NewPosition", promotion.NewPosition);
                    command.Parameters.AddWithValue("@PromotionDate", promotion.PromotionDate);
                    command.Parameters.AddWithValue("@Reason", promotion.Reason);

                    command.ExecuteNonQuery();
                }
            }
        }
        private int Salary(string position)
        {
            return position switch
            {
                "Intern" => 5000000,
                "Fresher" => 6000000,
                "Junior" => 7000000,
                "Senior" => 8000000,
                "Team Leader" => 10000000,
                _ => 0 // Giá trị mặc định nếu không có vị trí khớp
            };
        }
        public List<PromotionTransfer> GetPromotions()
        {
            var promotions = new List<PromotionTransfer>();

            using (var connection = _dataProvider.OpenConnection())
            {
                string query = "SELECT EmployeeId, OldPosition, NewPosition, PromotionDate, Reason FROM Promotions";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            promotions.Add(new PromotionTransfer
                            {
                                EmployeeId = reader.GetInt32(0),
                                OldPosition = reader.GetString(1),
                                NewPosition = reader.GetString(2),
                                PromotionDate = reader.GetDateTime(3),
                                Reason = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return promotions;
        }

    }
}
