using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                    //Bài 2: Viết chương trình nhập vào 3 số thực. Tìm số lớn nhất, nhỏ nhất trong 3 số đó.
namespace _2
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true; //Khóa không cho nhập
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, num3;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ 3 số.");
                return; //Kiểm tra nhập liệu
            }
            if (double.TryParse(textBox1.Text, out num1) == false || double.TryParse(textBox2.Text, out num2) == false || double.TryParse(textBox3.Text, out num3) == false)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số.");
                return; //Kiểm tra định dạng số
            }
            //So sánh tìm số lớn nhất và nhỏ nhất
            if (num1 < num2 && num1 < num3)
            {
                textBox5.Text = num1.ToString();
            }
            else if (num2 < num1 && num2 < num3)
            {
                textBox5.Text = num2.ToString();
            }
            else
            {
                textBox5.Text = num3.ToString();
            }
            if (num1 > num2 && num1 > num3)
            {
                textBox4.Text = num1.ToString();
            }
            else if (num2 > num1 && num2 > num3)
            {
                textBox4.Text = num2.ToString();
            }
            else
            {
                textBox4.Text = num3.ToString();
            }
        }
        //Xóa trắng các TextBox
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        //Quay về Form1
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Lab1 = new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
