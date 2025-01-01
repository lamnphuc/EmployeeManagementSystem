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
using TL;

namespace EmployeeManagementSystem
{
    public partial class DASHBOARD : Form
    {
        private readonly DashboardBussiness _dashboardBussiness;
        public DASHBOARD()
        {
            InitializeComponent();
            _dashboardBussiness = new DashboardBussiness();
            LoadDashboardStats();
        }
        private void LoadDashboardStats()
        {
            try
            {
                var stats = _dashboardBussiness.GetEmployeeStats();

                label2.Text = $"{stats.TotalEmployees}";
                label6.Text = $"{stats.ActiveEmployees}";
                label5.Text = $"{stats.InactiveEmployees}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void RefreshDashboard()
        {
            // Lấy dữ liệu thống kê từ Business Layer
            DashboardTranfer stats = _dashboardBussiness.GetEmployeeStats();

            // Hiển thị dữ liệu lên giao diện
            label2.Text = stats.TotalEmployees.ToString();
            label6.Text = stats.ActiveEmployees.ToString();
            label5.Text = stats.InactiveEmployees.ToString();
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            var employees = _dashboardBussiness.GetAllEmployees();
            dataGridView1.DataSource = employees; // Giả định bạn đã có DataGridView đặt tên là dataGridViewEmployees
        }
    }
}
