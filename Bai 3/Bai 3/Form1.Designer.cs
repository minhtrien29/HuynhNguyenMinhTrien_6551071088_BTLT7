namespace Bai_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numTangSo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTinhTrang = new System.Windows.Forms.ComboBox();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cmbLocLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cmbLocTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.btnQuanLyLoai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTangSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Text = "Số phòng";
            
            // txtSoPhong
            this.txtSoPhong.Location = new System.Drawing.Point(74, 12);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(100, 23);
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 15);
            this.label2.Name = "label2";
            this.label2.Text = "Tầng số";
            
            // numTangSo
            this.numTangSo.Location = new System.Drawing.Point(245, 12);
            this.numTangSo.Name = "numTangSo";
            this.numTangSo.Size = new System.Drawing.Size(60, 23);
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 15);
            this.label3.Name = "label3";
            this.label3.Text = "Loại phòng";
            
            // cmbLoaiPhong
            this.cmbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiPhong.FormattingEnabled = true;
            this.cmbLoaiPhong.Location = new System.Drawing.Point(395, 12);
            this.cmbLoaiPhong.Name = "cmbLoaiPhong";
            this.cmbLoaiPhong.Size = new System.Drawing.Size(121, 23);
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 15);
            this.label4.Name = "label4";
            this.label4.Text = "Tình trạng";
            
            // cmbTinhTrang
            this.cmbTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTinhTrang.FormattingEnabled = true;
            this.cmbTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
            this.cmbTinhTrang.Location = new System.Drawing.Point(601, 12);
            this.cmbTinhTrang.Name = "cmbTinhTrang";
            this.cmbTinhTrang.Size = new System.Drawing.Size(121, 23);
            
            // picHinhAnh
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(744, 12);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(100, 100);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHinhAnh.TabIndex = 8;
            this.picHinhAnh.TabStop = false;
            
            // btnChonAnh
            this.btnChonAnh.Location = new System.Drawing.Point(744, 118);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(100, 23);
            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            
            // btnThem
            this.btnThem.Location = new System.Drawing.Point(15, 60);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            // btnSua
            this.btnSua.Location = new System.Drawing.Point(96, 60);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            
            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(177, 60);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            
            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(258, 60);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            
            // btnQuanLyLoai
            this.btnQuanLyLoai.Location = new System.Drawing.Point(340, 60);
            this.btnQuanLyLoai.Name = "btnQuanLyLoai";
            this.btnQuanLyLoai.Size = new System.Drawing.Size(120, 23);
            this.btnQuanLyLoai.Text = "Quản lý Loại phòng";
            this.btnQuanLyLoai.UseVisualStyleBackColor = true;
            this.btnQuanLyLoai.Click += new System.EventHandler(this.btnQuanLyLoai_Click);
            
            // cmbLocLoaiPhong
            this.cmbLocLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocLoaiPhong.FormattingEnabled = true;
            this.cmbLocLoaiPhong.Location = new System.Drawing.Point(15, 118);
            this.cmbLocLoaiPhong.Name = "cmbLocLoaiPhong";
            this.cmbLocLoaiPhong.Size = new System.Drawing.Size(121, 23);
            
            // cmbLocTinhTrang
            this.cmbLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocTinhTrang.FormattingEnabled = true;
            this.cmbLocTinhTrang.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang ở", "Đang dọn" });
            this.cmbLocTinhTrang.Location = new System.Drawing.Point(152, 118);
            this.cmbLocTinhTrang.Name = "cmbLocTinhTrang";
            this.cmbLocTinhTrang.Size = new System.Drawing.Size(121, 23);
            
            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(289, 118);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            
            // dgvPhong
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(15, 161);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowTemplate.Height = 80;
            this.dgvPhong.Size = new System.Drawing.Size(829, 277);
            this.dgvPhong.TabIndex = 18;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 450);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cmbLocTinhTrang);
            this.Controls.Add(this.cmbLocLoaiPhong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnQuanLyLoai);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.picHinhAnh);
            this.Controls.Add(this.cmbTinhTrang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbLoaiPhong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numTangSo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Quản Lý Phòng - Sunrise Homestay";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTangSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTangSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoaiPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTinhTrang;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnQuanLyLoai;
        private System.Windows.Forms.ComboBox cmbLocLoaiPhong;
        private System.Windows.Forms.ComboBox cmbLocTinhTrang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvPhong;
    }
}
