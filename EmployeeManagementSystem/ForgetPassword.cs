using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace EmployeeManagementSystem
{
    public partial class ForgetPassword : Form
    {
        private readonly ForgetPasswordBusiness _business;
        public ForgetPassword()
        {
            InitializeComponent();
            _business = new ForgetPasswordBusiness();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = await _business.SendResetPasswordEmail(email);
                if (success)
                {
                    MessageBox.Show("Email đã được gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Gửi email thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
