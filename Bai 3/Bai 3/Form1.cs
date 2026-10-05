using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bai_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_3
{
    public partial class Form1 : Form
    {
        private string currentImageName = "";
        private readonly string imageFolderPath = Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }
            LoadLoaiPhong();
            LoadData();
        }

        private void LoadLoaiPhong()
        {
            using (var context = new HomestayContext())
            {
                var loaiPhongs = context.LoaiPhongs.ToList();
                
                cmbLoaiPhong.DataSource = loaiPhongs;
                cmbLoaiPhong.DisplayMember = "TenLoai";
                cmbLoaiPhong.ValueMember = "MaLoai";

                var filterLoai = loaiPhongs.ToList();
                filterLoai.Insert(0, new LoaiPhong { MaLoai = 0, TenLoai = "Tất cả" });
                cmbLocLoaiPhong.DataSource = filterLoai;
                cmbLocLoaiPhong.DisplayMember = "TenLoai";
                cmbLocLoaiPhong.ValueMember = "MaLoai";
                
                if (cmbLocTinhTrang.Items.Count > 0)
                {
                    cmbLocTinhTrang.SelectedIndex = 0;
                }
            }
        }

        private void LoadData(int? loaiId = 0, string tinhTrang = "Tất cả")
        {
            using (var context = new HomestayContext())
            {
                var query = context.Phongs.Include(p => p.LoaiPhongNavigation).AsQueryable();

                if (loaiId.HasValue && loaiId.Value > 0)
                {
                    query = query.Where(p => p.MaLoai == loaiId.Value);
                }

                if (!string.IsNullOrEmpty(tinhTrang) && tinhTrang != "Tất cả")
                {
                    query = query.Where(p => p.TinhTrang == tinhTrang);
                }

                var phongs = query.ToList();

                dgvPhong.DataSource = phongs.Select(p => new
                {
                    p.MaPhong,
                    Anh = GetImage(p.HinhAnh),
                    p.SoPhong,
                    p.TangSo,
                    LoaiPhong = p.LoaiPhongNavigation?.TenLoai,
                    GiaMoiDem = p.LoaiPhongNavigation?.GiaMoiDem,
                    p.TinhTrang,
                    p.HinhAnh
                }).ToList();

                if (dgvPhong.Columns["Anh"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                
                if(dgvPhong.Columns["HinhAnh"] != null)
                {
                    dgvPhong.Columns["HinhAnh"].Visible = false;
                }
                if(dgvPhong.Columns["MaPhong"] != null)
                {
                    dgvPhong.Columns["MaPhong"].Visible = false;
                }
            }
        }

        private Image GetImage(string imageName)
        {
            if (string.IsNullOrEmpty(imageName)) return null;
            string path = Path.Combine(imageFolderPath, imageName);
            if (File.Exists(path))
            {
                try
                {
                    using (var ms = new MemoryStream(File.ReadAllBytes(path)))
                    {
                        return Image.FromStream(ms);
                    }
                }
                catch { return null; }
            }
            return null;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImageName = Path.GetFileName(ofd.FileName);
                    string destPath = Path.Combine(imageFolderPath, currentImageName);
                    
                    if (!File.Exists(destPath))
                    {
                        File.Copy(ofd.FileName, destPath);
                    }
                    
                    picHinhAnh.Image = GetImage(currentImageName);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng.");
                return;
            }

            using (var context = new HomestayContext())
            {
                var phong = new Phong
                {
                    SoPhong = txtSoPhong.Text,
                    TangSo = (int)numTangSo.Value,
                    MaLoai = Convert.ToInt32(cmbLoaiPhong.SelectedValue),
                    TinhTrang = cmbTinhTrang.SelectedItem?.ToString(),
                    HinhAnh = currentImageName
                };
                context.Phongs.Add(phong);
                context.SaveChanges();
            }
            btnLamMoi_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            if (cmbLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng.");
                return;
            }
            
            int id = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaPhong"].Value);
            using (var context = new HomestayContext())
            {
                var phong = context.Phongs.Find(id);
                if (phong != null)
                {
                    phong.SoPhong = txtSoPhong.Text;
                    phong.TangSo = (int)numTangSo.Value;
                    phong.MaLoai = Convert.ToInt32(cmbLoaiPhong.SelectedValue);
                    phong.TinhTrang = cmbTinhTrang.SelectedItem?.ToString();
                    phong.HinhAnh = currentImageName;
                    context.SaveChanges();
                }
            }
            btnTimKiem_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaPhong"].Value);
            using (var context = new HomestayContext())
            {
                var phong = context.Phongs.Find(id);
                if (phong != null)
                {
                    context.Phongs.Remove(phong);
                    context.SaveChanges();
                }
            }
            btnTimKiem_Click(sender, e);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSoPhong.Clear();
            numTangSo.Value = 0;
            if (cmbLoaiPhong.Items.Count > 0) cmbLoaiPhong.SelectedIndex = 0;
            if (cmbTinhTrang.Items.Count > 0) cmbTinhTrang.SelectedIndex = 0;
            picHinhAnh.Image = null;
            currentImageName = "";
            btnTimKiem_Click(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int loaiId = cmbLocLoaiPhong.SelectedValue != null ? Convert.ToInt32(cmbLocLoaiPhong.SelectedValue) : 0;
            string tinhTrang = cmbLocTinhTrang.SelectedItem?.ToString() ?? "Tất cả";
            LoadData(loaiId, tinhTrang);
        }

        private void btnQuanLyLoai_Click(object sender, EventArgs e)
        {
            frmLoaiPhong f = new frmLoaiPhong();
            f.ShowDialog();
            LoadLoaiPhong();
            btnTimKiem_Click(sender, e);
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhong.Rows[e.RowIndex];
                txtSoPhong.Text = row.Cells["SoPhong"].Value?.ToString();
                if (int.TryParse(row.Cells["TangSo"].Value?.ToString(), out int tang))
                {
                    numTangSo.Value = tang;
                }
                
                string tenLoai = row.Cells["LoaiPhong"].Value?.ToString();
                foreach (LoaiPhong item in cmbLoaiPhong.Items)
                {
                    if (item.TenLoai == tenLoai)
                    {
                        cmbLoaiPhong.SelectedItem = item;
                        break;
                    }
                }
                
                if (cmbTinhTrang.Items.Contains(row.Cells["TinhTrang"].Value?.ToString()))
                {
                    cmbTinhTrang.SelectedItem = row.Cells["TinhTrang"].Value?.ToString();
                }
                
                currentImageName = row.Cells["HinhAnh"].Value?.ToString();
                picHinhAnh.Image = GetImage(currentImageName);
            }
        }
    }
}
