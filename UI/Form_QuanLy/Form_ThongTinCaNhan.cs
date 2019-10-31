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
    public partial class Form_ThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL nvbll;

        public Form_ThongTinCaNhan()
        {
            InitializeComponent();
            nvbll = new NhanVienBLL();
        }
        #region Hàm viết riêng
        public void LoadData()
        {
            tbMaNV.Text = nvbll.KiemTraDangNhap(Form_Main.TENTAIKHOAN_ADMIN, Form_Main.MATKHAU_ADMIN).IdNhanVien;
            tbTenNV.Text = nvbll.KiemTraDangNhap(Form_Main.TENTAIKHOAN_ADMIN, Form_Main.MATKHAU_ADMIN).HoTen;
            tbDiaChi.Text = nvbll.KiemTraDangNhap(Form_Main.TENTAIKHOAN_ADMIN, Form_Main.MATKHAU_ADMIN).DiaChi;
            tbSDT.Text = nvbll.KiemTraDangNhap(Form_Main.TENTAIKHOAN_ADMIN, Form_Main.MATKHAU_ADMIN).SoDienThoai;

        }
        #endregion
        private void Form_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadData();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void Form_ThongTinCaNhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_ThongTinCaNhan = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnSua.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Sửa
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn thêm nhân viên không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    if (tbTenNV.Text == "" || tbDiaChi.Text == "" || tbSDT.Text == "")
                    {
                        XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                    }
                    else
                    {
                        //string reTen1 = @"^[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zĐaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                        string reTen = @"^[A-ZĐAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                        Regex rgTen = new Regex(reTen);

                        string reSDT = @"^[0-9]{10,11}$";
                        Regex rgSDT = new Regex(reSDT);

                        if (!rgTen.IsMatch(tbTenNV.Text))
                        {
                            XtraMessageBox.Show("Tên khách hàng viết hoa chữ đầu không bao gồm số, ít nhất 2 chữ , vui lòng nhập lại !");
                        }
                        else if (!rgSDT.IsMatch(tbSDT.Text))
                        {
                            XtraMessageBox.Show("Số điện thoại gồm 10 hoặc 11 chữ số, không có kí tự , vui lòng nhập lại !");
                        }
                        else
                        {
                            eNhanVien env = new eNhanVien();
                            env.IdNhanVien = tbMaNV.Text;
                            env.HoTen = tbTenNV.Text;
                            env.DiaChi = tbDiaChi.Text;
                            env.SoDienThoai = tbSDT.Text;

                            if (nvbll.SuaNhanVien(env))
                            {
                                XtraMessageBox.Show("Sửa thành công !");
                                panelTT.Enabled = false;                              
                                btnLuu.Enabled = false;
                                btnHuy.Enabled = false;
                                btnSua.Enabled = true;                              
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Lỗi: " + ex);
                }

            }
            else
            {
                dg = DialogResult.Cancel;
                LoadData();
                panelTT.Enabled = false;
                btnSua.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
            #endregion
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
            panelTT.Enabled = false;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }
    }
}