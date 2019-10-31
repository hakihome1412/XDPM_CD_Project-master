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

namespace UI.Form_ChucNang
{
    public partial class Form_TraDia : DevExpress.XtraEditors.XtraForm
    {
        KhachHangBLL khbll;
        TieuDeBLL tdbll;
        DiaBLL diabll;
        ChiTietPhieuThueBLL ctptbll;
        eKhachHang ekh = new eKhachHang();
        eDia ed = new eDia();
        eThongTinPhieuThue ettpt = new eThongTinPhieuThue();

        public Form_TraDia()
        {
            khbll = new KhachHangBLL();
            tdbll = new TieuDeBLL();
            diabll = new DiaBLL();
            ctptbll = new ChiTietPhieuThueBLL();

            InitializeComponent();
        }

        private void Form_TraDia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_TraDia = true;
        }
        #region Hàm tự viéte

        public void HienThiThongTinKH()
        {
            tbTenKhachHang.Text = ekh.HoTen;
            tbDiaChi.Text = ekh.DiaChi;
            tbSDT.Text = ekh.SoDienThoai;
        }
        public void HienThiThongTinDia()
        {
            tbTTIdDia.Text = ed.IdDia;
            tbTTTenDia.Text = ed.TenTieuDe;
            tbTTDanhMuc.Text = ed.TenDanhMuc;
            tbTTPhiThueDia.Text = ed.PhiThue.ToString();
            tbTTPhiTreHan.Text = ed.PhiTreHan.ToString();
        }

        private void HienThiThongTinThueDia()
        {
            tbNgaythue.Text = ettpt.NgayThue.ToString();
            tbHanChotTraDia.Text = ettpt.NgayTraDiaDuKien.ToString();
            tbSoNgayThue.Text = ettpt.SoNgayThue.ToString();
            tbPhiTreHan.Text = ettpt.PhiTreHan.ToString();
            tbSoNgayTreHan.Text = ettpt.SoNgayTreHan.ToString();

        }

        public void XoaAll()
        {
            tbIdDia.Text = "";
            tbTTIdDia.Text = "";
            tbTTTenDia.Text = "";
            tbTTDanhMuc.Text = "";
            tbTTPhiThueDia.Text = "";
            tbTTPhiTreHan.Text = "";


            tbTenKhachHang.Text = "";
            tbDiaChi.Text = "";
            tbSDT.Text = "";
            tbTongPhiTreHan.Text = "";

            tbNgaythue.Text = "";
            tbHanChotTraDia.Text = "";
            tbSoNgayThue.Text = "";
            tbSoNgayTreHan.Text = "";
            tbPhiTreHan.Text = "";
        }

        public void KhoaButton()
        {
            btnXNTD_BT.Enabled = false;
            btnXNTD_TraPhi.Enabled = false;
            btnXNTD_ChuaTraPhi.Enabled = false;
            btnHuy.Enabled = false;
        }
        #endregion


