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
    public partial class Form_QuanLyDatDia : DevExpress.XtraEditors.XtraForm
    {
        private KhachHangBLL khbll;
        private TieuDeBLL tdbll;
        private List<eThongTinPhieuThue> listTtPhieuDat;
        private PhieuDatBLL pdbll;
        private ChiTietPhieuDatBLL ctpdbll;
        public int _IDPhieuDat;
        public Form_QuanLyDatDia()
        {
            InitializeComponent();
            dataGridView_phu.AutoGenerateColumns = false;
            dataGridView_chinh.AutoGenerateColumns = false;
        }

        private void Form_QuanLyDatDia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyDatDia = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void Form_QuanLyDatDia_Load(object sender, EventArgs e)
        {
            khbll = new KhachHangBLL();
            tdbll = new TieuDeBLL();
            pdbll = new PhieuDatBLL();
            ctpdbll = new ChiTietPhieuDatBLL();
            listTtPhieuDat = new List<eThongTinPhieuThue>();
            loadComboBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void loadComboBox()
        {
            foreach (eTieuDe item in tdbll.LayDanhSachTenTieuDe())
            {
                comboBox1.Items.Add(item.TenTieuDe);
            }
        }

        private void btnXacNhanKH_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            //eKhachHang ekh = khbll.LayThongTinKhachHang(tbIdKH.Text);
            //tbTenKhachHang.Text = ekh.HoTen;
            if (btnXacNhanKH.Text == "Xác Nhận")
            {
                eKhachHang ekh = khbll.LayThongTinKhachHang(tbIdKH.Text);
                if (tbIdKH.Text == "")
                {
                    XtraMessageBox.Show("Thiếu thông tin. Vui lòng nhập ID khách hàng !");
                }
                else if (ekh == null)
                {
                    XtraMessageBox.Show("ID Khách hàng không có trong hệ thống !");
                }
                else
                {
                    tbTenKhachHang.Text = ekh.HoTen;
                    comboBox1.Enabled = true;
                    btnXacNhanKH.Text = "Hủy";
                    dataGridView_chinh.DataSource = null;
                    dataGridView_chinh.DataSource = ctpdbll.LayDanhSachChiTietPhieuDatTheoIDKhach2(tbIdKH.Text);
                    LoadChiTietChinh();
                    btnXoa.Enabled = true;
                }
            }
            else
            {
                if (btnXacNhanKH.Text == "Hủy")
                {
                    DialogResult dg = new DialogResult();
                    dg = XtraMessageBox.Show("Chưa hoàn tất phiếu đặt, bạn KHÔNG THỂ HOÀN TÁC, bạn có muốn hủy không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        btnXacNhanKH.Text = "Xác Nhận";
                        tbIdKH.Focus();
                        comboBox1.Enabled = btnThemChiTiet.Enabled = btnXoaChiTiet.Enabled = btnXacNhanDat.Enabled = false;
                        dataGridView_phu.DataSource = null;
                        dataGridView_chinh.DataSource = null;
                        clearALLtextbox();
                        btnXoa.Enabled = false;
                    }
                    else
                    {
                        dg = DialogResult.Cancel;
                    }
                }
            }

        }

            private void clearALLtextbox()
        {
            tbIDTieuDe.Text = tbTenTieuDe.Text = tbTenKhachHang.Text = tbIDTieuDe_chinh.Text = tbNgayXuLyDonDat_chinh.Text = tbNgayDat_chinh.Text = tbTenTieuDe_chinh.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                btnThemChiTiet.Enabled = true;

        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            string idtieude = tdbll.layIdTieuDeBangTenTieuDe(comboBox1.SelectedItem.ToString());
            string tentieude = comboBox1.SelectedItem.ToString();
            DateTime ngaydat = DateTime.Now;

            eThongTinPhieuThue ct = new eThongTinPhieuThue(idtieude, tentieude,ngaydat);
            if(listTtPhieuDat.Count == 0)
            {
                listTtPhieuDat.Add(ct);
                var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuDat);
                var source = new BindingSource(bindingList, null);
                dataGridView_phu.DataSource = source;
                btnXoaChiTiet.Enabled = true;
                btnXacNhanDat.Enabled = true;
                LoadChiTietPhu();
            }
            else
            {
                if(listTtPhieuDat != null)
                {
                    int temp = 0;
                    foreach (eThongTinPhieuThue item in listTtPhieuDat)
                    {
                        if (item.TenTieuDe == comboBox1.SelectedItem.ToString())
                        {
                            temp = temp + 1;
                        }
                    }

                    if(temp == 0)
                    {
                        listTtPhieuDat.Add(ct);
                        var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuDat);
                        var source = new BindingSource(bindingList, null);
                        dataGridView_phu.DataSource = source;
                        btnXoaChiTiet.Enabled = true;
                        btnXacNhanDat.Enabled = true;
                        LoadChiTietPhu();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tiêu đề này đã NẰM TRONG danh sách . Vui lòng chọn Tiêu Đề khác !");
                    }
                }
            }
        }

        private void LoadChiTietPhu()
        {
            tbIDTieuDe.Text = dataGridView_phu.CurrentRow.Cells[0].Value.ToString();
            tbTenTieuDe.Text = dataGridView_phu.CurrentRow.Cells[1].Value.ToString();
        }

        private void LoadChiTietChinh()
        {
            tbIDTieuDe_chinh.Text = dataGridView_chinh.CurrentRow.Cells[0].Value.ToString();
            tbTenTieuDe_chinh.Text = dataGridView_chinh.CurrentRow.Cells[1].Value.ToString();
            tbNgayDat_chinh.Text = dataGridView_chinh.CurrentRow.Cells[2].Value.ToString();
            tbNgayXuLyDonDat_chinh.Text = dataGridView_chinh.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            int count = 0;
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn bỏ Tiêu Đề này ra khỏi phiếu đặt không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                foreach (eThongTinPhieuThue item in listTtPhieuDat)
                {
                    if (item.TenTieuDe == tbTenTieuDe.Text)
                    {
                        listTtPhieuDat.Remove(item);
                        var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuDat);
                        var source = new BindingSource(bindingList, null);
                        dataGridView_phu.DataSource = source;
                        count = source.Count;
                        break;
                    }
                }

                if (count == 0)
                {
                    tbIDTieuDe.Text = "";
                    tbTenTieuDe.Text = "";
                    btnXoaChiTiet.Enabled = false;
                    btnXacNhanDat.Enabled = false;
                }
                else
                    LoadChiTietPhu();
            }
        }

        private void dataGridView_phu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadChiTietPhu();
        }

        private void btnXacNhanDat_Click(object sender, EventArgs e)
        {
            _IDPhieuDat = pdbll.LayIdPhieuDatLonNhat() + 1;
            ePhieuDat epd = new ePhieuDat();
            epd.IdPhieuDat = _IDPhieuDat;
            epd.IdKhachHang = tbIdKH.Text;
            epd.NgayTao = DateTime.Now;

            //try
            //{
                if (pdbll.ThemPhieuDat(epd))
                {
                    if (ctpdbll.ThemChiTietPhieuDat(listTtPhieuDat, _IDPhieuDat))
                    {
                        XtraMessageBox.Show("Đã lưu thông tin phiếu đặt vào hệ thống !");
                        btnXacNhanKH.Text = "Xác Nhận";
                        tbIdKH.Enabled = true;
                        tbIdKH.Focus();

                        listTtPhieuDat.Clear();
                        var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuDat);
                        var source = new BindingSource(bindingList, null);
                        dataGridView_phu.DataSource = source;

                        dataGridView_chinh.DataSource = null;
                        dataGridView_chinh.DataSource = ctpdbll.LayDanhSachChiTietPhieuDatTheoIDKhach2(tbIdKH.Text);
                        LoadChiTietChinh();
                    }
                }
            //}
            //catch(Exception ex)
            //{
            //    XtraMessageBox.Show("Lỗi" + ex);
            //}
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            int idChiTiet = Convert.ToInt32(dataGridView_chinh.CurrentRow.Cells[4].Value.ToString());
            if (ctpdbll.XoaChiTietPhieuDat(idChiTiet))
            {
                XtraMessageBox.Show("Đã xóa THÀNH CÔNG");
                dataGridView_chinh.DataSource = null;
                dataGridView_chinh.DataSource = ctpdbll.LayDanhSachChiTietPhieuDatTheoIDKhach2(tbIdKH.Text);
                LoadChiTietChinh();
            }
            else
            {
                XtraMessageBox.Show("Xóa THẤT BẠI , vui lòng thử lại !");
            }
        }

        private void dataGridView_chinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadChiTietChinh();
        }

        private void dataGridView_phu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridView_phu.Rows[e.RowIndex];
            LoadChiTietPhu();
        }
    }
}