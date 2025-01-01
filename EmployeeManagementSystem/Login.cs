using System.Windows.Forms;
using BL;
using DL;

namespace EmployeeManagementSystem
{
    public partial class Login : Form
    {
        private readonly LoginBusiness _loginBusiness;
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '•';
            _loginBusiness = new LoginBusiness();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim(); // Lấy tên đăng nhập từ TextBox
            string password = textBox2.Text.Trim(); // Lấy mật khẩu từ TextBox

            // Kiểm tra nếu các trường không trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Kiểm tra thông tin đăng nhập
            try
            {
                var (isLoginSuccessful, employeeName, message) = _loginBusiness.Login(username, password);

                if (isLoginSuccessful)
                {
                    MessageBox.Show(message);
                    WorkSpace workSpaceForm = new WorkSpace(employeeName);
                    workSpaceForm.Show();

                    // Đóng Form đăng nhập
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(message); // Hiển thị thông báo lỗi
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}"); // Thông báo lỗi chung
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            var forgetPasswordForm = new ForgetPassword();

            // Hiển thị form ForgetPassword
            forgetPasswordForm.ShowDialog();
        }
    }
}
