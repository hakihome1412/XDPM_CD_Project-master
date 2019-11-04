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
using DevExpress.XtraBars;
using UI.Form_QuanLy;
using UI.Form_ChucNang;
using DevExpress.XtraBars.Ribbon;
using BLL;
using Entities;
using static DevExpress.Utils.MVVM.Services.DocumentManagerService;

namespace UI
{
    public partial class Form_Main : DevExpress.XtraEditors.XtraForm
    {
        //Biến kiểm tra đang nhập. True là đang đăng nhập, False là chưa đăng nhập.
        public static bool trangThaiLogin = false;

        #region Biến dùng để ngăn form mở nhiều lần
      
        public static bool f_DoiMatKhau = true;
        public static bool f_ThongTinCaNhan = true;
        public static bool f_ = true;
        public static bool f_QuanLyDanhMuc = true;
        public static bool f_QuanLyKhachHang = true;
        public static bool f_QuanLyKhoDia = true;
        public static bool f_QuanLyThueDia = true;
        public static bool f_QuanLyTieuDe = true;
        public static bool f_QuanLyPhiTre = true;
        public static bool f_QuanLyDatDia = true;
        public static bool f_TraDia = true;


        //Thông tin tài khoản admin
        public static string TENTAIKHOAN_ADMIN;
        public static string MATKHAU_ADMIN;
        #endregion


        public Form_Main()
        {
            InitializeComponent();
            
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            //ribbonPageGroup3.Visible = false;
            //btn_DangNhap.Links[0].Visible = false;
            if (trangThaiLogin == false)
            {

                rbPage_QuanLy.Visible = false;
            }
        }
        private void BatQuanLyConTrol()
        {
            rbPage_QuanLy.Visible = true;
        }

        private void btn_ThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_ThongTinCaNhan form = new Form_ThongTinCaNhan();
            form.MdiParent = this;
            form.Show();
        }

        private void btn_DoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_DoiMatKhau form = new Form_DoiMatKhau();
            form.MdiParent = this;
            form.Show();
        }

        private void btn_DangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_DangNhap form = new Form_DangNhap();            
            //form.MdiParent = this;
            form.ShowDialog();
            if(trangThaiLogin == true)
            {
                rbPage_QuanLy.Visible = true;
                
            }
        }

        private void btn_QuanLyThueDia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
            Form_QuanLyThueDia form = new Form_QuanLyThueDia();
            if (f_QuanLyThueDia == true)
            {
               
                form.MdiParent = this;
                form.Show();
              
                f_QuanLyThueDia = false;
            }
            else if(f_QuanLyThueDia == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {

                    
                    if (item is Form_QuanLyThueDia)
                    {                   
                        item.Activate();
                    }                   
                }                            
            }

        }
       
        private void btn_QuanLyPhiTre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyPhiTre form = new Form_QuanLyPhiTre();
            if (f_QuanLyPhiTre == true)
            {
              
                form.MdiParent = this;
                form.Show();

                f_QuanLyPhiTre = false;
            }
            else if (f_QuanLyPhiTre == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyPhiTre)
                    {
                        item.Activate();
                    }
                }
            }

        }
        private void btn_QuanLyDatDia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyDatDia form = new Form_QuanLyDatDia();
            if (f_QuanLyDatDia == true)
            {
               
                form.MdiParent = this;
                form.Show();

                f_QuanLyDatDia = false;
            }
            else if (f_QuanLyDatDia == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyDatDia)
                    {
                        item.Activate();
                    }
                }
            }
        }

        private void btn_QuanLyKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyKhachHang form = new Form_QuanLyKhachHang();
            if (f_QuanLyKhachHang == true)
            {
                
                form.MdiParent = this;
                form.Show();

                f_QuanLyKhachHang = false;
            }
            else if (f_QuanLyKhachHang == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyKhachHang)
                    {
                        item.Activate();
                    }
                }
            }

        }

        private void btn_QuanLyTieuDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyTieuDe form = new Form_QuanLyTieuDe();
            if (f_QuanLyTieuDe == true)
            {
              
                form.MdiParent = this;
                form.Show();

                f_QuanLyTieuDe = false;
            }
            else if (f_QuanLyTieuDe == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyTieuDe)
                    {
                        item.Activate();
                    }
                }
            }

        }

        private void btn_QuanLyDanhMuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyDanhMuc form = new Form_QuanLyDanhMuc();
            if (f_QuanLyDanhMuc == true)
            {               
                form.MdiParent = this;
                form.Show();

                f_QuanLyDanhMuc = false;
            }
            else if (f_QuanLyDanhMuc == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyDanhMuc)
                    {
                        item.Activate();
                    }
                }
            }
        }

        private void btn_QuanLyKhoDia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_QuanLyKhoDia form = new Form_QuanLyKhoDia();
            if (f_QuanLyKhoDia == true)
            {
               
                form.MdiParent = this;
                form.Show();

                f_QuanLyKhoDia = false;
            }
            else if (f_QuanLyKhoDia == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_QuanLyKhoDia)
                    {
                        item.Activate();
                    }
                }
            }
        }

        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                trangThaiLogin = false;
                if (trangThaiLogin == false)
                {
                    rbPage_QuanLy.Visible = false;
                }
            }
            else
            {
                dg = DialogResult.Cancel;
            }
               
        }

        private void btn_TraDia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_TraDia form = new Form_TraDia();
            if (f_TraDia == true)
            {

                form.MdiParent = this;
                form.Show();

                f_TraDia = false;
            }
            else if (f_TraDia == false)
            {
                foreach (XtraForm item in this.MdiChildren)
                {


                    if (item is Form_TraDia)
                    {
                        item.Activate();
                    }
                }
            }
        }
    }
}