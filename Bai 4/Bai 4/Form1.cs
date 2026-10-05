using System;
using System.Linq;
using System.Windows.Forms;
using Bai_4.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_4
{
    public partial class Form1 : Form
    {
        private TextBox txtTenBN, txtSDT;
        private DateTimePicker dtpNgayKham, dtpGioKham, dtpTuNgay, dtpDenNgay;
        private ComboBox cbBacSi, cbTrangThai, cbSearchBacSi;
        private Button btnThem, btnSua, btnXoa, btnTimKiem, btnQuanLyBS, btnReset;
        private DataGridView dgvLichKham;
        private int selectedMaLich = -1;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Lịch khám - An Khang Clinic";
            this.Size = new System.Drawing.Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Xóa controls mặc định nếu có
            this.Controls.Clear();

            int left1 = 20, left2 = 120, top = 20, step = 30;

            this.Controls.Add(new Label() { Text = "Tên BN:", Left = left1, Top = top, Width = 80 });
            txtTenBN = new TextBox() { Left = left2, Top = top, Width = 200 };
            this.Controls.Add(txtTenBN);
            top += step;

            this.Controls.Add(new Label() { Text = "SĐT:", Left = left1, Top = top, Width = 80 });
            txtSDT = new TextBox() { Left = left2, Top = top, Width = 200 };
            this.Controls.Add(txtSDT);
            top += step;

            this.Controls.Add(new Label() { Text = "Ngày khám:", Left = left1, Top = top, Width = 80 });
            dtpNgayKham = new DateTimePicker() { Left = left2, Top = top, Width = 200, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpNgayKham);
            top += step;

            this.Controls.Add(new Label() { Text = "Giờ khám:", Left = left1, Top = top, Width = 80 });
            dtpGioKham = new DateTimePicker() { Left = left2, Top = top, Width = 200, Format = DateTimePickerFormat.Time, ShowUpDown = true };
            this.Controls.Add(dtpGioKham);
            top += step;

            this.Controls.Add(new Label() { Text = "Bác sĩ:", Left = left1, Top = top, Width = 80 });
            cbBacSi = new ComboBox() { Left = left2, Top = top, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cbBacSi);
            
            btnQuanLyBS = new Button() { Text = "...", Left = left2 + 210, Top = top, Width = 30 };
            btnQuanLyBS.Click += (s, e) => { new FormBacSi().ShowDialog(); LoadCombos(); };
            this.Controls.Add(btnQuanLyBS);
            top += step;

            this.Controls.Add(new Label() { Text = "Trạng thái:", Left = left1, Top = top, Width = 80 });
            cbTrangThai = new ComboBox() { Left = left2, Top = top, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbTrangThai.Items.AddRange(new string[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cbTrangThai.SelectedIndex = 0;
            this.Controls.Add(cbTrangThai);
            top += step + 10;

            btnThem = new Button() { Text = "Thêm", Left = left1, Top = top, Width = 80 };
            btnSua = new Button() { Text = "Sửa", Left = left1 + 90, Top = top, Width = 80 };
            btnXoa = new Button() { Text = "Xóa", Left = left1 + 180, Top = top, Width = 80 };
            btnReset = new Button() { Text = "Làm mới", Left = left1 + 270, Top = top, Width = 80 };
            this.Controls.Add(btnThem); this.Controls.Add(btnSua); this.Controls.Add(btnXoa); this.Controls.Add(btnReset);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += async (s, e) => await BtnXoa_ClickAsync();
            btnReset.Click += (s, e) => LoadData();

            // Search area
            int searchLeft = 400;
            this.Controls.Add(new Label() { Text = "Từ ngày:", Left = searchLeft, Top = 20, Width = 60 });
            dtpTuNgay = new DateTimePicker() { Left = searchLeft + 60, Top = 20, Width = 100, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpTuNgay);

            this.Controls.Add(new Label() { Text = "Đến ngày:", Left = searchLeft + 170, Top = 20, Width = 60 });
            dtpDenNgay = new DateTimePicker() { Left = searchLeft + 230, Top = 20, Width = 100, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpDenNgay);

            this.Controls.Add(new Label() { Text = "Bác sĩ:", Left = searchLeft + 340, Top = 20, Width = 50 });
            cbSearchBacSi = new ComboBox() { Left = searchLeft + 390, Top = 20, Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cbSearchBacSi);

            btnTimKiem = new Button() { Text = "Tìm kiếm", Left = searchLeft + 520, Top = 18, Width = 80 };
            btnTimKiem.Click += BtnTimKiem_Click;
            this.Controls.Add(btnTimKiem);

            // DGV
            dgvLichKham = new DataGridView() { Left = searchLeft, Top = 60, Width = 560, Height = 450, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvLichKham.CellClick += DgvLichKham_CellClick;
            this.Controls.Add(dgvLichKham);
        }

        private void LoadCombos()
        {
            using (var context = new AnKhangClinicContext())
            {
                var bacsis = context.BacSis.Select(b => new { b.MaBs, Display = "BS. " + b.HoTen + " - " + b.ChuyenKhoa }).ToList();
                
                cbBacSi.DataSource = bacsis.ToList();
                cbBacSi.DisplayMember = "Display";
                cbBacSi.ValueMember = "MaBs";

                var searchBacSis = bacsis.ToList();
                searchBacSis.Insert(0, new { MaBs = 0, Display = "Tất cả" });
                cbSearchBacSi.DataSource = searchBacSis;
                cbSearchBacSi.DisplayMember = "Display";
                cbSearchBacSi.ValueMember = "MaBs";
            }
        }

        private void LoadData()
        {
            using (var context = new AnKhangClinicContext())
            {
                var query = context.LichKhams.Include(x => x.MaBsNavigation).Select(l => new {
                    l.MaLich,
                    l.TenBenhNhan,
                    l.Sdt,
                    l.NgayKham,
                    l.GioKham,
                    TrangThai = l.TrangThai,
                    MaBs = l.MaBs,
                    BacSi = "BS. " + l.MaBsNavigation.HoTen + " (" + l.MaBsNavigation.ChuyenKhoa + ")"
                }).ToList();
                dgvLichKham.DataSource = query;
                if(dgvLichKham.Columns.Contains("MaBs"))
                    dgvLichKham.Columns["MaBs"].Visible = false;
            }
        }

        private void DgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLichKham.Rows[e.RowIndex];
                selectedMaLich = Convert.ToInt32(row.Cells["MaLich"].Value);
                txtTenBN.Text = row.Cells["TenBenhNhan"].Value?.ToString();
                txtSDT.Text = row.Cells["Sdt"].Value?.ToString();
                
                if (row.Cells["NgayKham"].Value != null)
                {
                    if (row.Cells["NgayKham"].Value is DateOnly dateOnly)
                        dtpNgayKham.Value = dateOnly.ToDateTime(new TimeOnly(0, 0));
                    else
                        dtpNgayKham.Value = Convert.ToDateTime(row.Cells["NgayKham"].Value);
                }
                if (row.Cells["GioKham"].Value != null)
                {
                    DateTime time;
                    if (DateTime.TryParse(row.Cells["GioKham"].Value.ToString(), out time))
                        dtpGioKham.Value = time;
                }
                
                cbTrangThai.SelectedItem = row.Cells["TrangThai"].Value?.ToString();
                if(row.Cells["MaBs"].Value != null)
                    cbBacSi.SelectedValue = row.Cells["MaBs"].Value;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtTenBN.Text))
            {
                MessageBox.Show("Tên bệnh nhân không được để trống!");
                return false;
            }
            if (cbBacSi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ!");
                return false;
            }
            if (dtpNgayKham.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Không được đặt lịch khám vào ngày trong quá khứ!");
                return false;
            }
            return true;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            using (var context = new AnKhangClinicContext())
            {
                var lich = new LichKham
                {
                    TenBenhNhan = txtTenBN.Text,
                    Sdt = txtSDT.Text,
                    NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value.Date),
                    GioKham = dtpGioKham.Value.ToString("HH:mm"),
                    MaBs = (int)cbBacSi.SelectedValue,
                    TrangThai = cbTrangThai.SelectedItem.ToString()
                };
                context.LichKhams.Add(lich);
                context.SaveChanges();
                LoadData();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaLich == -1 || !ValidateData()) return;
            using (var context = new AnKhangClinicContext())
            {
                var lich = context.LichKhams.Find(selectedMaLich);
                if (lich != null)
                {
                    lich.TenBenhNhan = txtTenBN.Text;
                    lich.Sdt = txtSDT.Text;
                    lich.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value.Date);
                    lich.GioKham = dtpGioKham.Value.ToString("HH:mm");
                    lich.MaBs = (int)cbBacSi.SelectedValue;
                    lich.TrangThai = cbTrangThai.SelectedItem.ToString();
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private async System.Threading.Tasks.Task BtnXoa_ClickAsync()
        {
            if (selectedMaLich == -1) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch khám này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var context = new AnKhangClinicContext())
                {
                    var lich = await context.LichKhams.FindAsync(selectedMaLich);
                    if (lich != null)
                    {
                        context.LichKhams.Remove(lich);
                        await context.SaveChangesAsync();
                        LoadData();
                        selectedMaLich = -1;
                    }
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            using (var context = new AnKhangClinicContext())
            {
                var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
                
                int maBS = 0;
                if(cbSearchBacSi.SelectedValue != null)
                    maBS = (int)cbSearchBacSi.SelectedValue;

                var query = context.LichKhams.Include(x => x.MaBsNavigation)
                    .Where(l => l.NgayKham >= tuNgay && l.NgayKham <= denNgay);

                if (maBS != 0)
                {
                    query = query.Where(l => l.MaBs == maBS);
                }

                var list = query.Select(l => new {
                    l.MaLich,
                    l.TenBenhNhan,
                    l.Sdt,
                    l.NgayKham,
                    l.GioKham,
                    TrangThai = l.TrangThai,
                    MaBs = l.MaBs,
                    BacSi = "BS. " + l.MaBsNavigation.HoTen + " (" + l.MaBsNavigation.ChuyenKhoa + ")"
                }).ToList();

                dgvLichKham.DataSource = list;
            }
        }
    }
}
