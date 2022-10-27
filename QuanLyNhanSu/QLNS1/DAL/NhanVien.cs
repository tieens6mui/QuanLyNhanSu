//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.baoHiems = new HashSet<baoHiem>();
            this.ChamCongs = new HashSet<ChamCong>();
            this.HopDongs = new HashSet<HopDong>();
            this.Luongs = new HashSet<Luong>();
        }
    
        public int maNV { get; set; }
        public string tenNV { get; set; }
        public string gioiTinh { get; set; }
        public System.DateTime ngaySinh { get; set; }
        public string queQuan { get; set; }
        public string sDT { get; set; }
        public string diaChi { get; set; }
        public string cmnd { get; set; }
        public string email { get; set; }
        public string maPhong { get; set; }
        public string maBP { get; set; }
        public string maHV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baoHiem> baoHiems { get; set; }
        public virtual BoPhan BoPhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual HocVan HocVan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}