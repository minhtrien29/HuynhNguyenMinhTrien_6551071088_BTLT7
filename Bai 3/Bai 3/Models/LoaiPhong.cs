using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai_3.Models
{
    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        [Key]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? GiaMoiDem { get; set; }

        [StringLength(255)]
        public string? MoTa { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
