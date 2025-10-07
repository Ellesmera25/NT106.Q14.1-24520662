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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1, num2;
            long sum = 0;
            if (int.TryParse(textBox1.Text, out num1) == false)
            {
                MessageBox.Show("Vui lòng nhập số nguyên");
                return;
            }
            if (int.TryParse(textBox2.Text, out num2) == false)
            {
                MessageBox.Show("Vui lòng nhập số nguyên");
                return;
            }
            //Kiểm tra điều kiện của cả 2 số
            sum = num1 + num2;
            textBox3.Text = sum.ToString();
        }
        //Quay về Form1
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Lab1 = new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
