using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class ThongKeLuotThuoc : INotifyPropertyChanged
    {
        private string _tenthuoc { get; set; }
        private int _soluong { get; set; }
        private int _solandung { get; set; }
        public String tenThuoc
        {
            get
            {
                return _tenthuoc;
            }
            set
            {
                _tenthuoc = value;
                Notify("tenThuoc");
            }
        }
        public int soLuong
        {
            get
            {
                return _soluong;
            }
            set
            {
                _soluong = value;
                Notify("soLuong");
            }
        }
        public int soLanDung
        {
            get
            {
                return _solandung;
            }
            set
            {
                _solandung = value;
                Notify("soLanDung");
            }
        }

        public ThongKeLuotThuoc(String tenThuoc)
        {
            this._tenthuoc = tenThuoc;
            _soluong = 0;
            _solandung = 0;
        }

        public void getData(IList<LuotThuoc> lts)
        {
            if (lts == null) return;
            if (!lts.Any()) return;
            foreach (LuotThuoc lt in lts)
            {
                if (lt.Thuoc.CompareTo(tenThuoc) == 0)
                {
                    _solandung++;
                    _soluong += (int)lt.SoLuong;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string v)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(v));
        }
    }
}
