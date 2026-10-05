namespace Bai_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            lblHoTen = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblSDT = new System.Windows.Forms.Label();
            txtSDT = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblNgaySinh = new System.Windows.Forms.Label();
            dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            lblHangThanhVien = new System.Windows.Forms.Label();
            cboHangThanhVien = new System.Windows.Forms.ComboBox();
            chkTrangThai = new System.Windows.Forms.CheckBox();
            grpGioiTinh = new System.Windows.Forms.GroupBox();
            radNu = new System.Windows.Forms.RadioButton();
            radNam = new System.Windows.Forms.RadioButton();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            txtTimKiemHoTen = new System.Windows.Forms.TextBox();
            lblLocHang = new System.Windows.Forms.Label();
            cboLocHangThanhVien = new System.Windows.Forms.ComboBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvHoiVien = new System.Windows.Forms.DataGridView();
            colMaHV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHangThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblHoTen.Location = new System.Drawing.Point(30, 25);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(47, 17);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtHoTen.Location = new System.Drawing.Point(145, 22);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Nhập họ tên...";
            txtHoTen.Size = new System.Drawing.Size(225, 24);
            txtHoTen.TabIndex = 1;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblSDT.Location = new System.Drawing.Point(30, 62);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new System.Drawing.Size(85, 17);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtSDT.Location = new System.Drawing.Point(145, 59);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "Nhập SĐT (9-11 số)...";
            txtSDT.Size = new System.Drawing.Size(225, 24);
            txtSDT.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblEmail.Location = new System.Drawing.Point(30, 99);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(39, 17);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtEmail.Location = new System.Drawing.Point(145, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email...";
            txtEmail.Size = new System.Drawing.Size(225, 24);
            txtEmail.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblNgaySinh.Location = new System.Drawing.Point(30, 136);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new System.Drawing.Size(66, 17);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new System.Drawing.Point(145, 133);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new System.Drawing.Size(225, 24);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblHangThanhVien
            // 
            lblHangThanhVien.AutoSize = true;
            lblHangThanhVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblHangThanhVien.Location = new System.Drawing.Point(30, 173);
            lblHangThanhVien.Name = "lblHangThanhVien";
            lblHangThanhVien.Size = new System.Drawing.Size(102, 17);
            lblHangThanhVien.TabIndex = 8;
            lblHangThanhVien.Text = "Hạng thành viên";
            // 
            // cboHangThanhVien
            // 
            cboHangThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboHangThanhVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboHangThanhVien.FormattingEnabled = true;
            cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.Location = new System.Drawing.Point(145, 170);
            cboHangThanhVien.Name = "cboHangThanhVien";
            cboHangThanhVien.Size = new System.Drawing.Size(225, 25);
            cboHangThanhVien.TabIndex = 9;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            chkTrangThai.Location = new System.Drawing.Point(33, 208);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new System.Drawing.Size(122, 21);
            chkTrangThai.TabIndex = 10;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            grpGioiTinh.Location = new System.Drawing.Point(400, 20);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new System.Drawing.Size(235, 100);
            grpGioiTinh.TabIndex = 11;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new System.Drawing.Point(135, 42);
            radNu.Name = "radNu";
            radNu.Size = new System.Drawing.Size(44, 21);
            radNu.TabIndex = 1;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new System.Drawing.Point(30, 42);
            radNam.Name = "radNam";
            radNam.Size = new System.Drawing.Size(53, 21);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnThem.Location = new System.Drawing.Point(670, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(115, 32);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnSua.Location = new System.Drawing.Point(670, 60);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(115, 32);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnXoa.Location = new System.Drawing.Point(670, 100);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(115, 32);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnLamMoi.Location = new System.Drawing.Point(670, 140);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(115, 32);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiemHoTen
            // 
            txtTimKiemHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtTimKiemHoTen.Location = new System.Drawing.Point(30, 245);
            txtTimKiemHoTen.Name = "txtTimKiemHoTen";
            txtTimKiemHoTen.PlaceholderText = "Nhập họ tên cần tìm...";
            txtTimKiemHoTen.Size = new System.Drawing.Size(260, 24);
            txtTimKiemHoTen.TabIndex = 16;
            txtTimKiemHoTen.KeyDown += txtTimKiem_KeyDown;
            // 
            // lblLocHang
            // 
            lblLocHang.AutoSize = true;
            lblLocHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblLocHang.Location = new System.Drawing.Point(305, 248);
            lblLocHang.Name = "lblLocHang";
            lblLocHang.Size = new System.Drawing.Size(102, 17);
            lblLocHang.TabIndex = 17;
            lblLocHang.Text = "Hạng thành viên";
            // 
            // cboLocHangThanhVien
            // 
            cboLocHangThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLocHangThanhVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboLocHangThanhVien.FormattingEnabled = true;
            cboLocHangThanhVien.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboLocHangThanhVien.Location = new System.Drawing.Point(415, 244);
            cboLocHangThanhVien.Name = "cboLocHangThanhVien";
            cboLocHangThanhVien.Size = new System.Drawing.Size(130, 25);
            cboLocHangThanhVien.TabIndex = 18;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnTimKiem.Location = new System.Drawing.Point(560, 241);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(115, 30);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHoiVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvHoiVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMaHV, colHoTen, colGioiTinh, colNgaySinh, colSDT, colHangThanhVien, colTrangThai });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvHoiVien.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHoiVien.Location = new System.Drawing.Point(30, 285);
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.RowHeadersWidth = 40;
            dgvHoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.Size = new System.Drawing.Size(920, 275);
            dgvHoiVien.TabIndex = 20;
            dgvHoiVien.CellFormatting += dgvHoiVien_CellFormatting;
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
            // 
            // colMaHV
            // 
            colMaHV.DataPropertyName = "MaHv";
            colMaHV.FillWeight = 50F;
            colMaHV.HeaderText = "Mã HV";
            colMaHV.MinimumWidth = 60;
            colMaHV.Name = "colMaHV";
            colMaHV.ReadOnly = true;
            // 
            // colHoTen
            // 
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 110F;
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 110;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            colGioiTinh.DataPropertyName = "GioiTinh";
            colGioiTinh.FillWeight = 60F;
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 70;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            colNgaySinh.DataPropertyName = "NgaySinh";
            colNgaySinh.FillWeight = 85F;
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 90;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.DataPropertyName = "Sdt";
            colSDT.FillWeight = 90F;
            colSDT.HeaderText = "SĐT";
            colSDT.MinimumWidth = 90;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colHangThanhVien
            // 
            colHangThanhVien.DataPropertyName = "HangThanhVien";
            colHangThanhVien.FillWeight = 95F;
            colHangThanhVien.HeaderText = "Hạng thành viên";
            colHangThanhVien.MinimumWidth = 100;
            colHangThanhVien.Name = "colHangThanhVien";
            colHangThanhVien.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 95F;
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 100;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 580);
            Controls.Add(dgvHoiVien);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocHangThanhVien);
            Controls.Add(lblLocHang);
            Controls.Add(txtTimKiemHoTen);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpGioiTinh);
            Controls.Add(chkTrangThai);
            Controls.Add(cboHangThanhVien);
            Controls.Add(lblHangThanhVien);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            MinimumSize = new System.Drawing.Size(860, 520);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Hội Viên Phòng Gym FitZone";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblHangThanhVien;
        private System.Windows.Forms.ComboBox cboHangThanhVien;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiemHoTen;
        private System.Windows.Forms.Label lblLocHang;
        private System.Windows.Forms.ComboBox cboLocHangThanhVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHoiVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHangThanhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
