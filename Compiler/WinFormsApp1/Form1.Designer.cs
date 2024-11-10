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
            button1 = new Button();
            button2 = new Button();
            txt1 = new TextBox();
            txt2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(185, 229, 232);
            button1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1272, 130);
            button1.Name = "button1";
            button1.Size = new Size(251, 94);
            button1.TabIndex = 0;
            button1.Text = "Tokens";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(185, 229, 232);
            button2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(1272, 230);
            button2.Name = "button2";
            button2.Size = new Size(251, 94);
            button2.TabIndex = 1;
            button2.Text = "Grammar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txt1
            // 
            txt1.BackColor = Color.FromArgb(223, 242, 235);
            txt1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt1.Location = new Point(-1, 76);
            txt1.Multiline = true;
            txt1.Name = "txt1";
            txt1.ScrollBars = ScrollBars.Both;
            txt1.Size = new Size(708, 701);
            txt1.TabIndex = 2;
            txt1.TextChanged += textBox1_TextChanged;
            // 
            // txt2
            // 
            txt2.BackColor = Color.FromArgb(223, 242, 235);
            txt2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt2.Location = new Point(713, 76);
            txt2.Multiline = true;
            txt2.Name = "txt2";
            txt2.ScrollBars = ScrollBars.Both;
            txt2.Size = new Size(553, 701);
            txt2.TabIndex = 3;
            txt2.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(122, 178, 211);
            ClientSize = new Size(1525, 789);
            Controls.Add(txt2);
            Controls.Add(txt1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Compiler";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox txt1;
        private TextBox txt2;
    }
}
