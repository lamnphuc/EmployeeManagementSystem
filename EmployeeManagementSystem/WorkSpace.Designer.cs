namespace EmployeeManagementSystem
{
    partial class WorkSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSpace));
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(33, 11, 97);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.FlatStyle = FlatStyle.Flat;
            label2.ForeColor = Color.White;
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            label1.Click += label1_Click;
            label1.MouseEnter += Label_MouseEnter;
            label1.MouseLeave += Label_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(33, 11, 97);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(33, 17, 98);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            resources.ApplyResources(button4, "button4");
            button4.ForeColor = Color.White;
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(33, 17, 98);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            resources.ApplyResources(button3, "button3");
            button3.ForeColor = Color.White;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            label4.MouseEnter += Label_MouseEnter;
            label4.MouseLeave += Label_MouseLeave;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            resources.ApplyResources(button2, "button2");
            button2.ForeColor = Color.White;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.MouseEnter += Label_MouseEnter;
            button2.MouseLeave += Label_MouseLeave;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 17, 98);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 8, 138);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 8, 138);
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = Color.White;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += Label_MouseEnter;
            button1.MouseLeave += Label_MouseLeave;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.White;
            label3.Name = "label3";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // WorkSpace
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "WorkSpace";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Label label4;
        private Button button3;
        private Button button4;
    }
}