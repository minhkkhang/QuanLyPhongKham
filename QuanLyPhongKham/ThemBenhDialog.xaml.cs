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
    /// Interaction logic for ThemBenhDialog.xaml
    /// </summary>
    public partial class ThemBenhDialog : Window
    {
        Benh b;
        List<CheckBox> list = new List<CheckBox>();
        public ThemBenhDialog(Benh benh,bool isObserve)
        {
            InitializeComponent();
            b = benh;
            if (isObserve)
            {
                OKPanel.Visibility = Visibility.Hidden;
                TenBenhTxt.IsReadOnly = true;
                TenBenhTxt.Text = b.LoaiBenh;
            }
            for(int i = 0; i < Bussiness.trieuChung.Count; i++)
            {
                CheckBox box = new CheckBox();
                box.Content = Bussiness.trieuChung.ElementAt(i);
                if (b.TrieuChung.Contains(Bussiness.trieuChung.ElementAt(i))) box.IsChecked = true;
                if (isObserve) { box.IsEnabled = false; }
                list.Add(box);
                TrieuChungCheckBoxes.Children.Add(box);
            }
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            b.LoaiBenh = TenBenhTxt.Text;
            if (b.LoaiBenh.Equals(""))
            {
                return;
            }
            string temp = "";
            int index = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if ((bool)list.ElementAt(i).IsChecked)
                {
                    if(index!=0) temp += " - ";
                    temp += list.ElementAt(i).Content;
                    index++;
                }
            }
            if (temp.Equals("")) return;
            
            b.TrieuChung = temp;
            DialogResult = true;
            Close();
        }
    }
}
