using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_2
{
    public partial class Form1 : Form
    {
        private readonly FitZoneGymContext context = new();
        private bool _isLoading = false;
        private int? _selectedMaHV = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            cboHangThanhVien.SelectedIndex = 0; // Mặc định là Basic
            cboLocHangThanhVien.SelectedIndex = 0; // Mặc định là "Tất cả"
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            await LoadDataAsync();
        }

        /// <summary>
        /// Tải toàn bộ danh sách hội viên lên DataGridView
        /// </summary>
        private async Task LoadDataAsync(int? selectedId = null)
        {
            try
            {
                _isLoading = true;
                var list = await context.HoiViens
                    .AsNoTracking()
                    .OrderBy(hv => hv.MaHv)
                    .ToListAsync();

                dgvHoiVien.AutoGenerateColumns = false;
                dgvHoiVien.DataSource = list;
                _isLoading = false;

                if (list.Count > 0)
                {
                    int targetRowIndex = 0;
                    if (selectedId.HasValue)
                    {
                        for (int i = 0; i < dgvHoiVien.Rows.Count; i++)
                        {
                            if (dgvHoiVien.Rows[i].DataBoundItem is HoiVien item && item.MaHv == selectedId.Value)
                            {
                                targetRowIndex = i;
                                break;
                            }
                        }
                    }

                    dgvHoiVien.ClearSelection();
                    dgvHoiVien.Rows[targetRowIndex].Selected = true;
                    dgvHoiVien.CurrentCell = dgvHoiVien.Rows[targetRowIndex].Cells[0];
                    DisplaySelectedRow();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                _isLoading = false;
                MessageBox.Show("Lỗi khi tải dữ liệu hội viên: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Định dạng hiển thị các cột đặc biệt trên DataGridView (Giới tính, Ngày sinh, Trạng thái)
        /// </summary>
        private void dgvHoiVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoiVien.Rows.Count)
                return;

            string colName = dgvHoiVien.Columns[e.ColumnIndex].Name;

            if (colName == "colGioiTinh" && e.Value is bool bGioiTinh)
            {
                e.Value = bGioiTinh ? "Nam" : "Nữ";
                e.FormattingApplied = true;
            }
            else if (colName == "colNgaySinh" && e.Value is DateOnly dNgaySinh)
            {
                e.Value = dNgaySinh.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
            else if (colName == "colTrangThai" && e.Value is bool bTrangThai)
            {
                e.Value = bTrangThai ? "Đang hoạt động" : "Tạm ngưng";
                e.FormattingApplied = true;
            }
        }

        /// <summary>
        /// Đổ dữ liệu dòng đang chọn lên tất cả các control nhập liệu (TextBox, RadioButton, DateTimePicker, ComboBox, CheckBox)
        /// </summary>
        private void DisplaySelectedRow()
        {
            if (_isLoading || dgvHoiVien.CurrentRow == null || dgvHoiVien.CurrentRow.Index < 0)
                return;

            if (dgvHoiVien.CurrentRow.DataBoundItem is HoiVien hv)
            {
                _selectedMaHV = hv.MaHv;
                txtHoTen.Text = hv.HoTen;
                txtSDT.Text = hv.Sdt ?? "";
                txtEmail.Text = hv.Email ?? "";

                // Giới tính -> RadioButton
                if (hv.GioiTinh)
                    radNam.Checked = true;
                else
                    radNu.Checked = true;

                // Ngày sinh -> DateTimePicker
                dtpNgaySinh.Value = hv.NgaySinh.ToDateTime(TimeOnly.MinValue);

                // Hạng thành viên -> ComboBox
                cboHangThanhVien.SelectedItem = hv.HangThanhVien;

                // Trạng thái -> CheckBox
                chkTrangThai.Checked = hv.TrangThai;
            }
        }

        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            DisplaySelectedRow();
        }

        /// <summary>
        /// Xóa trắng các ô nhập liệu và reset về mặc định
        /// </summary>
        private void ClearInputs()
        {
            _selectedMaHV = null;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            radNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            cboHangThanhVien.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            dgvHoiVien.ClearSelection();
            txtHoTen.Focus();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu đầu vào theo từng trường cụ thể
        /// </summary>
        private bool ValidateInputs()
        {
            // 1. Kiểm tra Họ tên không được để trống
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên hội viên!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // 2. Kiểm tra SDT: chỉ chứa chữ số và đủ 9-11 ký tự
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (!Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! SĐT chỉ chứa các chữ số và có độ dài từ 9 đến 11 ký tự.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // 3. Kiểm tra Email: phải chứa ký tự '@'
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Email không hợp lệ! Địa chỉ email phải chứa ký tự '@' và tên miền hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // 4. Kiểm tra tuổi hội viên: từ 15 tuổi trở lên tính đến thời điểm hiện tại
            DateTime birthDate = dtpNgaySinh.Value.Date;
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;

            if (age < 15)
            {
                MessageBox.Show($"Hội viên hiện tại {age} tuổi. Quy định phải từ 15 tuổi trở lên mới được đăng ký tập luyện tại FitZone!", "Không đủ tuổi quy định", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            // 5. Kiểm tra Hạng thành viên
            if (cboHangThanhVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hạng thành viên!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangThanhVien.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Chức năng Thêm mới hội viên
        /// </summary>
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                var newHoiVien = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cboHangThanhVien.SelectedItem!.ToString()!,
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                context.Add(newHoiVien);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm mới hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync(selectedId: newHoiVien.MaHv);
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Lỗi khi thêm hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng Cập nhật thông tin hội viên
        /// </summary>
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!_selectedMaHV.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một hội viên từ danh sách để sửa!", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
                return;

            try
            {
                var hv = await context.HoiViens.FindAsync(_selectedMaHV.Value);
                if (hv == null)
                {
                    MessageBox.Show("Không tìm thấy hội viên này trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hv.HoTen = txtHoTen.Text.Trim();
                hv.GioiTinh = radNam.Checked;
                hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                hv.Sdt = txtSDT.Text.Trim();
                hv.Email = txtEmail.Text.Trim();
                hv.HangThanhVien = cboHangThanhVien.SelectedItem!.ToString()!;
                hv.TrangThai = chkTrangThai.Checked;

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync(selectedId: hv.MaHv);
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Lỗi khi cập nhật hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng Xóa hội viên có xác nhận Yes/No
        /// </summary>
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaHV.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một hội viên từ danh sách để xóa!", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenHoiVien = txtHoTen.Text;
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hội viên '{tenHoiVien}' (Mã: {_selectedMaHV.Value}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var hv = await context.HoiViens.FindAsync(_selectedMaHV.Value);
                if (hv == null)
                {
                    MessageBox.Show("Hội viên không tồn tại hoặc đã bị xóa trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadDataAsync();
                    return;
                }

                context.HoiViens.Remove(hv);
                await context.SaveChangesAsync();

                MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Lỗi khi xóa hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới các ô nhập liệu và nạp lại toàn bộ dữ liệu
        /// </summary>
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiemHoTen.Clear();
            cboLocHangThanhVien.SelectedIndex = 0; // "Tất cả"
            ClearInputs();
            await LoadDataAsync();
        }

        /// <summary>
        /// Tìm kiếm kết hợp 2 điều kiện cùng lúc bằng LINQ Where: Họ tên (Contains) && Hạng thành viên
        /// </summary>
        private async Task SearchDataAsync()
        {
            try
            {
                string keyword = txtTimKiemHoTen.Text.Trim();
                string rank = cboLocHangThanhVien.SelectedItem?.ToString() ?? "Tất cả";

                var query = context.HoiViens.AsNoTracking().AsQueryable();

                // Minh họa LINQ Where kết hợp nhiều điều kiện bằng toán tử &&
                query = query.Where(hv =>
                    (string.IsNullOrEmpty(keyword) || hv.HoTen.Contains(keyword)) &&
                    (rank == "Tất cả" || hv.HangThanhVien == rank)
                );

                _isLoading = true;
                var list = await query.OrderBy(hv => hv.MaHv).ToListAsync();
                dgvHoiVien.DataSource = list;
                _isLoading = false;

                if (list.Count > 0)
                {
                    dgvHoiVien.ClearSelection();
                    dgvHoiVien.Rows[0].Selected = true;
                    dgvHoiVien.CurrentCell = dgvHoiVien.Rows[0].Cells[0];
                    DisplaySelectedRow();
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                _isLoading = false;
                MessageBox.Show("Lỗi khi tìm kiếm hội viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            await SearchDataAsync();
        }

        private async void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SearchDataAsync();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
