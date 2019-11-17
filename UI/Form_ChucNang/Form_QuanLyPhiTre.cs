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
    public partial class Form_QuanLyPhiTre : DevExpress.XtraEditors.XtraForm
    {
        private KhachHangBLL khbll;
        private ChiTietPhieuThueBLL ctptbll;
        private DanhMucBLL dmbll;
        public Form_QuanLyPhiTre()
        {
            khbll = new KhachHangBLL();
            ctptbll = new ChiTietPhieuThueBLL();
            dmbll = new DanhMucBLL();
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
        }

        private void Form_QuanLyPhiTre_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyPhiTre = true;
        }

        private void Form_QuanLyPhiTre_Load(object sender, EventArgs e)
        {
            formDN = new Form_QuanLy.Form_DangNhap();
            tbIdKH.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXacNhanIDKhach_Click(object sender, EventArgs e)
        {
            eKhachHang kh = khbll.LayThongTinKhachHang(tbIdKH.Text);
            if (kh == null)
                XtraMessageBox.Show("Không tồn tại thông tin Khách Hàng này trong hệ thống");
            else
            {
                if (btnXacNhanIDKhach.Text == "Xác Nhận")
                {
                    if (khbll.TongPhiTreKhachHang(tbIdKH.Text) == 0)
                    {
                        XtraMessageBox.Show("Khách hàng " + kh.HoTen + " không nợ khoản phí trễ nào");
                    }
                    else
                    {
                        btnXacNhanIDKhach.Text = "Hủy";
                        tbDiaChi.Text = kh.DiaChi;
                        tbTenKhachHang.Text = kh.HoTen;
                        tbSDT.Text = kh.SoDienThoai;
                        tbTienNo.Text = khbll.TongPhiTreKhachHang(tbIdKH.Text).ToString();
                        tbSoTienKhachTra.Enabled = true;
                        checkBox1.Enabled = true;
                        btnXacNhanTraPhi.Enabled = true;

                        if (ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text) == null)
                            XtraMessageBox.Show("Không có dữ liệu");
                        else
                        {
                            dataGridView2.DataSource = ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text);
                            loadCell();
                            btnXoaPhiTre.Enabled = true;
                        }
                    }
                    
                }
                else //Nếu là Hủy
                {
                    DialogResult dialog = new DialogResult();
                    dialog = XtraMessageBox.Show("Các thao tác trước đó sẽ bị hủy . Bạn có muốn Hủy ?","Thông báo Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        btnXacNhanIDKhach.Text = "Xác Nhận";
                        clearALLtextbox();
                        dataGridView2.DataSource = null;
                        tbIdKH.Focus();
                        checkBox1.Enabled = false;
                        tbSoTienKhachTra.Enabled = false;
                    }
                    else
                    {
                        dialog = DialogResult.Cancel;
                    }
                }
            }
        }

        private void loadCell()
        {
            if (dataGridView2.DataSource != null)
            {
                tbIDDia.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                tbTieuDe.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                tbDanhMuc.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                tbPhiTreHan.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                tbNgayThue.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                tbNgayTraDuKien.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                tbNgayTraThucTe.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

                DateTime dukien = (DateTime)dataGridView2.CurrentRow.Cells[5].Value;
                DateTime thucte = (DateTime)dataGridView2.CurrentRow.Cells[6].Value;

                TimeSpan s = thucte.Subtract(dukien);
                tbSoNgayTre.Text = s.Days.ToString();
            }
            else
            {
                tbIDDia.Text = tbTieuDe.Text = tbDanhMuc.Text = tbPhiTreHan.Text = tbNgayThue.Text = tbNgayTraDuKien.Text = tbNgayTraThucTe.Text = tbSoNgayTre.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXacNhanTraPhi_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) // trường hợp chọn checkbox "Thanh toán tất cả"
            {
                if(ctptbll.ThayDoiTrangThaiNoPhiTreTatCa(tbIdKH.Text))
                {
                    XtraMessageBox.Show("Đã thanh toán thành công TẤT CẢ khoản phí trễ");
                    dataGridView2.DataSource = null;
                    tbIdKH.Focus();
                    checkBox1.Enabled = false;
                    tbSoTienKhachTra.Enabled = false;
                    clearALLtextbox();
                    btnXacNhanTraPhi.Enabled = false;
                    btnXacNhanIDKhach.Text = "Xác Nhận";
                }
                else
                {
                    XtraMessageBox.Show("Thanh toán thất bại !");
                }
            }
            else //Trường hợp nhập số tiền khách đưa
            {
                if(tbSoTienKhachTra.Text == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập số tiền khách trả");
                    tbSoTienKhachTra.Focus();
                }
                else
                {
                    if (Convert.ToDecimal(tbSoTienKhachTra.Text) < dmbll.PhiTreMin())
                    {
                        XtraMessageBox.Show("Số tiền này không đủ để trả bất kì khoản nợ phí trễ nào . Vui lòng nhập lại số tiền !");
                        tbSoTienKhachTra.Focus();
                    }
                    else
                    {
                        decimal tienthoi = ctptbll.ThayDoiTrangThaiNoPhiTreWithMoney(tbIdKH.Text, Convert.ToDecimal(tbSoTienKhachTra.Text));
                        XtraMessageBox.Show("Đã thanh toán thành công CÁC khoản phí trễ tương ứng với: " + tbSoTienKhachTra.Text + ". Tiền thối trả lại : " + tienthoi.ToString());                

                        if (khbll.TongPhiTreKhachHang(tbIdKH.Text) == 0)
                        {
                            dataGridView2.DataSource = null;
                            btnXacNhanIDKhach.Text = "Xác Nhận";
                            checkBox1.Enabled = false;
                            tbSoTienKhachTra.Enabled = false;
                            tbSoTienKhachTra.Text = "";
                            tbIdKH.Focus();
                            btnXacNhanTraPhi.Enabled = false;
                            clearALLtextbox();
                        }
                        else
                        {
                            dataGridView2.DataSource = null;
                            dataGridView2.DataSource = ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text);
                            loadCell();
                            checkBox1.Enabled = true;
                            tbSoTienKhachTra.Enabled = true;
                            tbSoTienKhachTra.Text = "";
                            tbSoTienKhachTra.Focus();
                            btnXacNhanTraPhi.Enabled = true;
                            
                        }
                    }
                }
            }
        }

        public void clearALLtextbox()
        {
            tbTenKhachHang.Text = "";
            tbDiaChi.Text = "";
            tbSDT.Text = "";
            tbTienNo.Text = "";
            tbIDDia.Text = "";
            tbTieuDe.Text = "";
            tbDanhMuc.Text = "";
            tbPhiTreHan.Text = "";
            tbNgayThue.Text = "";
            tbNgayTraDuKien.Text = "";
            tbNgayTraThucTe.Text = "";
            tbSoNgayTre.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadCell();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbSoTienKhachTra.Enabled = false;
                tbSoTienKhachTra.Text = "";
            }
            else
            {
                tbSoTienKhachTra.Enabled = true;
                tbSoTienKhachTra.Text = "";
            }
        }
        private Form_QuanLy.Form_DangNhap formDN;

        private void btnXoaPhiTre_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[7].Value);
            if (Form_Main.trangThaiLogin != true)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập tài khoản quản lý để thực hiện chức năng này !");
                formDN = new Form_QuanLy.Form_DangNhap();
                formDN.ShowDialog();
            }
            else
            {
                if (ctptbll.XoaMotKhoanPhiTre(id))
                {
                    XtraMessageBox.Show("Đã xóa phí trễ THÀNH CÔNG");
                    if (khbll.TongPhiTreKhachHang(tbIdKH.Text) == 0)
                    {
                        dataGridView2.DataSource = null;
                        btnXacNhanIDKhach.Text = "Xác Nhận";
                        checkBox1.Enabled = false;
                        tbSoTienKhachTra.Enabled = false;
                        tbSoTienKhachTra.Text = "";
                        tbIdKH.Focus();
                        btnXacNhanTraPhi.Enabled = false;
                        clearALLtextbox();
                        btnXoaPhiTre.Enabled = false;
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text);
                        loadCell();
                        checkBox1.Enabled = true;
                        tbSoTienKhachTra.Enabled = true;
                        tbSoTienKhachTra.Text = "";
                        tbSoTienKhachTra.Focus();
                        btnXacNhanTraPhi.Enabled = true;
                        tbTienNo.Text = khbll.TongPhiTreKhachHang(tbIdKH.Text).ToString();
                    }
                }
                else
                    XtraMessageBox.Show("Đã xóa phí trễ THẤT BẠI !");
            }
        }
    }
}