using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai_3.Models
{
    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        public int MaPhong { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string SoPhong { get; set; } = null!;

        public int? TangSo { get; set; }

        [StringLength(20)]
        public string? TinhTrang { get; set; }

        [StringLength(255)]
        public string? HinhAnh { get; set; }

        public int? MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        [InverseProperty("Phongs")]
        public virtual LoaiPhong? LoaiPhongNavigation { get; set; }
    }
}
