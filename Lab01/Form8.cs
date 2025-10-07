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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            richTextBox2.ReadOnly = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            string[] nameAndPoint = richTextBox1.Text.Split(','); //Tách chuỗi theo dấu phẩy
            double sum = 0;
            if (nameAndPoint.Length <= 1)
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
                return;
            }
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                if (double.TryParse(nameAndPoint[i], out double point) == false)//Điểm không phải số
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                    return;
                }
                if (point > 10 || point < 0) //Điểm không hợp lệ
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                    return;
                }
                sum += point;
            }
            richTextBox2.AppendText("Họ và tên: ");
            richTextBox2.AppendText(nameAndPoint[0] + "\n");
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                richTextBox2.AppendText("Môn " + i + ": " + nameAndPoint[i] + "\t");
            }
            double average = sum / (nameAndPoint.Length - 1);
            double minPoint = 11;
            for (int i = 1; i < nameAndPoint.Length; i++) //Tìm điểm thấp nhất
            {
                if (double.TryParse(nameAndPoint[i], out double point))
                {
                    if (point < minPoint) minPoint = point;
                }
            }
            double maxPoint = -1; //Tìm điểm cao nhất
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                if (double.TryParse(nameAndPoint[i], out double point))
                {
                    if (point > maxPoint) maxPoint = point;
                }
            }
            int countPass = 0; //Đếm số môn đậu
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                if (double.TryParse(nameAndPoint[i], out double point))
                {
                    if (point >= 5) countPass++;
                }
            }
            richTextBox2.AppendText("\nĐiểm trung bình: " + Math.Round(average, 2)); //Làm tròn 2 chữ số thập phân
            richTextBox2.AppendText("\nMôn có điểm cao nhất: ");
            //In ra các môn có điểm cao nhất
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                if (double.Parse(nameAndPoint[i]) == maxPoint)
                {
                    richTextBox2.AppendText("Môn " + i + "\t");
                }
            }
            richTextBox2.AppendText("\nMôn có điểm thấp nhất: ");
            //In ra các môn có điểm thấp nhất
            for (int i = 1; i < nameAndPoint.Length; i++)
            {
                if (double.Parse(nameAndPoint[i]) == minPoint)
                {
                    richTextBox2.AppendText("Môn " + i + "\t");
                }
            }
            richTextBox2.AppendText("\nSố môn đậu: " + countPass);
            richTextBox2.AppendText("\nSố môn rớt: " + (nameAndPoint.Length - 1 - countPass));
            richTextBox2.AppendText("\nXếp loại: ");
            //Xếp loại
            if (average >= 8)
            {
                if (minPoint >= 6.5)
                {
                    richTextBox2.AppendText("Giỏi");
                }
                else if (minPoint >= 5)
                {
                    richTextBox2.AppendText("Khá");
                }
                else if (minPoint >= 3.5)
                {
                    richTextBox2.AppendText("Trung bình");
                }
                else if (minPoint >= 2)
                {
                    richTextBox2.AppendText("Yếu");
                }
                else
                {
                    richTextBox2.AppendText("Kém");
                }
            }
            else if (average >= 6.5)
            {
                if (minPoint >= 5)
                {
                    richTextBox2.AppendText("Khá");
                }
                else if (minPoint >= 3.5)
                {
                    richTextBox2.AppendText("Trung bình");
                }
                else if (minPoint >= 2)
                {
                    richTextBox2.AppendText("Yếu");
                }
                else
                {
                    richTextBox2.AppendText("Kém");
                }
            }
            else if (average >= 5)
            {
                if (minPoint >= 3.5)
                {
                    richTextBox2.AppendText("Trung bình");
                }
                else if (minPoint >= 2)
                {
                    richTextBox2.AppendText("Yếu");
                }
                else
                {
                    richTextBox2.AppendText("Kém");
                }
            }
            else if (average >= 3.5)
            {
                if (minPoint >= 2)
                {
                    richTextBox2.AppendText("Yếu");
                }
                else
                {
                    richTextBox2.AppendText("Kém");
                }
            }
            else
            {
                richTextBox2.AppendText("Kém");
            }
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
