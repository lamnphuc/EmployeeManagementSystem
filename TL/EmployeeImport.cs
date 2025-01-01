using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace TL
{
    public class EmployeeImport
    {
        public List<Employee> ReadExcelFile(string filePath)
        {
            var employees = new List<Employee>();

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Đọc sheet đầu tiên
                    var rows = worksheet.RangeUsed().RowsUsed();

                    foreach (var row in rows.Skip(1)) // Bỏ qua dòng tiêu đề
                    {
                        var employee = new Employee
                        {
                            FullName = row.Cell(1).GetValue<string>(),
                            Gender = row.Cell(2).GetValue<string>(),
                            Position = row.Cell(3).GetValue<string>(),
                            Salary = row.Cell(4).GetValue<int>(),
                            Phone = row.Cell(5).GetValue<string>(),
                            Email = row.Cell(6).GetValue<string>(),
                            HireDate = row.Cell(7).GetValue<DateTime>(),
                            Status = row.Cell(8).GetValue<string>()
                        };

                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Excel file: " + ex.Message);
            }

            return employees;
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; }
    }
}

