namespace QuanLyPhongKham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuotKham")]
    public partial class LuotKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LuotKham()
        {
            LuotThuocs = new HashSet<LuotThuoc>();
            TienThuoc = 0;
            TienKham = 0;
            ID = -1;
            BenhNhan = "";
            NgayKham = "00/00/0000";
            Benh = "unidentified";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(20)]
        public string BenhNhan { get; set; }

        [StringLength(12)]
        public string NgayKham { get; set; }

        [StringLength(50)]
        public string Benh { get; set; }

        public double? TienThuoc { get; set; }

        public double? TienKham { get; set; }

        public virtual Benh Benh1 { get; set; }

        public virtual BenhNhan BenhNhan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotThuoc> LuotThuocs { get; set; }

        [NotMapped]
        public double ChiPhi
        {
            get
            {
                return (double)TienThuoc + (double)TienKham;
            }
        }
    }
}