        private void btnThemDia_Click(object sender, EventArgs e)
        {
            if (tbIdDia.Text == "" || tbIdDia.Text == "")
            {
                XtraMessageBox.Show("Thông tin thiếu, vui lòng nhập ID đĩa !");
            }
            else if (tdbll.LayTenTieuDeBangIdDia(tbIdDia.Text) == "null")
            {
                XtraMessageBox.Show("Không có Đĩa này trong hệ thống, vui lòng nhập ID khác !");
            }
            else if (diabll.kiemTraDiaTaiCuaHang(tbIdDia.Text) == false)
            {
                XtraMessageBox.Show("Đĩa đang có sẵn trong cửa hàng và chưa được thuê bởi ai , vui lòng nhập ID đĩa khác !");
            }
            else
            {

                ekh = khbll.LayThongTinKhachHangBangIdDia(tbIdDia.Text);
                ed = diabll.LayThongTinDiaBangIdDia(tbIdDia.Text);
                ettpt = ctptbll.LayThongTinPhieuThue(tbIdDia.Text, ekh.IdKhachHang);

                ctptbll.CapNhatKhoanNoCuaKhachHang(ekh.IdKhachHang);
                HienThiThongTinKH();
                tbTongPhiTreHan.Text = ctptbll.LayKhoanNoCuaKhachHang(ekh.IdKhachHang).ToString();

                HienThiThongTinDia();

                HienThiThongTinThueDia();

                btnXNTD_BT.Enabled = true;
                btnHuy.Enabled = true;


                if (Convert.ToDecimal(tbPhiTreHan.Text) == 0)
                {
                    btnXNTD_BT.Enabled = true;
                    btnXNTD_TraPhi.Enabled = false;
                    btnXNTD_ChuaTraPhi.Enabled = false;
                    btnHuy.Enabled = true;
                }
                else if (Convert.ToDecimal(tbPhiTreHan.Text) > 0)
                {
                    btnXNTD_BT.Enabled = false;
                    btnXNTD_TraPhi.Enabled = true;
                    btnXNTD_ChuaTraPhi.Enabled = true;
                    btnHuy.Enabled = true;
                }

            }


        }

        private void btnXNTD_BT_Click(object sender, EventArgs e)
        {
            #region Xác nhận trả dĩa bình thường
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Xác nhận trả đĩa: "+ed.IdDia+" của khách hàng "+ekh.HoTen+" !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {                    
                    
                        eChiTietPhieuThue ectpt = new eChiTietPhieuThue();
                        ectpt.IdChiTietPhieuThue = ettpt.IdChiTietPhieuThue;
                        ectpt.NgayTraDiaThucTe = DateTime.Now;
                        ectpt.TrangThaiNoPhiTre = false;
                        ectpt.TrangThaiTraPhiTre = false;                       
                        
                        

                        if (ctptbll.XacNhanTraDia(ectpt) && diabll.SuaTrangThaiThueDia(ed.IdDia))
                        {
                            XtraMessageBox.Show("Trả đĩa thành công !");                          
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
            }
            #endregion
        }

        private void btnXNTD_TraPhi_Click(object sender, EventArgs e)
        {
            #region Xác nhận trả dĩa có trả phí trễ
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Chỉ xác nhận khi khách hàng " + ekh.HoTen + "thanh toán khoản phí trễ cho đĩa: " + ed.IdDia + "!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {

                    eChiTietPhieuThue ectpt = new eChiTietPhieuThue();
                    ectpt.IdChiTietPhieuThue = ettpt.IdChiTietPhieuThue;
                    ectpt.NgayTraDiaThucTe = DateTime.Now;
                    ectpt.TrangThaiNoPhiTre = true;
                    ectpt.TrangThaiTraPhiTre = true;

                    if (ctptbll.XacNhanTraDia(ectpt) && diabll.SuaTrangThaiThueDia(ed.IdDia))
                    {
                        XtraMessageBox.Show("Trả đĩa thành công !");
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
            }
            #endregion
        }

        private void btnXNTD_ChuaTraPhi_Click(object sender, EventArgs e)
        {
            #region Xác nhận trả dĩa có trả phí trễ
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Xác nhận khách hàng " + ekh.HoTen + "trả đĩa: " + ed.IdDia + "và chưa thanh toán khoản phí trễ !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {

                    eChiTietPhieuThue ectpt = new eChiTietPhieuThue();
                    ectpt.IdChiTietPhieuThue = ettpt.IdChiTietPhieuThue;
                    ectpt.NgayTraDiaThucTe = DateTime.Now;
                    ectpt.TrangThaiNoPhiTre = true;
                    ectpt.TrangThaiTraPhiTre = false;

                    if (ctptbll.XacNhanTraDia(ectpt) && diabll.SuaTrangThaiThueDia(ed.IdDia))
                    {
                        XtraMessageBox.Show("Trả đĩa thành công !");
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
            }
            #endregion
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaAll();
            KhoaButton();

            
        }
  

        private void Form_TraDia_Load(object sender, EventArgs e)
        {

        }
    }
}