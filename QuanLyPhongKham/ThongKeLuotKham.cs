using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class ThongKeLuotKham : INotifyPropertyChanged
    {
        private string _date { get; set; }
        private int _sobenhnhan { get; set; }
        private double _doanhthu { get; set; }
        private double _tyle { get; set; }
        public String date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                Notify("date");
            }
        }
        public int soBenhNhan
        {
            get
            {
                return _sobenhnhan;
            }
            set
            {
                _sobenhnhan = value;
                Notify("soBenhNhan");
            }
        }

        public Double doanhThu
        {
            get
            {
                return _doanhthu;
            }
            set
            {
                _doanhthu = value;
                Notify("doanhThu");
            }
        }
        public double tyLe
        {
            get
            {
                return _tyle;
            }
            set
            {
                _tyle = value;
                Notify("tyLe");
            }
        }

        public ThongKeLuotKham(String date)
        {
            this._date = date;
            _sobenhnhan = 0;
            _doanhthu = 0;
            _tyle = 0;
        }
        public void getData(IList<LuotKham> lks)
        {
            if (lks == null) return;
            if (!lks.Any()) return;
            double sum = 0;
            foreach (LuotKham lk in lks) {
                if (lk.NgayKham.CompareTo(_date) == 0)
                {
                    _sobenhnhan++;
                    _doanhthu += (double)lk.TienKham + (double)lk.TienThuoc;
                }
                sum+= (double)lk.TienKham + (double)lk.TienThuoc;
            }
            _tyle = (_doanhthu / sum)*100;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string v)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(v));
        }
    }
}
