using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
        }
        //Xóa trắng các ô
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn"); //Kiểm tra nhập liệu
                return;
            }
            else
            {
                richTextBox1.AppendText(textBox1.Text + "\n");
                textBox1.Clear();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random randomLine = new Random();
            string[] foodList = richTextBox1.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray(); //Lấy các dòng không trống
            if (foodList.Length == 0)
            {
                MessageBox.Show("Danh sách món ăn trống, vui lòng nhập món ăn");
                return;
            }
            else
            {
                int index = randomLine.Next(0, foodList.Length);
                textBox2.Text = foodList[index]; //Hiện món ăn được chọn ngẫu nhiên
                return;
            }
        }
        //Quay về Form1
        private void button4_Click_1(object sender, EventArgs e)
        {
            Form1 Lab1 = new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
