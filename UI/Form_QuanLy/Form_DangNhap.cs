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

namespace UI.Form_QuanLy
{
    public partial class Form_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        TaiKhoanBLL tkbll;
        NhanVienBLL nvbll;       
        
        public Form_DangNhap()
        {
            
            InitializeComponent();
            tkbll = new TaiKhoanBLL();
            nvbll = new NhanVienBLL();           
        }

      


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTaiKhoan.Text.Trim() == "" || tbMatKhau.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin !");
                    tbTaiKhoan.Focus();
                }
                else if (tbTaiKhoan.Text.Trim() != "" || tbMatKhau.Text.Trim() != "")
                {
                    eNhanVien nv = nvbll.KiemTraDangNhap(tbTaiKhoan.Text, tbMatKhau.Text);
                    if (nv != null)
                    {
                        XtraMessageBox.Show("Login thành công !");
                        Form_Main.TENTAIKHOAN_ADMIN = tkbll.LayTaiKhoan(tbTaiKhoan.Text).TenTaiKhoan;
                        Form_Main.MATKHAU_ADMIN = tkbll.LayTaiKhoan(tbTaiKhoan.Text).MatKhau;
                        
                        Form_Main.trangThaiLogin = true;
                        
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng nhập lại !");
                        tbTaiKhoan.Focus();
                    }
                }
                   
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi: " + ex);
            }
           
           
           
            
        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
          
        }
    }
}