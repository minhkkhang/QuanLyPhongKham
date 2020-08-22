namespace QuanLyPhongKham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuotThuoc")]
    public partial class LuotThuoc : INotifyPropertyChanged
    {
        public LuotThuoc()
        {
            Thuoc = "";
            ID = -1;
            SoLuong = 0;
            LuotKham = -1;
            ChiPhi = 0;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Thuoc { get; set; }

        public int? SoLuong { get; set; }

        public int? LuotKham { get; set; }

        public double? ChiPhi { get; set; }

        public virtual LuotKham LuotKham1 { get; set; }

        public virtual Thuoc Thuoc1 { get; set; }

        [NotMapped]
        public string thuoc2
        {
            get
            {
                return Thuoc;
            }
            set
            {
                Notify("thuoc2");
            }
        }
        [NotMapped]
        public int soluong2
        {
            get
            {
                return (int)SoLuong;
            }
            set
            {
                SoLuong = value;
                Notify("soluong2");
            }
        }
        [NotMapped]
        public double chiphi2
        {
            get
            {
                return (double)ChiPhi;
            }
            set
            {
                ChiPhi = value;
                Notify("chiphi2");
            }
        }
        [NotMapped]
        public int id2
        {
            get
            {
                return ID;
            }
            set
            {
                Notify("id2");
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
