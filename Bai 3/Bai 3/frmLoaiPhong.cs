using System;
using System.Linq;
using System.Windows.Forms;
using Bai_3.Models;

namespace Bai_3
{
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new HomestayContext())
            {
                dgvLoaiPhong.DataSource = context.LoaiPhongs.Select(x => new
                {
                    x.MaLoai,
                    x.TenLoai,
                    x.GiaMoiDem,
                    x.MoTa
                }).ToList();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var context = new HomestayContext())
            {
                var loai = new LoaiPhong
                {
                    TenLoai = txtTenLoai.Text,
                    GiaMoiDem = decimal.TryParse(txtGia.Text, out var gia) ? gia : null,
                    MoTa = txtMoTa.Text
                };
                context.LoaiPhongs.Add(loai);
                context.SaveChanges();
            }
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow == null) return;
            int id = (int)dgvLoaiPhong.CurrentRow.Cells["MaLoai"].Value;
            using (var context = new HomestayContext())
            {
                var loai = context.LoaiPhongs.Find(id);
                if (loai != null)
                {
                    loai.TenLoai = txtTenLoai.Text;
                    loai.GiaMoiDem = decimal.TryParse(txtGia.Text, out var gia) ? gia : null;
                    loai.MoTa = txtMoTa.Text;
                    context.SaveChanges();
                }
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow == null) return;
            int id = (int)dgvLoaiPhong.CurrentRow.Cells["MaLoai"].Value;
            using (var context = new HomestayContext())
            {
                var loai = context.LoaiPhongs.Find(id);
                if (loai != null)
                {
                    context.LoaiPhongs.Remove(loai);
                    context.SaveChanges();
                }
            }
            LoadData();
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvLoaiPhong.Rows[e.RowIndex];
                txtTenLoai.Text = row.Cells["TenLoai"].Value?.ToString();
                txtGia.Text = row.Cells["GiaMoiDem"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
            }
        }
    }
}
