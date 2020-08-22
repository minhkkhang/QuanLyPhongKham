using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyPhongKham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
        }
        private BindingList<string> benhs;
        private void start()
        {
            Bussiness.init();
            DSLuotKhamListView.ItemsSource = Bussiness.listBenhNhan;
            LichSuKhamListView.ItemsSource = Bussiness.listLuotKhamTrongNgay;
            ThongKeDoanhThuListView.ItemsSource = Bussiness.listThongKeLuotkham;
            ThongKeThuocListView.ItemsSource = Bussiness.listThongKeLuotThuoc;
            ThemThuocListView.ItemsSource = Bussiness.bindingListAllThuoc;
            LuotThuocListView.ItemsSource = Bussiness.listLuotThuoc;
            benhs = new BindingList<string>();
            foreach (Benh b in Bussiness.listAllBenh) benhs.Add(b.LoaiBenh);
            BenhComboBox.ItemsSource = benhs;
            setUpTrieuChung();
        }
        
        private void UpdateUserInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            BenhNhan bn = LuotKhamDAO.getLuotKham(Bussiness.currentLuotKhamID).BenhNhan1;
            ThemLuotKhamDialog dialog = new ThemLuotKhamDialog(bn, 1);
            if (dialog.ShowDialog() == true)
            {
                Bussiness.addOrUpdateBenhNhan(bn.CMND, bn.HoTen, bn.SDT, bn.DiaChi, (byte)bn.GioiTinh);
                UserInfoTxtBlock.Text = bn.HoTen;
                foreach(BenhNhan b in Bussiness.listBenhNhan)
                {
                    if (b.CMND.Equals(bn.CMND))
                    {
                        b.diachi1 = bn.DiaChi;
                        b.sdt1 = bn.SDT;
                        b.gioitinh1 = (byte)bn.GioiTinh;
                        b.hoten1 = bn.HoTen;
                    }
                }
            }
        }
        

        private void ThemBenhNhanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Bussiness.listBenhNhan.Count > Bussiness.gioiHanLuotKham)
            {
                MessageBox.Show("So luong ca kham hom nay da vuot qua gioi han!");
                return;
            }
            BenhNhan bn = new BenhNhan();
            ThemLuotKhamDialog dialog = new ThemLuotKhamDialog(bn, 0);
            if (dialog.ShowDialog() == true)
            {
                foreach (BenhNhan b in Bussiness.listBenhNhan)
                {
                    if (b.CMND.Equals(bn.CMND)) {
                        MessageBox.Show("Benh nhan nay da duoc kham trong hom nay!");
                        return;
                    }
                }
                Bussiness.addOrUpdateBenhNhan(bn.CMND, bn.HoTen, bn.SDT, bn.DiaChi, (byte)bn.GioiTinh);
                Bussiness.addLuotKham(bn.CMND, DateTime.Today.ToString("dd/MM/yyyy"));
            }
        }

        private void KhamBenhBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DSLuotKhamListView.SelectedIndex == -1) return;
                ThongTinLuotKhamTab.IsEnabled = true;
                BenhNhan bn = DSLuotKhamListView.SelectedItem as BenhNhan;
                LuotKham lk = LuotKhamDAO.getLuotKhamBaseOnDateAndPatient(DateTime.Today.ToString("dd/MM/yyyy"), bn.CMND);
                Bussiness.currentLuotKhamID = -1;
                BenhComboBox.SelectedItem = lk.Benh;
                Bussiness.currentLuotKhamID = lk.ID;
                LuotKhamIDLabel.Content = "ID: " + lk.ID;
                BenhComboBox.SelectedItem = lk.Benh;
                if (!lk.Benh.Equals(""))
                {
                    Benh b = BenhDAO.getBenh(lk.Benh);
                    TrieuChungTxtBlock.Text = b.TrieuChung;
                }
                TienKhamTxtBlock.Text = "Tien kham: " + lk.TienKham.ToString();
                TienThuocTxtBlock.Text = "Tien thuoc: " + lk.TienThuoc.ToString();
                TongChiPhiTxtBlock.Text = "Tong chi phi: " + lk.ChiPhi.ToString();
                UserInfoTxtBlock.Text = bn.HoTen;
                Bussiness.listLuotThuoc.Clear();
                foreach (LuotThuoc lt in lk.LuotThuocs) Bussiness.listLuotThuoc.Add(lt);
                ThongTinLuotKhamTab.IsSelected = true;
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void HoaDonBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DSLuotKhamListView.SelectedIndex == -1) return;
                StringBuilder builder = new StringBuilder();
                LuotKham lk = LuotKhamDAO
                    .getLuotKhamBaseOnDateAndPatient(DateTime.Today.ToString("dd/MM/yyyy")
                    ,(DSLuotKhamListView.SelectedItem as BenhNhan).CMND);
                builder.Append("-----HOA DON THANH TOAN-----");
                builder.Append(Environment.NewLine);
                builder.Append("Thong tin benh nhan");
                builder.Append(Environment.NewLine);
                BenhNhan bn = BenhNhanDAO.getBenhNhan(lk.BenhNhan);
                builder.Append(">Ho ten: " + bn.HoTen);
                builder.Append(Environment.NewLine);
                builder.Append(">So CMND: " + bn.CMND);
                builder.Append(Environment.NewLine);
                builder.Append("Thong tin kham benh:");
                builder.Append(Environment.NewLine);
                builder.Append(">Ten benh: " + lk.Benh);
                builder.Append(Environment.NewLine);
                builder.Append("Ke toa thuoc:");
                builder.Append(Environment.NewLine);
                ICollection<LuotThuoc> list = lk.LuotThuocs;
                foreach (LuotThuoc lt in list)
                {
                    builder.Append(">");
                    builder.Append(lt.Thuoc);
                    Thuoc thuoc = ThuocDAO.getThuoc(lt.Thuoc);
                    builder.Append(" - ");
                    builder.Append(lt.SoLuong + " " + thuoc.DonVi);
                    builder.Append(" - ");
                    builder.Append(lt.ChiPhi + "VND");
                    builder.Append(Environment.NewLine);
                }
                builder.Append("---------------------------" + Environment.NewLine);
                builder.Append("Tien kham: " + lk.TienKham);
                builder.Append(" + Tien thuoc: " + lk.TienThuoc);
                builder.Append(Environment.NewLine);
                builder.Append("Tong chi phi: " + lk.ChiPhi);
                TextDialog dialog = new TextDialog("Hoa don", builder.ToString());
                dialog.ShowDialog();
            }catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void resetLuotKhamTab()
        {
            LuotKhamIDLabel.Content = "ID:";
            TienKhamTxtBlock.Text = "Tien kham: ";
            TienThuocTxtBlock.Text = "Tien thuoc: ";
            TongChiPhiTxtBlock.Text = "Tong chi phi: ";
            UserInfoTxtBlock.Text = "";
            Bussiness.listLuotThuoc.Clear();
            ThemLuotThuocTab.IsSelected = true;
            ThongTinLuotKhamTab.IsEnabled = false;
        }

        private void LuotKhamRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DSLuotKhamListView.SelectedIndex == -1) return;
            resetLuotKhamTab();
            BenhNhan bn = DSLuotKhamListView.SelectedItem as BenhNhan;
            LuotKham lk = LuotKhamDAO.getLuotKhamBaseOnDateAndPatient(DateTime.Today.ToString("dd/MM/yyyy"), bn.CMND);
            Bussiness.removeLuotKham(lk.ID);
        }

        private void LichSuKhamBtn_Click(object sender, RoutedEventArgs e)
        {
            Bussiness.getLichSuKham(LichSuKhamTextBox.Text);
        }

        private void ThongKeDoanhThuBtn_Click(object sender, RoutedEventArgs e)
        {
            Bussiness.getThongKeDoanhThu(ThongKeDoanhThuTextBox.Text);
            double tongDoanhThu = 0;
            int tongSoBenhNhan = 0;
            foreach(ThongKeLuotKham tk in Bussiness.listThongKeLuotkham)
            {
                tongDoanhThu += tk.doanhThu;
                tongSoBenhNhan += tk.soBenhNhan;
            }
            DoanhThuThangTxtBlock.Text = "Tong doanh thu: " + tongDoanhThu + " - Tong luot kham: " + tongSoBenhNhan;
        }

        private void ThongKeThuocBtn_Click(object sender, RoutedEventArgs e)
        {
            Bussiness.getThongKeThuoc(ThongKeThuocTextBox.Text);
        }
        

        private void BenhComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bussiness.currentLuotKhamID == -1) return;
            if((BenhComboBox.SelectedItem as string).Equals("unidentified"))
            {
                Bussiness.updateLuotKham(Bussiness.currentLuotKhamID, "unidentified");
            }
            Benh benh = BenhDAO.getBenh(BenhComboBox.SelectedItem as string);
            TrieuChungTxtBlock.Text = benh.TrieuChung;
            Bussiness.updateLuotKham(Bussiness.currentLuotKhamID, benh.LoaiBenh);
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isObserve = false;
            if (Bussiness.currentLuotKhamID == -1) isObserve=true;
            LuotThuoc lt = new LuotThuoc();
            lt.LuotKham = Bussiness.currentLuotKhamID;
            lt.Thuoc = (ThemThuocListView.SelectedItem as Thuoc).TenThuoc;
            ThemLuotThuocDialog dialog = new ThemLuotThuocDialog(lt,isObserve);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    Bussiness.addLuotThuoc(lt.Thuoc, (int)lt.SoLuong);
                    LuotKham lk = LuotKhamDAO.getLuotKham(Bussiness.currentLuotKhamID);
                    TienKhamTxtBlock.Text = "Tien kham: " + lk.TienKham.ToString();
                    TienThuocTxtBlock.Text = "Tien thuoc: " + lk.TienThuoc.ToString();
                    TongChiPhiTxtBlock.Text = "Tong chi phi: " + lk.ChiPhi.ToString();
                    ThongTinLuotKhamTab.IsSelected = true;
                }
                catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void ThemThuocBtn_Click(object sender, RoutedEventArgs e)
        {
            Thuoc thuoc = new Thuoc();
            ThemThuocDialog dialog = new ThemThuocDialog(thuoc);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    int res = Bussiness.addOrUpdateThuoc(thuoc.TenThuoc, thuoc.DonVi, thuoc.CachDung, (double)thuoc.DonGia);
                }
                catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            }

        }

        private void ThemBenhBtn_Click(object sender, RoutedEventArgs e)
        {
            Benh benh = new Benh();
            ThemBenhDialog dialog = new ThemBenhDialog(benh,false);
            if (dialog.ShowDialog() == true)
            {
                int res = Bussiness.addOrUpdateBenh(benh.LoaiBenh, benh.TrieuChung);
                if(res==1)benhs.Add(benh.LoaiBenh);
            }
        }

        private void AddLuotThuocBtn_Click(object sender, RoutedEventArgs e)
        {
            ThemLuotThuocTab.IsSelected = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Bussiness.removeLuotThuoc((LuotThuocListView.SelectedItem as LuotThuoc).ID);
            LuotKham lk = LuotKhamDAO.getLuotKham(Bussiness.currentLuotKhamID);
            TienKhamTxtBlock.Text = "Tien kham: " + lk.TienKham.ToString();
            TienThuocTxtBlock.Text = "Tien thuoc: " + lk.TienThuoc.ToString();
            TongChiPhiTxtBlock.Text = "Tong chi phi: " + lk.ChiPhi.ToString();
        }

        private void SeeDetailBtn_Click(object sender, RoutedEventArgs e)
        {
            ThemLuotThuocDialog dialog = new ThemLuotThuocDialog(LuotThuocListView.SelectedItem as LuotThuoc,true);
            dialog.ShowDialog();
        }

        private void LichSuXemBNBtn_Click(object sender, RoutedEventArgs e)
        {
            BenhNhan bn = LuotKhamDAO.getLuotKham((LichSuKhamListView.SelectedItem as LuotKham).ID).BenhNhan1;
            ThemLuotKhamDialog dialog = new ThemLuotKhamDialog(bn, 2);
            dialog.ShowDialog();
        }

        private void LichSuXemBenhBtn_Click(object sender, RoutedEventArgs e)
        {
            Benh b = LuotKhamDAO.getLuotKham((LichSuKhamListView.SelectedItem as LuotKham).ID).Benh1;
            ThemBenhDialog dialog = new ThemBenhDialog(b, true);
            dialog.ShowDialog();
        }

        private void LichSuXemThuocBtn_Click(object sender, RoutedEventArgs e)
        {
            ICollection<LuotThuoc> list = LuotKhamDAO
                .getLuotKham((LichSuKhamListView.SelectedItem as LuotKham).ID).LuotThuocs;
            StringBuilder builder = new StringBuilder();
            builder.Append("Ke toa thuoc: ");
            builder.Append(Environment.NewLine);
            foreach(LuotThuoc lt in list)
            {
                builder.Append(">");
                builder.Append(lt.Thuoc);
                Thuoc thuoc = ThuocDAO.getThuoc(lt.Thuoc);
                builder.Append(" - ");
                builder.Append(lt.SoLuong + " "+thuoc.DonVi);
                builder.Append(" - ");
                builder.Append(lt.ChiPhi + " VND");
                builder.Append(Environment.NewLine);
            }
            TextDialog dialog = new TextDialog("Toa thuoc",builder.ToString());
            dialog.ShowDialog();
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            TextDialog dialog = 
                new TextDialog("Help","Phan mem quan ly phong kham"+Environment.NewLine
                +"Nguoi thuc hien: 1712518 - Nguyen Le Minh Khang");
            dialog.ShowDialog();
        }

        private void LichSuKhamTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Bussiness.getLichSuKham(LichSuKhamTextBox.Text);
            }
        }

        private void ThongKeDoanhThuTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Bussiness.getThongKeDoanhThu(ThongKeDoanhThuTextBox.Text);
                double tongDoanhThu = 0;
                int tongSoBenhNhan = 0;
                foreach (ThongKeLuotKham tk in Bussiness.listThongKeLuotkham)
                {
                    tongDoanhThu += tk.doanhThu;
                    tongSoBenhNhan += tk.soBenhNhan;
                }
                DoanhThuThangTxtBlock.Text = "Tong doanh thu: " + tongDoanhThu + " - Tong luot kham: " + tongSoBenhNhan;
            }
        }

        private void ThongKeThuocTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Bussiness.getThongKeThuoc(ThongKeThuocTextBox.Text);
            }
        }

        private void ChanDoanBenhBtn_Click(object sender, RoutedEventArgs e)
        {
            string temp = "";
            int index = 0;
            for (int i = 0; i < listTrieuChung.Count; i++)
            {
                if ((bool)listTrieuChung.ElementAt(i).IsChecked)
                {
                    if (index != 0) temp += " - ";
                    temp += listTrieuChung.ElementAt(i).Content;
                    index++;
                }
            }
            ChanDoanBenhTextBlock.Text = Bussiness.ChanDoanBenh(temp);
        }
        List<CheckBox> listTrieuChung = new List<CheckBox>();
        private void setUpTrieuChung()
        {
            for (int i = 0; i < Bussiness.trieuChung.Count; i++)
            {
                CheckBox box = new CheckBox();
                box.Content = Bussiness.trieuChung.ElementAt(i);
                listTrieuChung.Add(box);
                TrieuChungCheckBoxes.Children.Add(box);
            }
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Settings dialog = new Settings(listTrieuChung, TrieuChungCheckBoxes);
            dialog.ShowDialog();
        }
    }
}
