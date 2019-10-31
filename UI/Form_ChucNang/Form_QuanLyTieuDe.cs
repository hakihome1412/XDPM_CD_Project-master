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

namespace UI.Form_ChucNang
{
    public partial class Form_QuanLyTieuDe : DevExpress.XtraEditors.XtraForm
    {
        //Biến điều khiển chức năng.
        public int KEY = 0;     
        TieuDeBLL tdbll;
        DanhMucBLL dmbll;
        public Form_QuanLyTieuDe()
        {
            InitializeComponent();        
            tdbll = new TieuDeBLL();
            dmbll = new DanhMucBLL();
            dataGridView1.AutoGenerateColumns = false;
        }

        #region Hàm tự viết
        public void LoadData()
        {
           
            dataGridView1.DataSource = tdbll.LayDanhSachTieuDeTheoTenDanhMuc(cbbPhanLoaiDanhMuc.Text);
        }

        private void LoadCell()
        {
            tbIdTieuDe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            tbTenTieuDe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();          
            tbSoLuongDia.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            //tbPhiThue.Text = String.Format(dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim(), "###,##");
         


        }

        private string NextID(string maTuTang, string prefixID)
        {
            if (maTuTang == "")
            {
                return prefixID + "00000001";  // fixwidth default
            }
            int nextID = int.Parse(maTuTang.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = maTuTang.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;

        }

        private void XoaPanel()
        {
            tbIdTieuDe.Text = "";
            tbTenTieuDe.Text = "";
            tbSoLuongDia.Text = "";
            //tbPhiThue.Text = "";            
        }
        #endregion

        private void Form_QuanLyTieuDe_Load(object sender, EventArgs e)
        {
            LoadData();
            //cbbDanhMuc.DataSource = (from a in db.DanhMucs
            //                         select a.TenDanhMuc
            //                             );
            //cbbDanhMuc.DataSource = dmbll.LayDanhSachDanhMuc();

            BindingSource binding1 = new BindingSource();
            binding1.DataSource = dmbll.LayDanhSachDanhMuc();
            cbbDanhMuc.DataSource = binding1.DataSource;
            cbbDanhMuc.DisplayMember = "TenDanhMuc";
            cbbDanhMuc.ValueMember = "TenDanhMuc";

            BindingSource binding2 = new BindingSource();
            binding2.DataSource = dmbll.LayDanhSachDanhMuc();
            cbbPhanLoaiDanhMuc.DataSource = binding2.DataSource;
            cbbPhanLoaiDanhMuc.DisplayMember = "TenDanhMuc";
            cbbPhanLoaiDanhMuc.ValueMember = "TenDanhMuc";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCell();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick( sender,  e);
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            KEY = 1;
            XoaPanel();
            tbIdTieuDe.Text = NextID(tdbll.LayMaTieuDeCaoNhat(), "TD");

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            panelQuanLyTD.Enabled = true;
            dataGridView1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KEY = 2;
            panelQuanLyTD.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            cbbPhanLoaiDanhMuc.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KEY == 1)
            {
                #region Thêm
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm tiêu đề không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbTenTieuDe.Text == "" )
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else
                        {
                            string reTen = @"^[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zĐaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                            Regex rgTen = new Regex(reTen);

                            string reGiaTien = @"^[0-9]{3,4,5,6,7,8,9,10}$";
                            Regex rgGiaTien = new Regex(reGiaTien);

                          
                            
                            if (!tdbll.kiemTraTrungTieuDe(tbTenTieuDe.Text))
                            {
                                XtraMessageBox.Show("Đã có một tiêu đề trùng tên trong hệ thống , vui lòng đặt tên khác!");
                            }
                            else
                            {
                                int idDM = dmbll.layIdDanhMuc(cbbDanhMuc.Text);
                                eTieuDe td = new eTieuDe();
                                td.IdTieuDe = tbIdTieuDe.Text;
                                td.TenTieuDe = tbTenTieuDe.Text;
                                td.SoLuongDia = 0;
                                td.IdDanhMuc = idDM;
                                //td.PhiThue = Convert.ToDecimal(tbPhiThue.Text);
                                td.TrangThaiXoa = false;

                                if (tdbll.ThemTieuDe(td))
                                {
                                    XtraMessageBox.Show("Thêm thành công !");
                                    XoaPanel();
                                    panelQuanLyTD.Enabled = false;
                                    LoadData();
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                    dataGridView1.Enabled = true;
                                    KEY = 0;

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
                }

                #endregion
            }
            else if (KEY == 2)
            {

                #region Sửa
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm nhân viên không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {

                        if (tbTenTieuDe.Text == "" /*|| tbPhiThue.Text == ""*/)
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else
                        {
                           
                                int idDM = dmbll.layIdDanhMuc(cbbDanhMuc.Text);
                                eTieuDe td = new eTieuDe();
                                td.IdTieuDe = tbIdTieuDe.Text;
                                td.TenTieuDe = tbTenTieuDe.Text;
                                td.SoLuongDia = 0;
                                td.IdDanhMuc = idDM;                             
                                td.TrangThaiXoa = false;

                                if (tdbll.SuaTieuDe(td))
                                {
                                    XtraMessageBox.Show("Sửa thành công !");
                                    XoaPanel();
                                    panelQuanLyTD.Enabled = false;
                                    LoadData();
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                    dataGridView1.Enabled = true;
                                    KEY = 0;

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
                }
                #endregion
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            KEY = 0;
            XoaPanel();
            panelQuanLyTD.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            cbbPhanLoaiDanhMuc.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            #region Xóa
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
            }
            else if (Form_Main.trangThaiLogin == true)
            {
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn xóa khách hàng này không, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        eTieuDe kh = new eTieuDe();
                        kh.IdTieuDe = tbIdTieuDe.Text;
                        kh.TrangThaiXoa = true;

                        if (tdbll.XoaTieuDe(kh))
                        {
                            XtraMessageBox.Show("Xóa thành công !");
                            XoaPanel();
                            panelQuanLyTD.Enabled = false;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                            btnThem.Enabled = true;
                            KEY = 0;
                            LoadData();
                            dataGridView1.Update();
                            dataGridView1.Refresh();
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
            }
            #endregion
        }

        private void Form_QuanLyTieuDe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyTieuDe = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbbPhanLoaiDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}