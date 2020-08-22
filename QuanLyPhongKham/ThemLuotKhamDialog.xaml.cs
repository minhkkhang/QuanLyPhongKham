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
    /// Interaction logic for ThemLuotKhamDialog.xaml
    /// </summary>
    public partial class ThemLuotKhamDialog : Window
    {
        BenhNhan bn;
        public ThemLuotKhamDialog(BenhNhan benhnhan,int isUpdate)
        {
            InitializeComponent();
            bn = benhnhan;
            if (isUpdate > 0)
            {
                CMNDTxt.IsReadOnly = true;
                if (isUpdate > 1)
                {
                    HoTenTxt.IsReadOnly = true;
                    DiaChiTxt.IsReadOnly = true;
                    SDTTxt.IsReadOnly = true;
                    NamRadioBtn.IsEnabled = false;
                    NuRadioBtn.IsEnabled = false;
                    OKPanel.Visibility = Visibility.Hidden;
                }
            }
            else CMNDTxt.IsEnabled = true;
            CMNDTxt.Text = benhnhan.CMND;
            HoTenTxt.Text = benhnhan.HoTen;
            DiaChiTxt.Text = benhnhan.DiaChi;
            SDTTxt.Text = benhnhan.SDT;
            if (benhnhan.GioiTinh == 1) NamRadioBtn.IsChecked = true;
            else NuRadioBtn.IsChecked = true;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            bn.CMND = CMNDTxt.Text;
            bn.HoTen = HoTenTxt.Text;
            if (bn.CMND.Equals(""))
            {
                return;
            }
            if ((bool)NamRadioBtn.IsChecked) bn.GioiTinh = 1;
            else bn.GioiTinh = 0;
            bn.DiaChi = DiaChiTxt.Text;
            bn.SDT = SDTTxt.Text;
            DialogResult = true;
            Close();
        }
    }
}
