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
            eTieuDe td = tdbll.LayTieuDeTheoIDTieuDe(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            tbIdTieuDe.Text = td.IdTieuDe;
            tbTenTieuDe.Text = td.TenTieuDe;
            tbSoLuongDia.Text = td.SoLuongDia.ToString();
            cbbDanhMuc.SelectedValue = cbbPhanLoaiDanhMuc.SelectedValue.ToString();
            tbSoLuongDiaCoSan.Text = td.SoLuongDiaCoSan.ToString();
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
            tbSoLuongDia.Text = "0";
            tbSoLuongDiaCoSan.Text = "0";
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
            LoadCell();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCell();
            btnXoa.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick( sender,  e);
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();
            }
            else if (Form_Main.trangThaiLogin == true)
            {
                KEY = 1;
                XoaPanel();
                tbIdTieuDe.Text = NextID(tdbll.LayMaTieuDeCaoNhat(), "TD");

                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnXoa.Enabled = false;
                panelQuanLyTD.Enabled = true;
                dataGridView1.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KEY = 2;
            panelQuanLyTD.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
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

                          
                            
                            if (tdbll.kiemtraTieuDeDaTonTai(tbTenTieuDe.Text))
                            {
                                if(tdbll.capnhatTrangThaiXoa(tbTenTieuDe.Text,false))
                                {
                                    XtraMessageBox.Show("Thêm thành công");
                                    XoaPanel();
                                    panelQuanLyTD.Enabled = false;
                                    LoadData();
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                    btnXoa.Enabled = true;
                                    dataGridView1.Enabled = true;
                                    KEY = 0;
                                    LoadCell();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Thêm thất bại !");
                                }
                            }
                            else
                            {
                                int idDM = dmbll.layIdDanhMuc(cbbDanhMuc.Text);
                                eTieuDe td = new eTieuDe();
                                td.IdTieuDe = tbIdTieuDe.Text;
                                td.TenTieuDe = tbTenTieuDe.Text;
                                td.SoLuongDia = 0;
                                td.IdDanhMuc = idDM;
                                td.SoLuongDiaCoSan = 0;
                                //td.PhiThue = Convert.ToDecimal(tbPhiThue.Text);
                                td.TrangThaiXoa = false;

                                if (tdbll.ThemTieuDe(td))
                                {
                                    XtraMessageBox.Show("Thêm thành công");
                                    XoaPanel();
                                    panelQuanLyTD.Enabled = false;
                                    LoadData();
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                    btnXoa.Enabled = true;
                                    dataGridView1.Enabled = true;
                                    KEY = 0;
                                    LoadCell();

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
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            KEY = 0;
            XoaPanel();
            panelQuanLyTD.Enabled = false;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            cbbPhanLoaiDanhMuc.Enabled = true;
            dataGridView1.Enabled = true;
            LoadCell();
        }

        private Form_QuanLy.Form_DangNhap formDN;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            #region Xóa
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();
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

                        if (tdbll.kiemtraSoLuongDiaConLai(tbIdTieuDe.Text))
                        {
                            XtraMessageBox.Show("Xóa không thành công vì còn tồn tại Đĩa với tiêu đề này !");
                        }
                        else
                        {
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
                                LoadCell();
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