namespace Bai_1
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
            lblMaTL = new System.Windows.Forms.Label();
            txtMaTL = new System.Windows.Forms.TextBox();
            lblTenTL = new System.Windows.Forms.Label();
            txtTenTL = new System.Windows.Forms.TextBox();
            lblMoTa = new System.Windows.Forms.Label();
            txtMoTa = new System.Windows.Forms.TextBox();
            lblNgayTao = new System.Windows.Forms.Label();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvTheLoaiSach = new System.Windows.Forms.DataGridView();
            colMaTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTenTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSoLuongSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblMaTL.Location = new System.Drawing.Point(32, 28);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new System.Drawing.Size(77, 17);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại";
            // 
            // txtMaTL
            // 
            txtMaTL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtMaTL.Location = new System.Drawing.Point(125, 25);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.PlaceholderText = "ReadOnly";
            txtMaTL.Size = new System.Drawing.Size(265, 24);
            txtMaTL.TabIndex = 1;
            // 
            // lblTenTL
            // 
            lblTenTL.AutoSize = true;
            lblTenTL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblTenTL.Location = new System.Drawing.Point(32, 65);
            lblTenTL.Name = "lblTenTL";
            lblTenTL.Size = new System.Drawing.Size(78, 17);
            lblTenTL.TabIndex = 2;
            lblTenTL.Text = "Tên thể loại";
            // 
            // txtTenTL
            // 
            txtTenTL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtTenTL.Location = new System.Drawing.Point(125, 62);
            txtTenTL.Name = "txtTenTL";
            txtTenTL.Size = new System.Drawing.Size(265, 24);
            txtTenTL.TabIndex = 3;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblMoTa.Location = new System.Drawing.Point(32, 102);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new System.Drawing.Size(43, 17);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtMoTa.Location = new System.Drawing.Point(125, 99);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtMoTa.Size = new System.Drawing.Size(265, 68);
            txtMoTa.TabIndex = 5;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblNgayTao.ForeColor = System.Drawing.Color.DimGray;
            lblNgayTao.Location = new System.Drawing.Point(125, 175);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new System.Drawing.Size(61, 15);
            lblNgayTao.TabIndex = 6;
            lblNgayTao.Text = "Ngày tạo: ";
            // 
            // btnThem
            // 
            btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnThem.Location = new System.Drawing.Point(540, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(95, 30);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnSua.Location = new System.Drawing.Point(645, 22);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(95, 30);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnXoa.Location = new System.Drawing.Point(750, 22);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(95, 30);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnLamMoi.Location = new System.Drawing.Point(855, 22);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(95, 30);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtTimKiem.Location = new System.Drawing.Point(32, 205);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
            txtTimKiem.Size = new System.Drawing.Size(358, 24);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnTimKiem.Location = new System.Drawing.Point(400, 201);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(125, 30);
            btnTimKiem.TabIndex = 12;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvTheLoaiSach
            // 
            dgvTheLoaiSach.AllowUserToAddRows = false;
            dgvTheLoaiSach.AllowUserToDeleteRows = false;
            dgvTheLoaiSach.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvTheLoaiSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoaiSach.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvTheLoaiSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMaTL, colTenTL, colMoTa, colSoLuongSach, colNgayTao });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvTheLoaiSach.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTheLoaiSach.Location = new System.Drawing.Point(32, 245);
            dgvTheLoaiSach.MultiSelect = false;
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.ReadOnly = true;
            dgvTheLoaiSach.RowHeadersWidth = 40;
            dgvTheLoaiSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoaiSach.Size = new System.Drawing.Size(918, 305);
            dgvTheLoaiSach.TabIndex = 13;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;
            // 
            // colMaTL
            // 
            colMaTL.DataPropertyName = "MaTl";
            colMaTL.FillWeight = 50F;
            colMaTL.HeaderText = "Mã TL";
            colMaTL.MinimumWidth = 60;
            colMaTL.Name = "colMaTL";
            colMaTL.ReadOnly = true;
            // 
            // colTenTL
            // 
            colTenTL.DataPropertyName = "TenTheLoai";
            colTenTL.FillWeight = 110F;
            colTenTL.HeaderText = "Tên thể loại";
            colTenTL.MinimumWidth = 120;
            colTenTL.Name = "colTenTL";
            colTenTL.ReadOnly = true;
            // 
            // colMoTa
            // 
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.FillWeight = 160F;
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 150;
            colMoTa.Name = "colMoTa";
            colMoTa.ReadOnly = true;
            // 
            // colSoLuongSach
            // 
            colSoLuongSach.DataPropertyName = "SoLuongSach";
            colSoLuongSach.FillWeight = 70F;
            colSoLuongSach.HeaderText = "Số lượng sách";
            colSoLuongSach.MinimumWidth = 90;
            colSoLuongSach.Name = "colSoLuongSach";
            colSoLuongSach.ReadOnly = true;
            // 
            // colNgayTao
            // 
            colNgayTao.DataPropertyName = "NgayTao";
            colNgayTao.FillWeight = 110F;
            colNgayTao.HeaderText = "Ngày tạo";
            colNgayTao.MinimumWidth = 130;
            colNgayTao.Name = "colNgayTao";
            colNgayTao.ReadOnly = true;
            colNgayTao.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 576);
            Controls.Add(dgvTheLoaiSach);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblNgayTao);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtTenTL);
            Controls.Add(lblTenTL);
            Controls.Add(txtMaTL);
            Controls.Add(lblMaTL);
            MinimumSize = new System.Drawing.Size(850, 500);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMaTL;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.Label lblTenTL;
        private System.Windows.Forms.TextBox txtTenTL;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTheLoaiSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
    }
}
