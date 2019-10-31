namespace UI.Form_QuanLy
{
    partial class Form_DoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DoiMatKhau));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoiMK = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMatKhauCu = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.tbNhapLaiMK = new DevExpress.XtraEditors.TextEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMatKhauCu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNhapLaiMK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDoiMK);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbMatKhauCu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbMatKhauMoi);
            this.panel1.Controls.Add(this.tbNhapLaiMK);
            this.panel1.Location = new System.Drawing.Point(327, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 444);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(132, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhập mật khẩu cũ:";
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoiMK.Appearance.Options.UseFont = true;
            this.btnDoiMK.Location = new System.Drawing.Point(232, 308);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(232, 90);
            this.btnDoiMK.TabIndex = 16;
            this.btnDoiMK.Text = "Xác Nhận";
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(165, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(365, 60);
            this.label7.TabIndex = 9;
            this.label7.Text = "Đổi Mật Khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(125, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Xác nhận mật khẩu:";
            // 
            // tbMatKhauCu
            // 
            this.tbMatKhauCu.Location = new System.Drawing.Point(288, 144);
            this.tbMatKhauCu.Name = "tbMatKhauCu";
            this.tbMatKhauCu.Size = new System.Drawing.Size(242, 23);
            this.tbMatKhauCu.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(125, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nhập mật khẩu mới:";
            // 
            // tbMatKhauMoi
            // 
            this.tbMatKhauMoi.Location = new System.Drawing.Point(288, 191);
            this.tbMatKhauMoi.Name = "tbMatKhauMoi";
            this.tbMatKhauMoi.Properties.UseSystemPasswordChar = true;
            this.tbMatKhauMoi.Size = new System.Drawing.Size(242, 23);
            this.tbMatKhauMoi.TabIndex = 11;
            // 
            // tbNhapLaiMK
            // 
            this.tbNhapLaiMK.Location = new System.Drawing.Point(288, 242);
            this.tbNhapLaiMK.Name = "tbNhapLaiMK";
            this.tbNhapLaiMK.Properties.UseSystemPasswordChar = true;
            this.tbNhapLaiMK.Size = new System.Drawing.Size(242, 23);
            this.tbNhapLaiMK.TabIndex = 12;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // Form_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 546);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DoiMatKhau";
            this.Text = "Đổi Mật Khẩu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_DoiMatKhau_FormClosed);
            this.Load += new System.EventHandler(this.Form_DoiMatKhau_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMatKhauCu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNhapLaiMK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnDoiMK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit tbMatKhauCu;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit tbMatKhauMoi;
        private DevExpress.XtraEditors.TextEdit tbNhapLaiMK;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}