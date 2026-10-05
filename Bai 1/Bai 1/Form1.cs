using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai_1
{
    public partial class Form1 : Form
    {
        private readonly TriThucBooksContext context = new();
        private bool _isLoading = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        /// <summary>
        /// Tải toàn bộ danh sách thể loại sách và hiển thị lên DataGridView
        /// </summary>
        private async Task LoadDataAsync(int? selectedId = null)
        {
            try
            {
                _isLoading = true;
                var list = await context.TheLoaiSaches
                    .AsNoTracking()
                    .OrderBy(tl => tl.MaTl)
                    .ToListAsync();

                dgvTheLoaiSach.AutoGenerateColumns = false;
                dgvTheLoaiSach.DataSource = list;
                _isLoading = false;

                if (list.Count > 0)
                {
                    int targetRowIndex = 0;
                    if (selectedId.HasValue)
                    {
                        for (int i = 0; i < dgvTheLoaiSach.Rows.Count; i++)
                        {
                            if (dgvTheLoaiSach.Rows[i].Cells["colMaTL"].Value is int id && id == selectedId.Value)
                            {
                                targetRowIndex = i;
                                break;
                            }
                        }
                    }

                    dgvTheLoaiSach.ClearSelection();
                    dgvTheLoaiSach.Rows[targetRowIndex].Selected = true;
                    dgvTheLoaiSach.CurrentCell = dgvTheLoaiSach.Rows[targetRowIndex].Cells[0];
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
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị thông tin dòng đang chọn trên DataGridView lên các control nhập liệu
        /// </summary>
        private void DisplaySelectedRow()
        {
            if (_isLoading || dgvTheLoaiSach.CurrentRow == null || dgvTheLoaiSach.CurrentRow.Index < 0)
                return;

            var row = dgvTheLoaiSach.CurrentRow;
            txtMaTL.Text = row.Cells["colMaTL"].Value?.ToString() ?? "";
            txtTenTL.Text = row.Cells["colTenTL"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["colMoTa"].Value?.ToString() ?? "";

            var ngayTaoVal = row.Cells["colNgayTao"].Value;
            if (ngayTaoVal is DateTime dt)
            {
                lblNgayTao.Text = $"Ngày tạo: {dt:yyyy/MM/dd HH:mm:ss}";
            }
            else if (ngayTaoVal != null && DateTime.TryParse(ngayTaoVal.ToString(), out DateTime parsedDt))
            {
                lblNgayTao.Text = $"Ngày tạo: {parsedDt:yyyy/MM/dd HH:mm:ss}";
            }
            else
            {
                lblNgayTao.Text = "Ngày tạo: Chưa có";
            }
        }

        private void dgvTheLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            DisplaySelectedRow();
        }

        /// <summary>
        /// Xóa dữ liệu các ô nhập liệu về trạng thái ban đầu
        /// </summary>
        private void ClearInputs()
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtMoTa.Clear();
            lblNgayTao.Text = "Ngày tạo: (Mới)";
            dgvTheLoaiSach.ClearSelection();
            txtTenTL.Focus();
        }

        /// <summary>
        /// Chức năng Thêm mới thể loại sách
        /// </summary>
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenTheLoai = txtTenTL.Text.Trim();

            // 1. Kiểm tra không được bỏ trống Tên thể loại
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại sách!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTL.Focus();
                return;
            }

            try
            {
                // 2. Kiểm tra không cho phép trùng tên thể loại khi thêm mới
                bool isDuplicate = await context.TheLoaiSaches
                    .AnyAsync(tl => tl.TenTheLoai.ToLower() == tenTheLoai.ToLower());

                if (isDuplicate)
                {
                    MessageBox.Show($"Tên thể loại '{tenTheLoai}' đã tồn tại trong hệ thống. Vui lòng chọn tên khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTL.Focus();
                    return;
                }

                var newTheLoai = new TheLoaiSach
                {
                    TenTheLoai = tenTheLoai,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
                    SoLuongSach = 0,
                    NgayTao = DateTime.Now
                };

                context.Add(newTheLoai);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm mới thể loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView ngay sau khi lưu thành công và chọn dòng mới
                await LoadDataAsync(selectedId: newTheLoai.MaTl);
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Đã xảy ra lỗi khi thêm thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng Cập nhật thông tin thể loại sách
        /// </summary>
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL) || maTL <= 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại từ bảng để chỉnh sửa!", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTheLoai = txtTenTL.Text.Trim();

            // 1. Kiểm tra không được bỏ trống Tên thể loại
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Tên thể loại sách không được để trống!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTL.Focus();
                return;
            }

            try
            {
                // 2. Kiểm tra trùng tên với thể loại khác
                bool isDuplicate = await context.TheLoaiSaches
                    .AnyAsync(tl => tl.MaTl != maTL && tl.TenTheLoai.ToLower() == tenTheLoai.ToLower());

                if (isDuplicate)
                {
                    MessageBox.Show($"Tên thể loại '{tenTheLoai}' đã tồn tại cho một thể loại khác!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTL.Focus();
                    return;
                }

                var theLoai = await context.TheLoaiSaches.FindAsync(maTL);
                if (theLoai == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại sách này trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                theLoai.TenTheLoai = tenTheLoai;
                theLoai.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin thể loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView ngay sau khi lưu thành công
                await LoadDataAsync(selectedId: maTL);
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng Xóa thể loại sách kèm xác nhận Yes/No và bắt lỗi DbUpdateException
        /// </summary>
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL) || maTL <= 0)
            {
                MessageBox.Show("Vui lòng chọn một thể loại từ bảng cần xóa!", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTheLoai = txtTenTL.Text;
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại sách '{tenTheLoai}' (Mã TL: {maTL}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var theLoai = await context.TheLoaiSaches.FindAsync(maTL);
                if (theLoai == null)
                {
                    MessageBox.Show("Thể loại này không tồn tại hoặc đã bị xóa trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadDataAsync();
                    return;
                }

                context.TheLoaiSaches.Remove(theLoai);
                await context.SaveChangesAsync();

                MessageBox.Show("Xóa thể loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                // Bắt lỗi khi thể loại đang được các sách khác tham chiếu (khóa ngoại)
                context.ChangeTracker.Clear();
                MessageBox.Show("Không thể xóa thể loại này vì đang có các đầu sách khác tham chiếu đến dữ liệu này!", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                context.ChangeTracker.Clear();
                MessageBox.Show("Đã xảy ra lỗi khi xóa thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới lại giao diện và danh sách dữ liệu
        /// </summary>
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            ClearInputs();
            await LoadDataAsync();
        }

        /// <summary>
        /// Tìm kiếm theo Tên thể loại dùng LINQ (Where + Contains)
        /// </summary>
        private async Task SearchDataAsync()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var query = context.TheLoaiSaches.AsNoTracking().AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(tl => tl.TenTheLoai.Contains(keyword));
                }

                _isLoading = true;
                var list = await query.OrderBy(tl => tl.MaTl).ToListAsync();
                dgvTheLoaiSach.DataSource = list;
                _isLoading = false;

                if (list.Count > 0)
                {
                    dgvTheLoaiSach.ClearSelection();
                    dgvTheLoaiSach.Rows[0].Selected = true;
                    dgvTheLoaiSach.CurrentCell = dgvTheLoaiSach.Rows[0].Cells[0];
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
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
