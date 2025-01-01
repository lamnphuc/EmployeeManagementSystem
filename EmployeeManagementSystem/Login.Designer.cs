namespace EmployeeManagementSystem
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(33, 11, 97);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 553);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(108, 153);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 105);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(24, 291);
            label5.Name = "label5";
            label5.Size = new Size(290, 24);
            label5.TabIndex = 0;
            label5.Text = "Employee Management System";
            label5.Click += label5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(429, 84);
            label2.Name = "label2";
            label2.Size = new Size(245, 35);
            label2.TabIndex = 1;
            label2.Text = "Login Account";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(810, 9);
            label1.Name = "label1";
            label1.Size = new Size(22, 21);
            label1.TabIndex = 2;
            label1.Text = "X";
            label1.Click += label1_Click;
            label1.MouseEnter += Label_MouseEnter;
            label1.MouseLeave += Label_MouseLeave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(422, 170);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 3;
            label3.Text = "Username:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(422, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(348, 27);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 238);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(422, 261);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(348, 27);
            textBox2.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(638, 294);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(132, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1.MouseEnter += Label_MouseEnter;
            checkBox1.MouseLeave += Label_MouseLeave;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 11, 97);
            button1.Font = new Font("Tahoma", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(530, 346);
            button1.Name = "button1";
            button1.Size = new Size(114, 47);
            button1.TabIndex = 8;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += Label_MouseEnter;
            button1.MouseLeave += Label_MouseLeave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Location = new Point(422, 298);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 9;
            label6.Text = "Forget Password?";
            label6.Click += label6_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 554);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private Button button1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
    }
}
