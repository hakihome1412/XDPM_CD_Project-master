using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using Entities;
using System.Text.RegularExpressions;

namespace UI.Form_QuanLy
{
    public partial class Form_DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        TaiKhoanBLL tkbll;
        public Form_DoiMatKhau()
        {
            InitializeComponent();
            tkbll = new TaiKhoanBLL();
        }

        private void Form_DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            //#region Chuối Regex để kiểm tra
            //string reMK = @"^([A-Z]){1}([\w_\.!@#$%^&*()]+){5,31}$";
            //Regex rgMK = new Regex(reMK);
            //#endregion
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn thêm tiêu đề không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    if (tbMatKhauCu.Text == "" || tbMatKhauMoi.Text == "" || tbNhapLaiMK.Text == "")
                    {
                        XtraMessageBox.Show("Chưa nhập đủ dữ liệu, vui lòng nhập lại !");
                    }
                    else
                    {
                        if (tbMatKhauCu.Text != Form_Main.MATKHAU_ADMIN)
                        {
                            XtraMessageBox.Show("Mật khẩu cũ không đúng, vui lòng nhập lại !");
                        }
                        else
                        {
                            if (tbMatKhauMoi.Text != tbNhapLaiMK.Text)
                            {
                                XtraMessageBox.Show("Mật khẩu mới không trùng, vui lòng nhập lại !");
                            }
                            else
                            {
                               
                                if (tkbll.SuaTaiKhoan(Form_Main.TENTAIKHOAN_ADMIN, tbMatKhauMoi.Text))
                                {
                                    XtraMessageBox.Show("Đổi mật khẩu thành công !");
                                    Form_Main.MATKHAU_ADMIN = tbMatKhauMoi.Text;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi " + ex);
                }
            }
            else
            {
                dg = DialogResult.Cancel;
            }
        }

        private void Form_DoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_DoiMatKhau = true;
        }
    }
}