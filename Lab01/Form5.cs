using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _2
{
    public partial class Form5 : Form
    {
        private Dictionary<string, decimal> priceOfFilm = new Dictionary<string, decimal>(); //Lưu giá phim, dùng bảng băm vì tra cứu nhanh
        private HashSet<string> bookedSeat = new HashSet<string>(); //Lưu ghế đã được mua, dùng hashset vì không cho trùng
        private List<(string Film, string Theater, string Seat)> choosingSeat = new List<(string, string, string)>();//Lưu ghế đang chọn, dùng mảng 1 chiều vì có thể trùng

        public Form5()
        {
            InitializeComponent();
            //Thiết lập giao diện
            richTextBox1.ReadOnly = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            //Thêm phim vào combobox1
            comboBox1.Items.AddRange(new string[]
            {
                "Đào, phở và piano",
                "Mai",
                "Gặp lại chị bầu",
                "Tarot"
            });
            //Thêm ghế vào checkedListBox1
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    checkedListBox1.Items.Add((char)('A' + i) + j.ToString());
                }
            }
            //Thêm các giá phim vào dictionary, thêm sự kiện
            InitPrice();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
        }
        //Hàm khởi tạo giá phim
        private void InitPrice()
        {
            priceOfFilm.Add("Đào, phở và piano", 45000);
            priceOfFilm.Add("Mai", 100000);
            priceOfFilm.Add("Gặp lại chị bầu", 70000);
            priceOfFilm.Add("Tarot", 90000);
        }
        //Hàm lấy loại ghế
        private string GetTypeSeat(string seat)
        {
            if (seat == "A1" || seat == "A5" || seat == "C1" || seat == "C5")
                return "Vớt";
            else if (seat == "A2" || seat == "A3" || seat == "A4" ||
                     seat == "C2" || seat == "C3" || seat == "C4")
                return "Thường";
            else
                return "VIP";
        }
        //Hàm tính giá ghế
        private decimal CalculatePrice(decimal basePrice, string seat)
        {
            string loai = GetTypeSeat(seat);
            if (loai == "Vớt") return basePrice * 0.25m;
            if (loai == "Thường") return basePrice;
            return basePrice * 2m;
        }
        //Sự kiện khi chọn phim thì khởi tạo rạp chiếu tương ứng
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            resetCheckedListBox();
            if (comboBox1.SelectedItem == null)
                return;
            string selectedFilm = comboBox1.SelectedItem.ToString();

            if (selectedFilm == "Đào, phở và piano")
                comboBox2.Items.AddRange(new string[] { "1", "2", "3" });
            else if (selectedFilm == "Mai")
                comboBox2.Items.AddRange(new string[] { "2", "3" });
            else if (selectedFilm == "Gặp lại chị bầu")
                comboBox2.Items.Add("1");
            else if (selectedFilm == "Tarot")
                comboBox2.Items.Add("3");
        }
        //Sự kiện khi chọn rạp chiếu thì reset checkedListBox
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetCheckedListBox();
        }
        //Sự kiện khi nhấn nút "Chọn ghế"
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phim và rạp chiếu trước!", "Thông báo");
                return;//Kiểm tra đã chọn phim và rạp chiếu chưa
            }

            string film = comboBox1.SelectedItem.ToString();
            string theater = comboBox2.SelectedItem.ToString();
            decimal basePrice = priceOfFilm[film];
            decimal totalPrice = 0;

            var selectedSeats = checkedListBox1.CheckedItems.Cast<string>().ToList();
            //Kiểm tra đã chọn ghế chưa
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 ghế!", "Thông báo");
                return; 
            }
            var distinctTheaters = choosingSeat.Select(x => x.Theater).Distinct().ToList();
            //Kiểm tra không chọn quá 2 phòng chiếu khác nhau
            if (!distinctTheaters.Contains(theater) && distinctTheaters.Count >= 2)
            {
                MessageBox.Show("Không thể chọn nhiều hơn 2 phòng chiếu khác nhau!", "Cảnh báo");
                return; 
            }
            //Xử lý từng ghế được chọn
            foreach (var seat in selectedSeats)
            {
                string key = $"{film}_{theater}_{seat}";
                if (bookedSeat.Contains(key))
                {
                    MessageBox.Show($"Ghế {seat} ở {film} (rạp {theater}) đã được mua!", "Thông báo");
                    continue;
                }

                if (choosingSeat.Any(x => x.Film == film && x.Theater == theater && x.Seat == seat))
                {
                    MessageBox.Show($"Ghế {seat} ở phim này đã được chọn!", "Thông báo");
                    continue;
                }
                //Tính giá và lưu ghế đã chọn
                decimal price = CalculatePrice(basePrice, seat);
                choosingSeat.Add((film, theater, seat));
                totalPrice += price;
                richTextBox1.AppendText($"{film} | Rạp {theater} | Ghế {seat} | Loại: {GetTypeSeat(seat)} | Giá: {price:#,##0}₫\n");
            }

            resetCheckedListBox();
        }
        //Sự kiện khi nhấn nút "Xóa tất cả"
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa tất cả lựa chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.Items.Clear();
                richTextBox1.Clear();
                choosingSeat.Clear();
                resetCheckedListBox();
            }
        }
        //Sự kiện khi nhấn nút "Thanh toán"
        private void button3_Click(object sender, EventArgs e)
        {
            if (choosingSeat.Count == 0)
            {
                MessageBox.Show("Chưa có vé nào được chọn!", "Thông báo");
                return;
            }
            //Nhập họ tên khách hàng
            string hoTen = Microsoft.VisualBasic.Interaction.InputBox("Nhập họ tên khách hàng:", "Thông tin khách hàng");
            if (string.IsNullOrWhiteSpace(hoTen)) return;
            //Tính tổng tiền và lưu ghế đã mua
            decimal tongTien = 0;
            foreach (var ve in choosingSeat)
            {
                string key = $"{ve.Film}_{ve.Theater}_{ve.Seat}";
                bookedSeat.Add(key);
                tongTien += CalculatePrice(priceOfFilm[ve.Film], ve.Seat);
            }

            richTextBox1.AppendText($"\n--- Thanh toán ---\nKhách hàng: {hoTen}\nTổng tiền: {tongTien:#,##0}₫\n\n");
            MessageBox.Show($"Thanh toán thành công cho {hoTen}!\nTổng tiền: {tongTien:#,##0}₫", "Hoàn tất");

            choosingSeat.Clear();
        }
        //Sự kiện khi nhấn nút "Reset"
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.Items.Clear();
            resetCheckedListBox();
        }
        //Hàm reset checkedListBox
        private void resetCheckedListBox()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }
        //Quay về Form1
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 Lab01 = new Form1();
            Lab01.Show();
            this.Hide();
        }
    }
}
