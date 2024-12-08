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
            button3 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(71, 109, 124);
            button1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1183, 76);
            button1.Name = "button1";
            button1.Size = new Size(340, 94);
            button1.TabIndex = 0;
            button1.Text = "Tokens";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(71, 109, 124);
            button2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(1183, 176);
            button2.Name = "button2";
            button2.Size = new Size(340, 94);
            button2.TabIndex = 1;
            button2.Text = "Grammar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txt1
            // 
            txt1.BackColor = Color.FromArgb(71, 109, 124);
            txt1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt1.ForeColor = Color.White;
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
            txt2.BackColor = Color.FromArgb(71, 109, 124);
            txt2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt2.ForeColor = Color.White;
            txt2.Location = new Point(713, 76);
            txt2.Multiline = true;
            txt2.Name = "txt2";
            txt2.ScrollBars = ScrollBars.Both;
            txt2.Size = new Size(464, 701);
            txt2.TabIndex = 3;
            txt2.TextChanged += textBox2_TextChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(71, 109, 124);
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(-1, -2);
            button3.Name = "button3";
            button3.Size = new Size(185, 54);
            button3.TabIndex = 4;
            button3.Text = "Switch to Light Mode";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(71, 109, 124);
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(1183, 276);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(340, 501);
            textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 62, 83);
            ClientSize = new Size(1525, 789);
            Controls.Add(textBox1);
            Controls.Add(button3);
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
        private Button button3;
        private TextBox textBox1;
    }
}
