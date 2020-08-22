namespace QuanLyPhongKham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Benh")]
    public partial class Benh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Benh()
        {
            LuotKhams = new HashSet<LuotKham>();
            LoaiBenh = "unidentified";
            TrieuChung = "";
        }

        [Key]
        [StringLength(50)]
        public string LoaiBenh { get; set; }

        public string TrieuChung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotKham> LuotKhams { get; set; }
    }
}
