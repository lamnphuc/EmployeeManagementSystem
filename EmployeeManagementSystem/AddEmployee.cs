using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BL;
using TL;
using static BL.AddEmployeeBussiness;





namespace EmployeeManagementSystem
{
    public partial class AddEmployee : Form
    {
        private readonly EmployeeBusiness _employeeBusiness;
        private PrintBussiness printBusiness;
        public AddEmployee()
        {
            InitializeComponent();
            _employeeBusiness = new EmployeeBusiness();
            printBusiness = new PrintBussiness();

        }


        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployeeTranfer employee = new AddEmployeeTranfer
            {
                FullName = textBox1.Text.Trim(),
                Gender = comboBox1.SelectedItem?.ToString(),
                Phone = textBox2.Text.Trim(),
                Position = comboBox2.SelectedItem?.ToString(),
                Email = textBox3.Text.Trim(),
                Status = comboBox3.SelectedItem?.ToString(),
                HireDate = monthCalendar1.SelectionStart,
                Salary = 0
            };

            // Gọi Business Layer
            string result = _employeeBusiness.AddEmployee(employee);
            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // FullName
            textBox2.Text = ""; // PhoneNumber
            textBox3.Text = ""; // Email

            // Đặt lại ComboBox về trạng thái mặc định
            comboBox1.SelectedIndex = -1; // Gender
            comboBox2.SelectedIndex = -1; // Position
            comboBox3.SelectedIndex = -1; // Status

            // Đặt lại MonthCalendar về ngày hiện tại
            monthCalendar1.SetDate(DateTime.Today);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox4.Text.Trim(), out int employeeId))
                {
                    string result = _employeeBusiness.DeleteEmployee(employeeId);
                    MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK,
                        result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ID nhân viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem trường EmployeeID có được nhập không
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Vui lòng nhập ID nhân viên cần cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy EmployeeID từ giao diện
                if (!int.TryParse(textBox5.Text.Trim(), out int employeeId) || employeeId <= 0)
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu người dùng cố tình thay đổi Position
                if (comboBox2.SelectedItem != null)
                {
                    MessageBox.Show("Không được phép cập nhật vị trí trong chức năng này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ giao diện
                AddEmployeeTranfer employee = new AddEmployeeTranfer
                {
                    EmployeeId = employeeId,
                    FullName = string.IsNullOrWhiteSpace(textBox1.Text) ? null : textBox1.Text.Trim(),
                    Gender = comboBox1.SelectedItem?.ToString(),
                    Phone = string.IsNullOrWhiteSpace(textBox2.Text) ? null : textBox2.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(textBox3.Text) ? null : textBox3.Text.Trim(),
                    Status = comboBox3.SelectedItem?.ToString(),
                    HireDate = monthCalendar1.SelectionStart // Không để mặc định, người dùng chọn
                };

                // Gọi Business Layer để cập nhật thông tin
                string result = _employeeBusiness.UpdateEmployee(employee);

                // Hiển thị kết quả
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới danh sách nhân viên sau khi cập nhật thành công
                if (result.Contains("thành công"))
                {

                    ClearInputFields(); // Hàm để xóa trắng các trường nhập liệu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputFields()
        {
            textBox5.Text = string.Empty;
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            textBox2.Text = string.Empty;
            comboBox2.SelectedIndex = -1; // Không cần sử dụng comboBox2
            textBox3.Text = string.Empty;
            comboBox3.SelectedIndex = -1;
            monthCalendar1.SetDate(DateTime.Now); // Đặt lại ngày hiện tại
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;

                    try
                    {
                        var importExcel = new EmployeeImport();
                        var employees = importExcel.ReadExcelFile(filePath);

                        var business = new EmployeeImportBussiness();
                        business.ProcessAndSaveEmployees(employees);

                        MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn mặc định là ổ D:
                string defaultDirectory = @"D:\";

                // Tạo tên file mới với timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"Employee_{timestamp}.xlsx";
                string filePath = Path.Combine(defaultDirectory, fileName);

                // Kiểm tra xem thư mục có tồn tại không, nếu không thì tạo mới
                if (!Directory.Exists(defaultDirectory))
                {
                    Directory.CreateDirectory(defaultDirectory);
                }

                // Gọi hàm xuất Excel
                printBusiness.ExportToExcel(filePath);

                MessageBox.Show($"Dữ liệu đã được xuất thành công tại:\n{filePath}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
