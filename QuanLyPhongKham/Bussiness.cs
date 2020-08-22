using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyPhongKham
{
    class Bussiness
    {
        public static List<int> daysOfMonth = new List<int>() { 31, 28,31,30,31,30,31,31,30,31,30,31 };
        public static double tienKham=100000;
        public static int gioiHanLuotKham=20;
        public static BindingList<BenhNhan> listBenhNhan;
        public static IList<Benh> listAllBenh;
        public static IList<Thuoc> listAllThuoc;
        public static BindingList<Thuoc> bindingListAllThuoc = new BindingList<Thuoc>();
        public static BindingList<LuotThuoc> listLuotThuoc=new BindingList<LuotThuoc>();
        public static BindingList<LuotKham> listLuotKhamTrongNgay;
        public static BindingList<ThongKeLuotKham> listThongKeLuotkham;
        public static BindingList<ThongKeLuotThuoc> listThongKeLuotThuoc;
        public static int currentLKID, currentLTID;
        public static int currentLuotKhamID=-1;
        public static IList<string> donViThuoc;
        public static IList<string> trieuChung;

        public static void init()
        {
            readSettings();
            listAllBenh = BenhDAO.getAllList();
            if (!listAllBenh.Any())
            {
                BenhDAO.addOrUpdateBenh("unidentified", new QuanLyPhongKham.Benh());
                listAllBenh.Add(new Benh());
            }
            listAllThuoc = ThuocDAO.getAllList();
            foreach (Thuoc t in listAllThuoc) bindingListAllThuoc.Add(t);
            IList<LuotKham> list = LuotKhamDAO.getAllLuotKhamOfCurrentDay();
            listBenhNhan = new BindingList<BenhNhan>();
            if (list.Any())
            {
                for(int i = 0; i < list.Count; i++)
                {
                    listBenhNhan.Add(list.ElementAt(i).BenhNhan1);
                }
            }
            listLuotKhamTrongNgay = new BindingList<LuotKham>();
            listThongKeLuotkham = new BindingList<ThongKeLuotKham>();
            listThongKeLuotThuoc = new BindingList<ThongKeLuotThuoc>();
        }

        public static void saveSettings()
        {
            string[] lines = new string[4];
            lines[0]= "Tien kham - " + tienKham.ToString();
            lines[1] = "Gioi han luot kham - " + gioiHanLuotKham.ToString();
            lines[2]= "Don vi thuoc - ";
            for (int i = 0; i < donViThuoc.Count; i++)
            {
                lines[2] += donViThuoc.ElementAt(i);
                if (i != donViThuoc.Count - 1) lines[2] += " - ";
            }
            lines[3] = "Trieu chung - ";
            for (int i = 0; i < trieuChung.Count; i++)
            {
                lines[3] += trieuChung.ElementAt(i);
                if (i != trieuChung.Count - 1) lines[3] += " - ";
            }
            File.WriteAllLines("setting.txt", lines);
        }
        public static void readSettings()
        {
            try
            {
                string[] lines= System.IO.File.ReadAllLines("setting.txt");
                for(int i = 0; i < lines.Count(); i++)
                {
                    string[] tokens = lines[i].Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0].Equals("Tien kham")) tienKham = double.Parse(tokens[1]);
                    if (tokens[0].Equals("Gioi han luot kham")) gioiHanLuotKham = int.Parse(tokens[1]);
                    if (tokens[0].Equals("Don vi thuoc"))
                    {
                        donViThuoc = new List<string>();
                        donViThuoc.Add("");
                        for (int j = 1; j < tokens.Count(); j++)
                        {
                            donViThuoc.Add(tokens[j]);
                        }
                    }
                    if (tokens[0].Equals("Trieu chung"))
                    {
                        trieuChung = new List<string>();
                        for (int j = 1; j < tokens.Count(); j++)
                        {
                            trieuChung.Add(tokens[j]);
                        }
                    }
                }
                currentLKID = LuotKhamDAO.getLatestID() + 1;
                currentLTID = LuotThuocDAO.getLatestID() + 1;
            }
            catch (Exception e)
            {
                // thong bao loi.
                donViThuoc = new List<string>();
                donViThuoc.Add("Vien");
                donViThuoc.Add("Vi thuoc 6 vien");
                donViThuoc.Add("Hop");
                trieuChung = new List<string>();
                trieuChung.Add("Khó thở");
                trieuChung.Add("Nghẹn ở họng và lồng ngực.");
                trieuChung.Add("Chóng mặt");
                trieuChung.Add("Co giật");
                trieuChung.Add("Nôn mửa, buồn nôn");
                trieuChung.Add("Đau bụng");
                trieuChung.Add("Đau cơ");
                trieuChung.Add("Cơ thể cảm thấy đau nhức nhẹ");
                saveSettings();
            }
        }
        public static int addOrUpdateThuoc(string tenthuoc,string donvi,string cachdung, double dongia)
        {
            Thuoc thuoc = ThuocDAO.getThuoc(tenthuoc);
            if(thuoc==null) thuoc = new QuanLyPhongKham.Thuoc();
            thuoc.TenThuoc = tenthuoc;
            thuoc.DonVi = donvi;
            thuoc.DonGia = dongia;
            thuoc.CachDung = cachdung;
            int res= ThuocDAO.addOrUpdateThuoc(tenthuoc,thuoc);
            if (res == 1)
            {
                bindingListAllThuoc.Add(thuoc);
                listAllThuoc.Add(thuoc);
            }
            if (res == 0)
            {
                foreach(Thuoc t in bindingListAllThuoc)
                {
                    if (t.TenThuoc.Equals(tenthuoc))
                    {
                        t.DonVi = donvi;
                        t.DonGia = dongia;
                        t.CachDung = cachdung;
                    }
                }
                foreach (Thuoc t in listAllThuoc)
                {
                    if (t.TenThuoc.Equals(tenthuoc))
                    {
                        t.DonVi = donvi;
                        t.DonGia = dongia;
                        t.CachDung = cachdung;
                    }
                }
            }
            return res;
        }
        public static int addOrUpdateBenh(string loaibenh,string trieuchung)
        {
            Benh benh = BenhDAO.getBenh(loaibenh);
            if(benh==null)benh = new QuanLyPhongKham.Benh();
            benh.LoaiBenh = loaibenh;
            benh.TrieuChung = trieuchung;
            int res = BenhDAO.addOrUpdateBenh(loaibenh, benh);
            if (res == 1)
            {
                listAllBenh.Add(benh);
            }
            if (res == 0)
            {
                foreach (Benh b in listAllBenh)
                {
                    if (b.LoaiBenh.Equals(loaibenh))
                    {
                        b.TrieuChung = trieuchung;
                    }
                }
            }
            return res;

        }
        public static int addOrUpdateBenhNhan(string CMND,string hoten,string sdt,string diachi,byte gioitinh)
        {
            BenhNhan bn = BenhNhanDAO.getBenhNhan(CMND);
            foreach(BenhNhan b in listBenhNhan)
            {
                if (b.CMND.Equals(CMND))
                {
                    b.hoten1 = hoten;
                    b.sdt1 = sdt;
                    b.diachi1 = diachi;
                    b.gioitinh1 = gioitinh;
                }
            }
            if (bn == null) bn = new BenhNhan();
            bn.CMND = CMND;
            bn.HoTen = hoten;
            bn.SDT = sdt;
            bn.DiaChi = diachi;
            bn.GioiTinh = gioitinh;
            return BenhNhanDAO.addOrUpdateBenhNhan(CMND, bn);
        }
        public static bool addLuotKham(string benhnhan,string ngaykham)
        {
            LuotKham lk = new LuotKham();
            BenhNhan bn = BenhNhanDAO.getBenhNhan(benhnhan);
            lk.BenhNhan = benhnhan;
            lk.TienKham = tienKham;
            lk.TienThuoc = 0;
            lk.NgayKham = ngaykham;
            lk.ID = currentLKID++;
            listBenhNhan.Add(bn);
            return LuotKhamDAO.addLuotKham(lk);
        }
        public static bool removeLuotKham(int ID)
        {
            LuotKham lk = LuotKhamDAO.getLuotKham(ID);
            if (lk == null) return false;
            foreach(LuotThuoc lt in lk.LuotThuocs)
            {
                LuotThuocDAO.removeLuotThuoc(lt.ID);
            }

            BenhNhan temp=null;
            foreach(BenhNhan bn in listBenhNhan)
            {
                if (bn.CMND.Equals(lk.BenhNhan))
                {
                    temp = bn;break;
                }
            }
            listBenhNhan.Remove(temp);
            LuotKhamDAO.removeLuotKham(ID);
            if (currentLuotKhamID == ID) currentLuotKhamID = -1;
            return true;
        }
        public static void updateLuotKham(int ID,string benh)
        {
            LuotKham lk = LuotKhamDAO.getLuotKham(ID);
            if (lk == null) return;
            lk.Benh = benh;
            LuotKhamDAO.updateLuotKham(ID, lk);
            /*foreach (LuotThuoc lt in lk.LuotThuocs)
            {
                LuotKhamDAO.updateLuotKham(ID,lk);
            }*/
        }

        public static void addLuotThuoc(string thuoc,int soLuong)
        {
            if (currentLuotKhamID == -1) return;
            int check = -1;
            LuotKham lk;
            foreach (Thuoc th in listAllThuoc)
            {
                if (th.TenThuoc.Equals(thuoc))
                {
                    check = 0;
                    break;
                }
            }
            if (check == -1) return;
            else {
                lk = LuotKhamDAO.getLuotKham(currentLuotKhamID);
                IList<LuotThuoc> list = lk.LuotThuocs.ToList();
                foreach(LuotThuoc lth in list)
                {
                    if (lth.Thuoc.Equals(thuoc))
                    {
                        lk.TienThuoc += soLuong * ThuocDAO.getThuoc(thuoc).DonGia;
                        LuotKhamDAO.updateLuotKham(lk.ID, lk);
                        updateLuotThuoc(lth.ID, soLuong);
                        return;
                    }
                }
            }
            LuotThuoc lt = new LuotThuoc();
            lt.ID = currentLTID++;
            lt.LuotKham = currentLuotKhamID;
            lt.SoLuong = soLuong;
            lt.Thuoc = thuoc;
            lt.ChiPhi= lt.SoLuong * ThuocDAO.getThuoc(thuoc).DonGia;
            lk.TienThuoc += lt.ChiPhi;
            listLuotThuoc.Add(lt);
            LuotKhamDAO.updateLuotKham(lk.ID, lk);
            LuotThuocDAO.addLuotThuoc(lt);
        }

        public static bool removeLuotThuoc(int ID)
        {
            if (currentLuotKhamID == -1) return false;
            LuotKham lk = LuotKhamDAO.getLuotKham(currentLuotKhamID);

            LuotThuoc lt = LuotThuocDAO.getLuotThuoc(ID);
            if (lt == null) return false;
            lk.TienThuoc -= lt.ChiPhi;
            LuotKhamDAO.updateLuotKham(lk.ID, lk);
            foreach(LuotThuoc l in listLuotThuoc)
            {
                if (l.ID == ID)
                {
                    lt = l;
                    break;
                }
            }
            listLuotThuoc.Remove(lt);
            LuotThuocDAO.removeLuotThuoc(ID);
            return true;
        }
        public static void updateLuotThuoc(int ID,int soLuongThem)
        {
            if (currentLuotKhamID == -1) return;
            LuotThuoc lt = LuotThuocDAO.getLuotThuoc(ID);
            int index=-1;
            for (int i = 0; i < listLuotThuoc.Count; i++)
            {
                if (listLuotThuoc.ElementAt(i).ID == ID) index = i;
            }
            if (index == -1 || lt==null) return;
            lt.SoLuong += soLuongThem;
            lt.ChiPhi+= soLuongThem * ThuocDAO.getThuoc(lt.Thuoc).DonGia;
            listLuotThuoc.ElementAt(index).soluong2 = (int)lt.SoLuong;
            listLuotThuoc.ElementAt(index).chiphi2 = (double)lt.ChiPhi;
            LuotThuocDAO.updateLuotThuoc(ID, lt);
        }
        public static void getLichSuKham(string date)
        {
            listLuotKhamTrongNgay.Clear();
            IList<LuotKham>list=LuotKhamDAO.getLuotKhamOfDate(date);
            for(int i = 0; i < list.Count; i++)
            {
                listLuotKhamTrongNgay.Add(list.ElementAt(i));
            }
        }
        public static bool getThongKeDoanhThu(string month)
        {
            IList<LuotKham> list = LuotKhamDAO.getLuotKhamOfMonth(month);
            listThongKeLuotkham.Clear();
            string[] tokens;
            int year;
            try
            {
                tokens = month.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0].Count() != 2 || tokens[1].Count() != 4) throw new Exception();
                int temp = int.Parse(tokens[0]);
                if (temp < 1 || temp > 12) throw new Exception();
                year = int.Parse(tokens[1]);
            }
            catch(Exception e) { MessageBox.Show("Thang khong hop le!"); return false; }
            if (!list.Any())
            {
                MessageBox.Show("Khong co du lieu trong thang nay!");
                return false;
            }
            int days = daysOfMonth.ElementAt(int.Parse(tokens[0])-1);
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) && tokens[0].Equals("02")) days++;
            
            for(int i = 1; i <= days; i++)
            {
                string day = i.ToString();
                if (day.Count() == 1) day = "0" + day;
                string date = day + "/" + month;
                ThongKeLuotKham tklk = new ThongKeLuotKham(date);
                tklk.getData(list);
                listThongKeLuotkham.Add(tklk);
            }
            return true;
        }

        public static bool getThongKeThuoc(string month)
        {
            IList<LuotThuoc> list = LuotThuocDAO.getLuotThuocOfMonth(month);
            listThongKeLuotThuoc.Clear();
            for(int i = 0; i < listAllThuoc.Count; i++)
            {
                ThongKeLuotThuoc tklt = new ThongKeLuotThuoc(listAllThuoc.ElementAt(i).TenThuoc);
                tklt.getData(list);
                listThongKeLuotThuoc.Add(tklt);
            }
            return true;
        }

        public static string ChanDoanBenh(string trieuchung)
        {
            string res = "Cac benh lien quan: ";
            string[] tokens = trieuchung.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            IList<Benh> list=BenhDAO.getAllList();
            int index = 0;
            foreach(Benh b in list)
            {
                bool check = true;
                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (!b.TrieuChung.Contains(tokens[i]))
                    {
                        check = false;
                        break;
                    }
                }
                if (check) {
                    if (index != 0) res += ", ";
                    res += b.LoaiBenh;
                    index++;
                }
            }
            
            return res;
        }
    }
}
