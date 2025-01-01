using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using TL;

namespace BL
{
    public class AddEmployeeBussiness
    {
        public class EmployeeBusiness
        {
            private readonly EmployeeData _employeeData;

            public EmployeeBusiness()
            {
                _employeeData = new EmployeeData();
            }

            // Hàm tính lương dựa trên Position
            private int CalculateSalary(string position)
            {
                return position switch
                {
                    "Intern" => 5000000,
                    "Fresher" => 6000000,
                    "Junior" => 7000000,
                    "Senior" => 8000000,
                    "Team Leader" => 10000000,
                    _ => 0
                };
            }

            // Kiểm tra cấu trúc số điện thoại
            private bool IsValidPhoneNumber(string phoneNumber)
            {
                return phoneNumber.Length == 10 && phoneNumber.StartsWith("0");
            }

            // Kiểm tra cấu trúc email
            private bool IsValidEmail(string email)
            {
                return email.EndsWith("@gmail.com");
            }

            public string AddEmployee(AddEmployeeTranfer employee)
            {
                // Kiểm tra tất cả các trường bắt buộc
                if (string.IsNullOrWhiteSpace(employee.FullName))
                {
                    return "Vui lòng nhập họ tên.";
                }

                if (string.IsNullOrWhiteSpace(employee.Gender))
                {
                    return "Vui lòng chọn giới tính.";
                }

                if (string.IsNullOrWhiteSpace(employee.Phone))
                {
                    return "Vui lòng nhập số điện thoại.";
                }

                if (string.IsNullOrWhiteSpace(employee.Position))
                {
                    return "Vui lòng chọn vị trí.";
                }

                if (string.IsNullOrWhiteSpace(employee.Email))
                {
                    return "Vui lòng nhập email.";
                }

                if (string.IsNullOrWhiteSpace(employee.Status))
                {
                    return "Vui lòng chọn trạng thái.";
                }

                if (employee.HireDate == default)
                {
                    return "Vui lòng chọn ngày tuyển dụng.";
                }

                // Kiểm tra số điện thoại
                if (!IsValidPhoneNumber(employee.Phone))
                {
                    return "Số điện thoại phải có 10 số và bắt đầu bằng số 0.";
                }

                // Kiểm tra email
                if (!IsValidEmail(employee.Email))
                {
                    return "Email phải có định dạng @gmail.com.";
                }

                // Tính lương tự động
                employee.Salary = CalculateSalary(employee.Position);

                // Thêm vào DB
                bool isSuccess = _employeeData.AddEmployee(employee);
                return isSuccess ? "Thêm nhân viên thành công!" : "Thêm nhân viên thất bại!";
            }
            public string DeleteEmployee(int employeeId)
            {
                // Kiểm tra ID có hợp lệ không
                if (employeeId <= 0)
                {
                    return "ID nhân viên không hợp lệ.";
                }

                // Gọi phương thức DeleteEmployee từ lớp Data
                bool isDeleted = _employeeData.DeleteEmployee(employeeId);

                // Nếu trả về false, có thể do vị trí là Manager hoặc không tìm thấy nhân viên
                if (!isDeleted)
                {
                    // Kiểm tra xem nhân viên có tồn tại không
                    var position = _employeeData.GetEmployeePosition(employeeId);
                    if (position == "Manager")
                    {
                        return "Không thể xóa nhân viên với vị trí là Manager.";
                    }

                    return "Không thể xóa nhân viên. Vui lòng kiểm tra lại ID.";
                }

                // Thành công
                return "Xóa nhân viên thành công!";
            }
            public string UpdateEmployee(AddEmployeeTranfer employee)
            {
                // Kiểm tra ID hợp lệ
                if (employee.EmployeeId <= 0)
                {
                    return "ID nhân viên không hợp lệ.";
                }

                // Kiểm tra nếu không có trường nào để cập nhật
                if (string.IsNullOrEmpty(employee.FullName) &&
                    string.IsNullOrEmpty(employee.Gender) &&
                    string.IsNullOrEmpty(employee.Phone) &&
                    string.IsNullOrEmpty(employee.Position) &&
                    string.IsNullOrEmpty(employee.Email) &&
                    string.IsNullOrEmpty(employee.Status) &&
                    employee.HireDate == default &&
                    employee.Salary <= 0)
                {
                    return "Không có dữ liệu để cập nhật.";
                }

                // Kiểm tra vị trí của nhân viên
                var position = _employeeData.GetEmployeePosition(employee.EmployeeId);
                if (position == "Manager")
                {
                    return "Không thể cập nhật nhân viên có vị trí là Manager.";
                }

                // Kiểm tra số điện thoại
                if (!string.IsNullOrEmpty(employee.Phone) && !IsValidPhoneNumber(employee.Phone))
                {
                    return "Số điện thoại phải có 10 số và bắt đầu bằng số 0.";
                }

                // Kiểm tra email
                if (!string.IsNullOrEmpty(employee.Email) && !IsValidEmail(employee.Email))
                {
                    return "Email phải có định dạng @gmail.com.";
                }

                // Gọi phương thức cập nhật
                bool isUpdated = _employeeData.UpdateEmployeeDynamic(employee);
                return isUpdated ? "Cập nhật nhân viên thành công!" : "Cập nhật nhân viên thất bại!";
            }
        }

    }
}