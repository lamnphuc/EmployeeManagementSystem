namespace EmployeeManagementSystem
{
    partial class ForgetPassword
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(124, 205);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(94, 153);
            label1.Name = "label1";
            label1.Size = new Size(370, 22);
            label1.TabIndex = 1;
            label1.Text = "Please enter your Email to send the Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F);
            label2.ForeColor = Color.Black;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(529, 9);
            label2.Name = "label2";
            label2.Size = new Size(20, 21);
            label2.TabIndex = 2;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 11, 97);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.CheckedBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 10.2F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(209, 256);
            button1.Name = "button1";
            button1.Size = new Size(124, 35);
            button1.TabIndex = 7;
            button1.Text = "SEND";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ForgetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 437);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}