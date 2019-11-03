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
    public partial class Form_QuanLyDanhMuc : DevExpress.XtraEditors.XtraForm
    {
        //Biến điều khiển chức năng.
        public int KEY = 0;

        DanhMucBLL dmbll;  
        public Form_QuanLyDanhMuc()
        {
            InitializeComponent();
            dmbll = new DanhMucBLL();
            dataGridView1.AutoGenerateColumns = false;
            formDN = new Form_QuanLy.Form_DangNhap();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dmbll.LayDanhSachDanhMuc();
        }

        private void LoadCell()
        {
            eDanhMuc dm = dmbll.LayDanhMucTheoIDDanhMuc(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            tbIdDanhMuc.Text = dm.IdDanhMuc.ToString();
            tbTenDanhMuc.Text = dm.TenDanhMuc;
            tbPhiThue.Text = dm.PhiThue.ToString();
            tbPhiTreHan.Text = dm.PhiTreHan.ToString();
            tbSoNgayThue.Text = dm.SoNgayThue.ToString();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCell();
            if(KEY == 1 || KEY == 2 || KEY == 3)
                btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = false;
            else
                btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = true;

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCell();
        }

        private void Form_QuanLyDanhMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyDanhMuc = true;
        }





        private void btnLuu_Click(object sender, EventArgs e)
        {
           
                if(KEY == 1)
                {
                    if(dmbll.CapNhatPhiThue(Convert.ToInt32(tbIdDanhMuc.Text), Convert.ToDecimal(tbPhiThue.Text)))
                    {
                        XtraMessageBox.Show("Cập nhật phí thuê mới thành công");
                        LoadData();
                        LoadCell();
                    btnLuu.Enabled = false;
                    btn_Huy.Enabled = false;
                    tbPhiThue.Enabled = false;
                    btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = true;
                    KEY = 0;
                }
                    else
                    {
                    XtraMessageBox.Show("Cập nhật thất bại !");

                    }
                    

                 }
                else
                {
                    if(KEY == 2)
                    {
                    if (dmbll.CapNhatPhiTreHan(Convert.ToInt32(tbIdDanhMuc.Text), Convert.ToDecimal(tbPhiTreHan.Text)))
                    {
                        XtraMessageBox.Show("Cập nhật phí trễ hạn mới thành công");
                        LoadData();
                        LoadCell();
                        btnLuu.Enabled = false;
                        btn_Huy.Enabled = false;
                        tbPhiTreHan.Enabled = false;
                        btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = true;
                        KEY = 0;
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật thất bại !");
                    }
                }
                    else
                    {
                    if (dmbll.CapNhatSoNgayThue(Convert.ToInt32(tbIdDanhMuc.Text), Convert.ToInt32(tbSoNgayThue.Text)))
                    {
                        XtraMessageBox.Show("Cập nhật số ngày thuê mới thành công");
                        LoadData();
                        LoadCell();
                        btnLuu.Enabled = false;
                        btn_Huy.Enabled = false;
                        tbSoNgayThue.Enabled = false;
                        btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = true;
                        KEY = 0;
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật thất bại !");
                    }
                }
                }
            
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbTimKiemNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSoNgayThue_EditValueChanged(object sender, EventArgs e)
        {

        }

        private Form_QuanLy.Form_DangNhap formDN;

        private void btn_SuaPhiThue_Click(object sender, EventArgs e)
        {

            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();

            }
            else
            {
                KEY = 1;
                btnLuu.Enabled = btn_Huy.Enabled = true;
                btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = btn_SuaPhiThue.Enabled = false;
                tbPhiThue.Enabled = true;
                tbPhiThue.Focus();
            }
            
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            KEY = 0;
            tbPhiThue.Enabled = tbPhiTreHan.Enabled = tbSoNgayThue.Enabled = false;
            btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = true;
            btn_Huy.Enabled = btnLuu.Enabled =  false;
            LoadData();
            LoadCell();


        }

        private void btn_SuaPhiTreHan_Click(object sender, EventArgs e)
        {
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();

            }
            else
            {
                KEY = 2;
                btnLuu.Enabled = btn_Huy.Enabled = true;
                btn_SuaPhiThue.Enabled = btn_SuaSoNgayThue.Enabled = btn_SuaPhiTreHan.Enabled = false;
                tbPhiTreHan.Enabled = true;
                tbPhiTreHan.Focus();
            }
        }

        private void btn_SuaSoNgayThue_Click(object sender, EventArgs e)
        {
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();

            }
            else
            {
                KEY = 3;
                btnLuu.Enabled = btn_Huy.Enabled = true;
                btn_SuaPhiThue.Enabled = btn_SuaPhiTreHan.Enabled = btn_SuaSoNgayThue.Enabled = false;
                tbSoNgayThue.Enabled = true;
                tbSoNgayThue.Focus();
            }
        }
    }
}