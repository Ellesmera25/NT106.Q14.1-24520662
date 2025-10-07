namespace _2
{
    partial class Form9
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(161, 73);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(67, 280);
            button2.Name = "button2";
            button2.Size = new Size(135, 29);
            button2.TabIndex = 1;
            button2.Text = "Tìm món ăn";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(261, 280);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(454, 280);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 31);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 4;
            label1.Text = "Nhập món ăn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 332);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 5;
            label2.Text = "Món ăn hôm nay là";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(261, 28);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(366, 232);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(67, 370);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(481, 27);
            textBox2.TabIndex = 8;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form9";
            Text = "Lab01-Bai08";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}