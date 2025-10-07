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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime inputDate;
            if (DateTime.TryParseExact(textBox1.Text, "dd/MM/yyyy",
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out inputDate)) //Check đúng định dạng ngày tháng năm
            {
                int day = inputDate.Day;
                int month = inputDate.Month;
                int year = inputDate.Year;
                //Xác định cung hoàng đạo
                switch (month)
                {
                    case 1:
                        if (day >= 21)
                        {
                            textBox2.Text = "Bảo Bình";
                        }
                        else
                        {
                            textBox2.Text = "Ma Kết";
                        }
                        break;
                    case 2:
                        if (day >= 20)
                        {
                            textBox2.Text = "Song Ngư";
                        }
                        else
                        {
                            textBox2.Text = "Bảo Bình";
                        }
                        break;
                    case 3:
                        if (day >= 21)
                        {
                            textBox2.Text = "Bạch Dương";
                        }
                        else
                        {
                            textBox2.Text = "Song Ngư";
                        }
                        break;
                    case 4:
                        if (day >= 21)
                        {
                            textBox2.Text = "Kim Ngưu";
                        }
                        else
                        {
                            textBox2.Text = "Bạch Dương";
                        }
                        break;
                    case 5:
                        if (day >= 22)
                        {
                            textBox2.Text = "Song Tử";
                        }
                        else
                        {
                            textBox2.Text = "Kim Ngưu";
                        }
                        break;
                    case 6:
                        if (day >= 23)
                        {
                            textBox2.Text = "Cự Giải";
                        }
                        else
                        {
                            textBox2.Text = "Song Tử";
                        }
                        break;
                    case 7:
                        if (day >= 24)
                        {
                            textBox2.Text = "Sư Tử";
                        }
                        else
                        {
                            textBox2.Text = "Cự Giải";
                        }
                        break;
                    case 8:
                        if (day >= 23)
                        {
                            textBox2.Text = "Xử Nữ";
                        }
                        else
                        {
                            textBox2.Text = "Sư Tử";
                        }
                        break;
                    case 9:
                        if (day >= 24)
                        {
                            textBox2.Text = "Thiên Bình";
                        }
                        else
                        {
                            textBox2.Text = "Xử Nữ";
                        }
                        break;
                    case 10:
                        if (day >= 24)
                        {
                            textBox2.Text = "Bọ Cạp";
                        }
                        else
                        {
                            textBox2.Text = "Thiên Bình";
                        }
                        break;
                    case 11:
                        if (day >= 23)
                        {
                            textBox2.Text = "Nhân Mã";
                        }
                        else
                        {
                            textBox2.Text = "Bọ Cạp";
                        }
                        break;
                    case 12:
                        if (day >= 22)
                        {
                            textBox2.Text = "Ma Kết";
                        }
                        else
                        {
                            textBox2.Text = "Nhân Mã";
                        }
                        break;
                    default:
                        return;
                }
            }
            else
            {
                MessageBox.Show("Ngày tháng năm không hợp lệ, vui lòng nhập lại"); //Sai định dạng
            }
        }
        //Quay về Form1
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Lab1=new Form1();
            Lab1.Show();
            this.Hide();
        }
    }
}
