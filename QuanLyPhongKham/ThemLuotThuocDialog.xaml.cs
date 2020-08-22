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
    /// Interaction logic for ThemLuotThuocDialog.xaml
    /// </summary>
    public partial class ThemLuotThuocDialog : Window
    {
        LuotThuoc lt;
        bool isObserve=false;
        public ThemLuotThuocDialog(LuotThuoc lt, bool isObserve)
        {
            InitializeComponent();
            this.lt = lt;
            TenThuocLabel.Content = lt.Thuoc;
            this.isObserve = isObserve;
            if (isObserve)
            {
                AdjustAmountPanel.Visibility = Visibility.Hidden;
            }
            Thuoc thuoc = ThuocDAO.getThuoc(lt.Thuoc);
            DonViLabel.Content = "Don vi tinh: " + thuoc.DonVi;
            DonGiaLabel.Content = "Don gia: " + thuoc.DonGia;
            CachDungLabel.Text = "Cach dung: " + thuoc.CachDung;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lt.SoLuong = int.Parse(SoLuongTxt.Text);
            }
            catch(Exception ex) { MessageBox.Show("Invalid number!"); return; }
            DialogResult = true;
            Close();
        }
    }
}
