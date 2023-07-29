namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            textbox_path = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label3 = new Label();
            textBox_maxCount = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(271, 270);
            button1.Margin = new Padding(10);
            button1.Name = "button1";
            button1.Size = new Size(140, 35);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(497, 106);
            label1.TabIndex = 1;
            label1.Text = "Запустите программу из того места где она будет лежать постоянно.";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(481, 150);
            button2.Name = "button2";
            button2.Size = new Size(28, 23);
            button2.TabIndex = 2;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 132);
            label2.Name = "label2";
            label2.Size = new Size(251, 15);
            label2.TabIndex = 4;
            label2.Text = "Укажите путь к папке с вашими картинками";
            // 
            // textbox_path
            // 
            textbox_path.Location = new Point(12, 150);
            textbox_path.Name = "textbox_path";
            textbox_path.ReadOnly = true;
            textbox_path.Size = new Size(473, 23);
            textbox_path.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 191);
            label3.Name = "label3";
            label3.Size = new Size(305, 15);
            label3.TabIndex = 6;
            label3.Text = "Максимальное колличество картинок в вашей папке:";
            // 
            // textBox_maxCount
            // 
            textBox_maxCount.Location = new Point(323, 188);
            textBox_maxCount.Name = "textBox_maxCount";
            textBox_maxCount.Size = new Size(86, 23);
            textBox_maxCount.TabIndex = 7;
            textBox_maxCount.TextChanged += textBox_maxCount_TextChanged;
            textBox_maxCount.KeyPress += textBox_maxCount_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 239);
            Controls.Add(textBox_maxCount);
            Controls.Add(label3);
            Controls.Add(textbox_path);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Picture";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialog1;
        protected TextBox textbox_path;
        private Label label3;
        private TextBox textBox_maxCount;
    }
}