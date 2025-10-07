using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace _2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            //Thiết lập giao diện
            comboBox1.Items.Add("Bảng cửu chương");
            comboBox1.Items.Add("Tính toán giá trị");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            richTextBox1.ReadOnly = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Bảng cửu chương
            if (comboBox1.SelectedItem == "Bảng cửu chương")
            {
                
                richTextBox1.Clear();
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập số");
                    return;
                }
                int num1, num2;
                if (int.TryParse(textBox1.Text, out num1) && int.TryParse(textBox2.Text, out num2)) //Đúng định dạng số
                {
                    int subNum = num2 - num1;
                    for (int i = 1; i <= 9; i++)
                    {
                        richTextBox1.AppendText(subNum.ToString() + " x " + i.ToString() + " = " + (subNum * i).ToString() + "\n");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số nguyên");
                    return;
                }
            }
            //Tính giai thừa và tổng lũy thừa
            if (comboBox1.SelectedItem == "Tính toán giá trị")
            {
                richTextBox1.Clear();
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các số");
                    return;
                }
                int num1, num2;
                if (int.TryParse(textBox1.Text, out num1) && int.TryParse(textBox2.Text, out num2)) //Nhập đúng định dạng
                {
                    BigInteger factorial = 1; //Giai thừa có thể rất lớn nên dùng BigInteger
                    for (int i = num1 - num2; i >= 1; i--)
                    {
                        factorial *= i;
                    }

                    richTextBox1.AppendText("(A-B)!= " + factorial.ToString());
                    if (num2 == 0 && num1 == 0)
                    {
                        richTextBox1.AppendText("\nKhong co 0^0");
                    }
                    else if (num2 == 0 && num1 != 0)
                    {
                        richTextBox1.AppendText("\nA^0 = 1");
                    }
                    else
                    {
                        BigInteger sumPow = 0;
                        for (int i = 1; i <= num2; i++)
                        {
                            sumPow += BigInteger.Pow(num1, i);
                        }
                        richTextBox1.AppendText("\nA^1 + A^2 + ... + A^B = " + sumPow.ToString());
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số nguyên");
                    return;
                }
            }
            if (comboBox1.SelectedIndex == -1) //Chưa chọn chức năng
            {
                MessageBox.Show("Vui lòng chọn chức năng");
                return;
            }
        }
        //Xóa trắng
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }
        //Quay về Form1
        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 Lab1 = new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
