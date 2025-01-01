using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DL;

namespace BL
{
    public class PrintBussiness
    {
        private PrintData employeeData;

        public PrintBussiness()
        {
            employeeData = new PrintData();
        }

        public void ExportToExcel(string filePath)
        {
            var employees = employeeData.GetEmployees();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                // Thêm tiêu đề cột
                worksheet.Cell(1, 1).Value = "Full Name";
                worksheet.Cell(1, 2).Value = "Gender";
                worksheet.Cell(1, 3).Value = "Position";
                worksheet.Cell(1, 4).Value = "Salary";
                worksheet.Cell(1, 5).Value = "Phone";
                worksheet.Cell(1, 6).Value = "Email";
                worksheet.Cell(1, 7).Value = "Hire Date";
                worksheet.Cell(1, 8).Value = "Status";

                // Thêm dữ liệu nhân viên
                for (int i = 0; i < employees.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = employees[i].FullName;
                    worksheet.Cell(i + 2, 2).Value = employees[i].Gender;
                    worksheet.Cell(i + 2, 3).Value = employees[i].Position;
                    worksheet.Cell(i + 2, 4).Value = employees[i].Salary;
                    worksheet.Cell(i + 2, 5).Value = employees[i].Phone;
                    worksheet.Cell(i + 2, 6).Value = employees[i].Email;
                    worksheet.Cell(i + 2, 7).Value = employees[i].HireDate;
                    worksheet.Cell(i + 2, 8).Value = employees[i].Status;
                }

                workbook.SaveAs(filePath);
            }
        }
    }
}
