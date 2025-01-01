namespace EmployeeManagementSystem
{
    partial class PROMOTION
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label3 = new Label();
            textBox3 = new TextBox();
            monthCalendar1 = new MonthCalendar();
            label2 = new Label();
            label5 = new Label();
            label1 = new Label();
            label10 = new Label();
            textBox5 = new TextBox();
            button2 = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(monthCalendar1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(27, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 722);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Intern", "Fresher", "Junior", "Senior", "Team Leader" });
            comboBox1.Location = new Point(25, 222);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 28);
            comboBox1.TabIndex = 33;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Intern", "Fresher", "Junior", "Senior", "Team Leader" });
            comboBox2.Location = new Point(25, 129);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(221, 28);
            comboBox2.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 483);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 31;
            label3.Text = "Reason:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(160, 481);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(262, 126);
            textBox3.TabIndex = 30;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(160, 262);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 177);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 29;
            label2.Text = "New position:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(26, 262);
            label5.Name = "label5";
            label5.Size = new Size(112, 21);
            label5.TabIndex = 18;
            label5.Text = "Change Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 95);
            label1.Name = "label1";
            label1.Size = new Size(104, 21);
            label1.TabIndex = 27;
            label1.Text = "Old position:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(26, 14);
            label10.Name = "label10";
            label10.Size = new Size(111, 21);
            label10.TabIndex = 25;
            label10.Text = "Employee ID:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(26, 52);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(224, 27);
            textBox5.TabIndex = 24;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(33, 11, 97);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.CheckedBackColor = Color.FromArgb(75, 8, 138);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 10.2F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(160, 633);
            button2.Name = "button2";
            button2.Size = new Size(143, 56);
            button2.TabIndex = 23;
            button2.Text = "Change";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(505, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(661, 723);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(605, 672);
            dataGridView1.TabIndex = 0;
            // 
            // PROMOTION
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1193, 765);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PROMOTION";
            Text = "PROMOTION";
            Load += PROMOTION_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label10;
        private TextBox textBox5;
        private Button button2;
        private Label label2;
        private MonthCalendar monthCalendar1;
        private Label label5;
        private TextBox textBox3;
        private Label label3;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}