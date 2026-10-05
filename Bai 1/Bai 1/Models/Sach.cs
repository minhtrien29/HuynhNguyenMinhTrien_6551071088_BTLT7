using System;
using System.Collections.Generic;

namespace Bai_1.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public int MaTl { get; set; }

    public virtual TheLoaiSach MaTlNavigation { get; set; } = null!;
}
