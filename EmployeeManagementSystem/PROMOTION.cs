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
    public partial class PROMOTION : Form
    {
        private PromotionBusiness _promotionBusiness;
        public PROMOTION()
        {
            InitializeComponent();
            _promotionBusiness = new PromotionBusiness();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                monthCalendar1.SelectionStart == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng hàm nếu có trường không hợp lệ
            }

            // Tạo đối tượng PromotionTransfer từ thông tin nhập
            var promotion = new PromotionTransfer
            {
                EmployeeId = int.Parse(textBox5.Text.Trim()),
                OldPosition = comboBox2.SelectedItem?.ToString(),
                NewPosition = comboBox1.SelectedItem?.ToString(),
                PromotionDate = monthCalendar1.SelectionStart,
                Reason = textBox3.Text.Trim()
            };

            try
            {
                // Gọi hàm PromoteEmployee trong Business Layer
                string result = _promotionBusiness.PromoteEmployee(promotion);

                // Hiển thị thông báo kết quả
                MessageBox.Show(result);

                // Tải lại dữ liệu vào DataGridView
                LoadPromotionData();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thăng cấp nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPromotionData()
        {
            try
            {
                // Lấy danh sách Promotion từ Business Layer
                var promotions = _promotionBusiness.GetPromotions();

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = promotions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PROMOTION_Load(object sender, EventArgs e)
        {
            LoadPromotionData();
        }
        private void ClearInputFields()
        {
            // Xóa nội dung các trường nhập liệu
            textBox5.Clear(); // Employee ID
            comboBox2.SelectedIndex = -1; // Old Position
            comboBox1.SelectedIndex = -1; // New Position
            textBox3.Clear(); // Reason
            monthCalendar1.SelectionStart = DateTime.Now; // Reset lại ngày
        }
    }
}
