using System;
using System.Linq;
using System.Windows.Forms;
using Bai_4.Models;

namespace Bai_4
{
    public class FormBacSi : Form
    {
        private DataGridView dgvBacSi;
        private TextBox txtHoTen, txtChuyenKhoa, txtSDT;
        private Button btnThem, btnSua, btnXoa;
        private int selectedMaBS = -1;

        public FormBacSi()
        {
            Text = "Quản lý Bác sĩ";
            Size = new System.Drawing.Size(800, 450);
            StartPosition = FormStartPosition.CenterParent;
            
            Label lblHoTen = new Label() { Text = "Họ tên:", Left = 20, Top = 20, Width = 80 };
            txtHoTen = new TextBox() { Left = 100, Top = 20, Width = 200 };
            
            Label lblChuyenKhoa = new Label() { Text = "Chuyên khoa:", Left = 20, Top = 50, Width = 80 };
            txtChuyenKhoa = new TextBox() { Left = 100, Top = 50, Width = 200 };
            
            Label lblSDT = new Label() { Text = "SĐT:", Left = 20, Top = 80, Width = 80 };
            txtSDT = new TextBox() { Left = 100, Top = 80, Width = 200 };
            
            btnThem = new Button() { Text = "Thêm", Left = 20, Top = 120, Width = 80 };
            btnSua = new Button() { Text = "Sửa", Left = 110, Top = 120, Width = 80 };
            btnXoa = new Button() { Text = "Xóa", Left = 200, Top = 120, Width = 80 };
            
            dgvBacSi = new DataGridView() { Left = 350, Top = 20, Width = 400, Height = 350, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvBacSi.CellClick += DgvBacSi_CellClick;

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;

            Controls.Add(lblHoTen); Controls.Add(txtHoTen);
            Controls.Add(lblChuyenKhoa); Controls.Add(txtChuyenKhoa);
            Controls.Add(lblSDT); Controls.Add(txtSDT);
            Controls.Add(btnThem); Controls.Add(btnSua); Controls.Add(btnXoa);
            Controls.Add(dgvBacSi);

            LoadData();
        }

        private void LoadData()
        {
            using (var context = new AnKhangClinicContext())
            {
                var list = context.BacSis.Select(b => new { b.MaBs, b.HoTen, b.ChuyenKhoa, b.Sdt }).ToList();
                dgvBacSi.DataSource = list;
            }
        }

        private void DgvBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBacSi.Rows[e.RowIndex];
                selectedMaBS = Convert.ToInt32(row.Cells["MaBs"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value?.ToString();
                txtSDT.Text = row.Cells["Sdt"].Value?.ToString();
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }
            using (var context = new AnKhangClinicContext())
            {
                var bs = new BacSi { HoTen = txtHoTen.Text, ChuyenKhoa = txtChuyenKhoa.Text, Sdt = txtSDT.Text };
                context.BacSis.Add(bs);
                context.SaveChanges();
                LoadData();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaBS == -1) return;
            using (var context = new AnKhangClinicContext())
            {
                var bs = context.BacSis.Find(selectedMaBS);
                if (bs != null)
                {
                    bs.HoTen = txtHoTen.Text;
                    bs.ChuyenKhoa = txtChuyenKhoa.Text;
                    bs.Sdt = txtSDT.Text;
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaBS == -1) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var context = new AnKhangClinicContext())
                {
                    var bs = context.BacSis.Find(selectedMaBS);
                    if (bs != null)
                    {
                        context.BacSis.Remove(bs);
                        context.SaveChanges();
                        LoadData();
                        selectedMaBS = -1;
                    }
                }
            }
        }
    }
}
