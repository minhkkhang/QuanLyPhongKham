namespace QuanLyPhongKham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            LuotThuocs = new HashSet<LuotThuoc>();
            TenThuoc = "";
            DonVi = "";
            CachDung = "";
            DonGia = 0;
        }

        [Key]
        [StringLength(50)]
        public string TenThuoc { get; set; }

        [StringLength(15)]
        public string DonVi { get; set; }

        public string CachDung { get; set; }

        public double? DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotThuoc> LuotThuocs { get; set; }
    }
}
