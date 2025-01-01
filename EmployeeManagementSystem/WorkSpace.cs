using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace EmployeeManagementSystem
{
    public partial class WorkSpace : Form
    {


        public WorkSpace(string employeeName)
        {
            InitializeComponent();
            label3.Text = $"Welcome, {employeeName}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Đóng tất cả các form đã mở
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Tạo form Add Employee và thiết lập MDI Parent
            AddEmployee addEmployeeForm = new AddEmployee
            {
                MdiParent = this, // Gán form Workspace làm MDI Parent
                StartPosition = FormStartPosition.CenterScreen // Căn giữa form con
            };
            addEmployeeForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();

            // Đóng Form hiện tại (WorkSpace)
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Tạo form Dashboard mới và thiết lập MDI Parent
            DASHBOARD dashboardForm = new DASHBOARD
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            dashboardForm.Show();
            dashboardForm.RefreshDashboard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Đóng tất cả các form đã mở
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Tạo form Promotion mới và thiết lập MDI Parent
            PROMOTION newPromotionForm = new PROMOTION
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            newPromotionForm.Show();
        }
    }
}
