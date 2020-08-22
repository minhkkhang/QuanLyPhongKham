using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyPhongKham
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        List<CheckBox> list;
        StackPanel panel;
        public Settings(List<CheckBox>list,StackPanel panel)
        {
            InitializeComponent();
            TienKhamTxt.Text = Bussiness.tienKham.ToString();
            GioiHanTxt.Text = Bussiness.gioiHanLuotKham.ToString();
            this.list = list;
            this.panel = panel;
        }

        private void ThemDonViTxt_Click(object sender, RoutedEventArgs e)
        {
            if (DonViTxt.Text.ToString().Equals("")) return;
            Bussiness.donViThuoc.Add(DonViTxt.Text.ToString());
            Bussiness.saveSettings();
            DonViTxt.Text = "";
            MessageBox.Show("Them don vi thuoc thanh cong!");
        }

        private void ThemTrieuChungTxt_Click(object sender, RoutedEventArgs e)
        {
            if (TrieuChungTxt.Text.ToString().Equals("")) return;
            Bussiness.trieuChung.Add(TrieuChungTxt.Text.ToString());
            Bussiness.saveSettings();
            CheckBox box = new CheckBox();
            box.Content = TrieuChungTxt.Text.ToString();
            list.Add(box);
            panel.Children.Add(box);
            TrieuChungTxt.Text = "";
            MessageBox.Show("Them trieu chung thanh cong!");
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bussiness.tienKham = double.Parse(TienKhamTxt.Text.ToString());
                Bussiness.gioiHanLuotKham = int.Parse(GioiHanTxt.Text.ToString());
                Bussiness.saveSettings();
                MessageBox.Show("Thay doi cai dat thanh cong!");
            }
            catch(Exception ex) {
                MessageBox.Show("Cac gia tri khong hop le!");
                return;
            }
        }
    }
}
