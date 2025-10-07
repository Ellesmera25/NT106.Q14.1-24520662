using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                //Bài 3: Viết chương trình nhập vào số nguyên từ 0 đến 9. In ra số đó bằng chữ.
namespace _2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox2.ReadOnly = true; //Khóa không cho nhập
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập số vào ô trống");
                return; //Kiểm tra nhập liệu
            }
            if (!int.TryParse(textBox1.Text, out n))
            {
                MessageBox.Show("Vui lòng nhập số nguyên");
                return; //Kiểm tra định dạng số
            }
            if (n < 0 || n > 9)
            {
                MessageBox.Show("Vui lòng nhập số từ 0 đến 9");
                return; //Kiểm tra điều kiện
            }
            //Chuyển số sang chữ
            switch (n)
            {
                case 0:
                    textBox2.Text = "Không";
                    break;
                case 1:
                    textBox2.Text = "Một";
                    break;
                case 2:
                    textBox2.Text = "Hai";
                    break;
                case 3:
                    textBox2.Text = "Ba";
                    break;
                case 4:
                    textBox2.Text = "Bốn";
                    break;
                case 5:
                    textBox2.Text = "Năm";
                    break;
                case 6:
                    textBox2.Text = "Sáu";
                    break;
                case 7:
                    textBox2.Text = "Bảy";
                    break;
                case 8:
                    textBox2.Text = "Tám";
                    break;
                case 9:
                    textBox2.Text = "Chín";
                    break;
                default: return;    
            }
        }
        //Xoá các ô
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        //Quay về Form1
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Lab1= new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
