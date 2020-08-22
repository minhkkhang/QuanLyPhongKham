namespace QuanLyPhongKham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BenhNhan")]
    public partial class BenhNhan : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BenhNhan()
        {
            LuotKhams = new HashSet<LuotKham>();
            CMND = "";
            HoTen = "";
            GioiTinh = 1;
            SDT = "";
            DiaChi = "";
        }

        [Key]
        [StringLength(20)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public byte? GioiTinh { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotKham> LuotKhams { get; set; }


        [NotMapped]
        public string cmnd1
        {
            get
            {
                return CMND;
            }
            set
            {
                CMND = value;
                Notify("cmnd1");
            }
        }
        [NotMapped]
        public string hoten1
        {
            get
            {
                return HoTen;
            }
            set
            {
                HoTen = value;
                Notify("hoten1");
            }
        }
        [NotMapped]
        public string sdt1
        {
            get
            {
                return SDT;
            }
            set
            {
                SDT = value;
                Notify("sdt1");
            }
        }
        [NotMapped]
        public string diachi1
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
                Notify("diachi1");
            }
        }
        [NotMapped]
        public byte gioitinh1
        {
            get
            {
                return (byte)GioiTinh;
            }
            set
            {
                GioiTinh = value;
                Notify("diachi1");
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
