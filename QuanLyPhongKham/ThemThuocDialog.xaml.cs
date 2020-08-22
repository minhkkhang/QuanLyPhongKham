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
    /// Interaction logic for ThemThuocDialog.xaml
    /// </summary>
    public partial class ThemThuocDialog : Window
    {
        Thuoc t;
        public ThemThuocDialog(Thuoc thuoc)
        {
            InitializeComponent();
            t = thuoc;
            DonGiaTxt.Text = "0";
            DonViCombobox.ItemsSource = Bussiness.donViThuoc;
        }

        private void OKBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            t.TenThuoc = TenThuocTxt.Text;
            if (t.TenThuoc.Equals(""))
            {
                return;
            }
            t.CachDung = CachDungTxt.Text;
            try
            {
                t.DonGia = Double.Parse(DonGiaTxt.Text);
            }
            catch(Exception ex)
            {
                DialogResult = false;
                Close();
                return;
            }
            t.DonVi = DonViCombobox.SelectedItem as string;
            DialogResult = true;
            Close();
        }
    }
}
