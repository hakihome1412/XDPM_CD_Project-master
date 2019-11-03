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
        public Form_QuanLyPhiTre()
        {
            khbll = new KhachHangBLL();
            ctptbll = new ChiTietPhieuThueBLL();
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
        }

        private void Form_QuanLyPhiTre_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyPhiTre = true;
        }

        private void Form_QuanLyPhiTre_Load(object sender, EventArgs e)
        {
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

                        if (ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text) == null)
                            XtraMessageBox.Show("Không có dữ liệu");
                        else
                        {
                            dataGridView2.DataSource = ctptbll.DanhSachPhiTretheoIDKhachHang(tbIdKH.Text);
                            loadCell();
                        }
                    }
                    
                }
                else //Nếu là Hủy
                {
                    btnXacNhanIDKhach.Text = "Xác Nhận";
                }
            }
        }

        private void loadCell()
        {
            tbIDDia.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            tbTieuDe.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            tbDanhMuc.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            tbPhiTreHan.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            tbNgayThue.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            tbNgayTraDuKien.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            tbNgayTraThucTe.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            DateTime dukien = (DateTime) dataGridView2.CurrentRow.Cells[5].Value;
            DateTime thucte = (DateTime) dataGridView2.CurrentRow.Cells[6].Value;

            TimeSpan s = thucte.Subtract(dukien);
            tbSoNgayTre.Text = s.Days.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
                MessageBox.Show("hello");
            else
                MessageBox.Show("bye");
        }
    }
}