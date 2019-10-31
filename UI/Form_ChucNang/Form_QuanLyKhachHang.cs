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
using UI.Form_QuanLy;

namespace UI.Form_ChucNang
{
    public partial class Form_QuanLyKhachHang : DevExpress.XtraEditors.XtraForm
    {
        //Biến điều khiển chức năng.
        public int KEY = 0;

        KhachHangBLL khbll;
        public Form_QuanLyKhachHang()
        {
            InitializeComponent();         
            khbll = new KhachHangBLL();
            dataGridView1.AutoGenerateColumns = false;
        }


        #region Hàm tự viết
        //Load dtgv lên text box.
        private void LoadCell()
        {
            tbIdKhachHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            tbTenKhachHang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            tbDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            tbSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void XoaPanel()
        {
            tbIdKhachHang.Text = "";
            tbTenKhachHang.Text = "";
            tbDiaChi.Text = "";
            tbSDT.Text = "";
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

        public void loadData()
        {
           
            dataGridView1.DataSource = khbll.LayDanhSachKhachHang();
        }
        #endregion


        //Load Form
        private void Form_QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            loadData();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {          
            LoadCell();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KEY = 1;
            XoaPanel();           
            tbIdKhachHang.Text =  NextID(khbll.LayMaKhachHangCaoNhat(), "KH");   
            
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            panelQuanLyTTKH.Enabled = true;
            dataGridView1.Enabled = false;
            tbTenKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KEY = 2;
            panelQuanLyTTKH.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            dataGridView1.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KEY = 0;
            XoaPanel();
            panelQuanLyTTKH.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (KEY == 1)
            {
                #region Thêm
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm nhân viên không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbTenKhachHang.Text == "" || tbDiaChi.Text == "" || tbSDT.Text == "")
                        {
                            XtraMessageBox.Show("Thiếu thông tin, vui lòng nhập đủ !");
                        }
                        else
                        {
                            string reTen = @"^[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ]+[a-zĐaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+(\s+[A-ZAÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴĐ]+[a-zaáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵđ]+)+$";
                            Regex rgTen = new Regex(reTen);

                            string reSDT = @"^[0-9]{10,11}$";
                            Regex rgSDT = new Regex(reSDT);

                            if (!rgTen.IsMatch(tbTenKhachHang.Text))
                            {
                                XtraMessageBox.Show("Tên khách hàng viết hoa chữ đầu không bao gồm số, ít nhất 2 chữ , vui lòng nhập lại !");
                            }
                            else if (!rgSDT.IsMatch(tbSDT.Text))
                            {
                                XtraMessageBox.Show("Số điện thoại gồm 10 hoặc 11 chữ số, không có kí tự , vui lòng nhập lại !");
                            }
                            else
                            {
                                eKhachHang ekh = new eKhachHang();
                                ekh.IdKhachHang = tbIdKhachHang.Text;
                                ekh.HoTen = tbTenKhachHang.Text;
                                ekh.DiaChi = tbDiaChi.Text;
                                ekh.SoDienThoai = tbSDT.Text;
                                ekh.TrangThaiXoa = false;

                                if (khbll.ThemKhachHang(ekh))
                                {
                                    XtraMessageBox.Show("Thêm thành công !");
                                    XoaPanel();
                                    panelQuanLyTTKH.Enabled = false;
                                    loadData();
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
            else if(KEY == 2)
            {

                #region Sửa
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn thêm nhân viên không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (tbTenKhachHang.Text == "" || tbDiaChi.Text == "" || tbSDT.Text == "")
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

                            if (!rgTen.IsMatch(tbTenKhachHang.Text))
                            {
                                XtraMessageBox.Show("Tên khách hàng viết hoa chữ đầu không bao gồm số, ít nhất 2 chữ , vui lòng nhập lại !");
                            }
                            else if (!rgSDT.IsMatch(tbSDT.Text))
                            {
                                XtraMessageBox.Show("Số điện thoại gồm 10 hoặc 11 chữ số, không có kí tự , vui lòng nhập lại !");
                            }
                            else
                            {
                                eKhachHang ekh = new eKhachHang();
                                ekh.IdKhachHang = tbIdKhachHang.Text;
                                ekh.HoTen = tbTenKhachHang.Text;
                                ekh.DiaChi = tbDiaChi.Text;
                                ekh.SoDienThoai = tbSDT.Text;

                                if (khbll.SuaKhachHang(ekh))
                                {
                                    XtraMessageBox.Show("Sửa thành công !");
                                    XoaPanel();
                                    panelQuanLyTTKH.Enabled = false;                                    
                                    btnLuu.Enabled = false;
                                    btnHuy.Enabled = false;
                                    btnThem.Enabled = true;
                                    KEY = 0;
                                    loadData();
                                    dataGridView1.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            #region Xóa
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
            }
            else if(Form_Main.trangThaiLogin == true)
            {
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Bạn có muốn xóa khách hàng này không, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        eKhachHang ekh = new eKhachHang();
                        ekh.IdKhachHang = tbIdKhachHang.Text;
                        ekh.TrangThaiXoa = true;

                        if (khbll.XoaKhachHang(ekh))
                        {
                            XtraMessageBox.Show("Xóa thành công !");
                            XoaPanel();
                            panelQuanLyTTKH.Enabled = false;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                            btnThem.Enabled = true;
                            KEY = 0;
                            loadData();
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

        private void Form_QuanLyKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyKhachHang = true;
        }

       
    }
}