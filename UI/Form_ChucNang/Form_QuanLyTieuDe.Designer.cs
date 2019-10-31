namespace UI.Form_ChucNang
{
    partial class Form_QuanLyTieuDe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QuanLyTieuDe));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelQuanLyTD = new System.Windows.Forms.Panel();
            this.tbSoLuongDia = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.tbIdTieuDe = new DevExpress.XtraEditors.TextEdit();
            this.tbTenTieuDe = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panelThaoTac = new System.Windows.Forms.Panel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tbTimKiemNV = new System.Windows.Forms.TextBox();
            this.cbbTK_NV = new System.Windows.Forms.ComboBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cbbPhanLoaiDanhMuc = new System.Windows.Forms.ComboBox();
            this.IdTieuDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTieuDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panelQuanLyTD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoLuongDia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIdTieuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenTieuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.panelThaoTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.panelQuanLyTD);
            this.groupControl1.Location = new System.Drawing.Point(6, 6);
            this.groupControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(547, 269);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Thông Tin Tiêu Đề";
            // 
            // panelQuanLyTD
            // 
            this.panelQuanLyTD.Controls.Add(this.tbSoLuongDia);
            this.panelQuanLyTD.Controls.Add(this.label1);
            this.panelQuanLyTD.Controls.Add(this.cbbDanhMuc);
            this.panelQuanLyTD.Controls.Add(this.tbIdTieuDe);
            this.panelQuanLyTD.Controls.Add(this.tbTenTieuDe);
            this.panelQuanLyTD.Controls.Add(this.label4);
            this.panelQuanLyTD.Controls.Add(this.label3);
            this.panelQuanLyTD.Controls.Add(this.label2);
            this.panelQuanLyTD.Enabled = false;
            this.panelQuanLyTD.Location = new System.Drawing.Point(11, 29);
            this.panelQuanLyTD.Name = "panelQuanLyTD";
            this.panelQuanLyTD.Size = new System.Drawing.Size(502, 229);
            this.panelQuanLyTD.TabIndex = 53;
            // 
            // tbSoLuongDia
            // 
            this.tbSoLuongDia.Enabled = false;
            this.tbSoLuongDia.Location = new System.Drawing.Point(124, 145);
            this.tbSoLuongDia.Name = "tbSoLuongDia";
            this.tbSoLuongDia.Size = new System.Drawing.Size(364, 22);
            this.tbSoLuongDia.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Số Lượng Đĩa:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbbDanhMuc
            // 
            this.cbbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDanhMuc.FormattingEnabled = true;
            this.cbbDanhMuc.Location = new System.Drawing.Point(124, 102);
            this.cbbDanhMuc.Name = "cbbDanhMuc";
            this.cbbDanhMuc.Size = new System.Drawing.Size(364, 24);
            this.cbbDanhMuc.TabIndex = 57;
            // 
            // tbIdTieuDe
            // 
            this.tbIdTieuDe.Enabled = false;
            this.tbIdTieuDe.Location = new System.Drawing.Point(124, 20);
            this.tbIdTieuDe.Name = "tbIdTieuDe";
            this.tbIdTieuDe.Size = new System.Drawing.Size(364, 22);
            this.tbIdTieuDe.TabIndex = 52;
            // 
            // tbTenTieuDe
            // 
            this.tbTenTieuDe.Location = new System.Drawing.Point(124, 58);
            this.tbTenTieuDe.Name = "tbTenTieuDe";
            this.tbTenTieuDe.Size = new System.Drawing.Size(364, 22);
            this.tbTenTieuDe.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(32, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Danh mục:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(24, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên tiêu đề:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã tiêu đề:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTieuDe,
            this.tenTieuDe,
            this.SoLuongDia});
            this.dataGridView1.Location = new System.Drawing.Point(559, 133);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(793, 410);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl3.Controls.Add(this.panelThaoTac);
            this.groupControl3.Location = new System.Drawing.Point(6, 281);
            this.groupControl3.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(547, 262);
            this.groupControl3.TabIndex = 55;
            this.groupControl3.Text = "Thao Tác";
            // 
            // panelThaoTac
            // 
            this.panelThaoTac.Controls.Add(this.btnThem);
            this.panelThaoTac.Controls.Add(this.btnHuy);
            this.panelThaoTac.Controls.Add(this.btnXoa);
            this.panelThaoTac.Controls.Add(this.btnSua);
            this.panelThaoTac.Controls.Add(this.btnLuu);
            this.panelThaoTac.Location = new System.Drawing.Point(19, 29);
            this.panelThaoTac.Name = "panelThaoTac";
            this.panelThaoTac.Size = new System.Drawing.Size(512, 224);
            this.panelThaoTac.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Location = new System.Drawing.Point(51, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(168, 48);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(51, 158);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(168, 48);
            this.btnHuy.TabIndex = 59;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(51, 89);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(168, 48);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(287, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(168, 48);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Enabled = false;
            this.btnLuu.Location = new System.Drawing.Point(287, 89);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(168, 48);
            this.btnLuu.TabIndex = 58;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl2.Controls.Add(this.tbTimKiemNV);
            this.groupControl2.Controls.Add(this.cbbTK_NV);
            this.groupControl2.Location = new System.Drawing.Point(816, 6);
            this.groupControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(536, 121);
            this.groupControl2.TabIndex = 56;
            this.groupControl2.Text = "                       Tìm Kiếm";
            // 
            // tbTimKiemNV
            // 
            this.tbTimKiemNV.Location = new System.Drawing.Point(26, 74);
            this.tbTimKiemNV.Name = "tbTimKiemNV";
            this.tbTimKiemNV.Size = new System.Drawing.Size(479, 23);
            this.tbTimKiemNV.TabIndex = 38;
            // 
            // cbbTK_NV
            // 
            this.cbbTK_NV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTK_NV.FormattingEnabled = true;
            this.cbbTK_NV.Items.AddRange(new object[] {
            "Theo Tên NV",
            "Theo Mã NV",
            "Theo SDT"});
            this.cbbTK_NV.Location = new System.Drawing.Point(26, 44);
            this.cbbTK_NV.Name = "cbbTK_NV";
            this.cbbTK_NV.Size = new System.Drawing.Size(479, 24);
            this.cbbTK_NV.TabIndex = 39;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl4.Controls.Add(this.cbbPhanLoaiDanhMuc);
            this.groupControl4.Location = new System.Drawing.Point(559, 6);
            this.groupControl4.LookAndFeel.SkinName = "Office 2010 Blue";
            this.groupControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(251, 121);
            this.groupControl4.TabIndex = 57;
            this.groupControl4.Text = "Phân Nhóm";
            // 
            // cbbPhanLoaiDanhMuc
            // 
            this.cbbPhanLoaiDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPhanLoaiDanhMuc.FormattingEnabled = true;
            this.cbbPhanLoaiDanhMuc.Items.AddRange(new object[] {
            "Theo Tên NV",
            "Theo Mã NV",
            "Theo SDT"});
            this.cbbPhanLoaiDanhMuc.Location = new System.Drawing.Point(24, 54);
            this.cbbPhanLoaiDanhMuc.Name = "cbbPhanLoaiDanhMuc";
            this.cbbPhanLoaiDanhMuc.Size = new System.Drawing.Size(191, 24);
            this.cbbPhanLoaiDanhMuc.TabIndex = 39;
            this.cbbPhanLoaiDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbPhanLoaiDanhMuc_SelectedIndexChanged);
            // 
            // IdTieuDe
            // 
            this.IdTieuDe.DataPropertyName = "IdTieuDe";
            this.IdTieuDe.FillWeight = 253.6585F;
            this.IdTieuDe.HeaderText = "Mã Tiêu Đề";
            this.IdTieuDe.Name = "IdTieuDe";
            this.IdTieuDe.ReadOnly = true;
            this.IdTieuDe.Width = 118;
            // 
            // tenTieuDe
            // 
            this.tenTieuDe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenTieuDe.DataPropertyName = "tenTieuDe";
            this.tenTieuDe.FillWeight = 48.78049F;
            this.tenTieuDe.HeaderText = "Tên Tiêu Đề";
            this.tenTieuDe.Name = "tenTieuDe";
            this.tenTieuDe.ReadOnly = true;
            // 
            // SoLuongDia
            // 
            this.SoLuongDia.DataPropertyName = "SoLuongDia";
            this.SoLuongDia.HeaderText = "Số Lượng";
            this.SoLuongDia.Name = "SoLuongDia";
            this.SoLuongDia.ReadOnly = true;
            this.SoLuongDia.Width = 110;
            // 
            // Form_QuanLyTieuDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 546);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_QuanLyTieuDe";
            this.Text = "Quản Lý Tiêu Đề";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_QuanLyTieuDe_FormClosed);
            this.Load += new System.EventHandler(this.Form_QuanLyTieuDe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panelQuanLyTD.ResumeLayout(false);
            this.panelQuanLyTD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoLuongDia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIdTieuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenTieuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.panelThaoTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panelQuanLyTD;
        private System.Windows.Forms.ComboBox cbbDanhMuc;
        private DevExpress.XtraEditors.TextEdit tbIdTieuDe;
        private DevExpress.XtraEditors.TextEdit tbTenTieuDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.TextEdit tbSoLuongDia;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Panel panelThaoTac;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox tbTimKiemNV;
        private System.Windows.Forms.ComboBox cbbTK_NV;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.ComboBox cbbPhanLoaiDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTieuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTieuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDia;
    }
}