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
    public partial class Form_QuanLyThueDia : DevExpress.XtraEditors.XtraForm
    {
        List<eThongTinPhieuThue> listTtPhieuThue;
        KhachHangBLL khbll;
        DiaBLL diabll;
        TieuDeBLL tdbll;
        DanhMucBLL dmbll;
        PhieuThueBLL ptbll;
        ChiTietPhieuThueBLL ctptbll;
        public int _IDPhieuThue;
        public static String _IDKhachHangDangThue;
        public Form_QuanLyThueDia()
        {
            InitializeComponent();
            tdbll = new TieuDeBLL();
            khbll = new KhachHangBLL();
            diabll = new DiaBLL();
            dmbll = new DanhMucBLL();
            ptbll = new PhieuThueBLL();
            ctptbll = new ChiTietPhieuThueBLL();

            listTtPhieuThue = new List<eThongTinPhieuThue>();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "###,##";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "###,##";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";

            //dtpkTTNgayTra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //dtpkTTNgayTra.Properties.Mask.EditMask = "dd/MM/yyyy";
            //dtpkTTNgayTra.Properties.Mask.UseMaskAsDisplayFormat = true ;


        }
        #region Hàm tự viết
        public void XoaThongTinKH()
        {
            tbTenKhachHang.Text = "";
            tbDiaChi.Text = "";
            tbSDT.Text = "";
        }

        public void XoaThongTinChiTietDia()
        {
            tbTTIdDia.Text = "";
            tbTTTenDia.Text = "";
            tbTTSoNgayThue.Text = "";
            tbTTNgayTraDia.Text = "";
        }

        public void XoaThongTinPhieuThue()
        {
            tbNgaythue.Text = "";
            tbTongSoDia.Text = "";
            tbTongTienThanhToan.Text = "";
        }
        public void ResetThongTinDia()
        {

            tbIdDia.Text = "";
            tbSoNgayThue.Text = "";
            tbIdDia.Enabled = false;
            tbSoNgayThue.Enabled = false;
            btnThemDia.Enabled = false;
        }

        private void LoadCell()
        {
            tbTTIdDia.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            tbTTTenDia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            tbTTSoNgayThue.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            tbTTNgayTraDia.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value).ToString("dd/MM/yyyy");

        }
        #endregion

        private void Form_QuanLyThueDia_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            LoadCell();
        }





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }


        private void Form_QuanLyThueDia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main.f_QuanLyThueDia = true;
        }

        private void btnXacNhanKH_Click(object sender, EventArgs e)
        {
           
            if (btnXacNhanKH.Text == "Xác Nhận")
            {
                eKhachHang ekh = khbll.LayThongTinKhachHang(tbIdKH.Text);
                //kiểm tra khách hàng có rỗng ko
                if (tbIdKH.Text == "")
                {
                    XtraMessageBox.Show("Thiếu thông tin. Vui lòng nhập ID khách hàng !");
                }
                else if (ekh == null)
                {
                    XtraMessageBox.Show("ID Khách hàng không có trong hệ thống !");
                }
                //kiểm tra khoản nợ của khách hàng trong hệ thống
                else if (ctptbll.CapNhatKhoanNoCuaKhachHang(tbIdKH.Text) == true)
                {

                    DialogResult dg = new DialogResult();
                    dg = XtraMessageBox.Show("Khách hàng " + khbll.LayTenKhachHangBangId(tbIdKH.Text) + " còn thiếu " + ctptbll.LayKhoanNoCuaKhachHang(tbIdKH.Text) + " $ phí trễ hạn, bạn có muốn cho khách hàng này thuê tiếp hay không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        dg = DialogResult.Cancel;
                        tbTenKhachHang.Text = ekh.HoTen;
                        tbDiaChi.Text = ekh.DiaChi;
                        tbSDT.Text = ekh.SoDienThoai;
                        tbTienNo.Text = ctptbll.LayKhoanNoCuaKhachHang(tbIdKH.Text).ToString();
                        btnXacNhanKH.Text = "Hủy";

                        tbIdDia.Enabled = true;
                        btnThemDia.Enabled = true;
                        tbIdKH.Enabled = false;
                        tbSoNgayThue.Enabled = true;

                    }
                    else
                    {
                        tbIdDia.Text = "";
                        dg = DialogResult.Cancel;


                    }

                }
                else if (ekh != null)
                {

                    tbTenKhachHang.Text = ekh.HoTen;
                    tbDiaChi.Text = ekh.DiaChi;
                    tbSDT.Text = ekh.SoDienThoai;
                    tbTienNo.Text = "0";
                    btnXacNhanKH.Text = "Hủy";

                    tbIdDia.Enabled = true;
                    btnThemDia.Enabled = true;
                    tbIdKH.Enabled = false;
                    tbSoNgayThue.Enabled = true;

                }
            }
            else if (btnXacNhanKH.Text == "Hủy")
            {
                DialogResult dg = new DialogResult();
                dg = XtraMessageBox.Show("Chưa hoàn tất phiếu thuê, bạn có muốn hủy không, thao tác này không thể hoàn tác !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    tbIdKH.Text = "";
                    XoaThongTinKH();
                    btnXacNhanKH.Text = "Xác Nhận";
                    tbIdDia.Text = "";
                    tbSoNgayThue.Text = "";
                    tbIdDia.Enabled = false;
                    btnThemDia.Enabled = false;
                    tbIdKH.Enabled = true;
                    tbSoNgayThue.Enabled = false;

                    XoaThongTinChiTietDia();

                    tbNgaythue.Text = "";
                    tbTongSoDia.Text = "";
                    tbTongTienThanhToan.Text = "";

                    btnXoaKhoiPhieuThue.Enabled = false;
                    btnXacNhanThue.Enabled = false;

                }
                else
                {
                    dg = DialogResult.Cancel;
                }

            }


        }



        private void btnThemDia_Click(object sender, EventArgs e)
        {
            if (tbIdDia.Text == "" || tbSoNgayThue.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ ID đĩa và số ngày thuê !");
            }
            else if (tdbll.LayTenTieuDeBangIdDia(tbIdDia.Text) == "null")
            {
                XtraMessageBox.Show("Không có Đĩa này trong hệ thống, vui lòng nhập ID khác !");
            }
            else if (diabll.kiemTraDiaTaiCuaHang(tbIdDia.Text))
            {
                XtraMessageBox.Show("Đĩa đang được thuê bởi người khác, vui lòng nhập ID khác !");
            }
            else
            {
                //Tạo đối tượng add vào list rồi đẩy ra datagridview

                DateTime ngayTraDia = DateTime.Now.AddDays(Convert.ToInt32(tbSoNgayThue.Text));

                string tenDia = tdbll.LayTenTieuDeBangIdDia(tbIdDia.Text);
                string tenDanhMuc = dmbll.LayTenDanhMucBangIdDia(tbIdDia.Text);

                decimal phiThue = dmbll.LayPhiThueBangIdDia(tbIdDia.Text);
                decimal phiTreHan = dmbll.LayPhiTreHanBangIdDia(tbIdDia.Text);
                eThongTinPhieuThue ettpt = new eThongTinPhieuThue(tbIdDia.Text, tenDia, tenDanhMuc, Convert.ToDecimal(phiThue) * Convert.ToDecimal(tbSoNgayThue.Text), Convert.ToDecimal(phiTreHan), Convert.ToInt32(tbSoNgayThue.Text), ngayTraDia, _IDPhieuThue);

                //kiểm tra list có rỗng ko
                if (listTtPhieuThue.Count() == 0)
                {
                    listTtPhieuThue.Add(ettpt);
                    var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuThue);
                    var source = new BindingSource(bindingList, null);
                    dataGridView1.DataSource = source;
                    thayDoiThongTinPhieuThue(listTtPhieuThue);

                    btnXoaKhoiPhieuThue.Enabled = true;
                    btnXacNhanThue.Enabled = true;
                }
                else if (listTtPhieuThue != null)
                {
                    int temp = 0;
                    foreach (eThongTinPhieuThue item in listTtPhieuThue)
                    {
                        if (item.IdDia == tbIdDia.Text)
                        {
                            temp = temp + 1;
                        }
                    }
                    if (temp == 0)
                    {
                        listTtPhieuThue.Add(ettpt);
                        var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuThue);
                        var source = new BindingSource(bindingList, null);
                        dataGridView1.DataSource = source;
                        thayDoiThongTinPhieuThue(listTtPhieuThue);

                        btnXoaKhoiPhieuThue.Enabled = true;
                        btnXacNhanThue.Enabled = true;
                    }
                    else if (temp > 0)
                    {
                        XtraMessageBox.Show("Đĩa này đã có trong phiếu thuê, vui lòng không nhập lại !");
                    }
                }
            }
        }
        public void thayDoiThongTinPhieuThue(List<eThongTinPhieuThue> listTTPT)
        {
            decimal tongPhiThue = 0;
            int tongSoDia = 0;
            foreach (eThongTinPhieuThue item in listTTPT)
            {
                tongPhiThue = tongPhiThue + item.PhiThue;
                tongSoDia++;
            }
            tbNgaythue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbTongSoDia.Text = tongSoDia.ToString();
            tbTongTienThanhToan.Text = tongPhiThue.ToString();
        }

        private void btnXoaKhoiPhieuThue_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Bạn có muốn bỏ đĩa này ra khỏi phiếu thuê hay không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                foreach (eThongTinPhieuThue item in listTtPhieuThue)
                {
                    if (item.IdDia == tbTTIdDia.Text)
                    {
                        listTtPhieuThue.Remove(item);
                        var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuThue);
                        var source = new BindingSource(bindingList, null);
                        dataGridView1.DataSource = source;
                        thayDoiThongTinPhieuThue(listTtPhieuThue);
                        break;
                    }
                }

            }
            else
            {
                dg = DialogResult.Cancel;
            }
        }

        private decimal tinhTongPhiThue(List<eThongTinPhieuThue> list)
        {
            decimal tong = 0;

            foreach (eThongTinPhieuThue tt in list)
            {
                tong += tt.PhiThue;
            }

            return tong;
        }

        private void btnXacNhanThue_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = XtraMessageBox.Show("Chỉ xác nhận sau khi khách hàng đã nhận đủ đĩa và thanh toán, nếu đã ok, vui lòng xác nhận !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                _IDPhieuThue = ptbll.LayIdPhieuThueLonNhat() + 1;
                ePhieuThue ept = new ePhieuThue();
                ept.IdPhieuThue = _IDPhieuThue;
                ept.NgayTao = DateTime.Now;
                ept.TongPhiThue = tinhTongPhiThue(listTtPhieuThue);
                ept.IdKhachHang = tbIdKH.Text;

                try
                {
                    if (ptbll.ThemPhieuThue(ept))
                    {
                        if (ctptbll.ThemChiTietPhieuThue(listTtPhieuThue, _IDPhieuThue))
                        {
                            XtraMessageBox.Show("Đã lưu thông tin phiếu thuê vào hệ thống !");
                            _IDPhieuThue = 0;

                            btnXacNhanKH.Text = "Xác Nhận";
                            tbIdKH.Enabled = true;
                            tbIdKH.Text = "";

                            btnXoaKhoiPhieuThue.Enabled = false;
                            btnXacNhanThue.Enabled = false;

                            XoaThongTinChiTietDia();
                            XoaThongTinPhieuThue();
                            ResetThongTinDia();

                            listTtPhieuThue.Clear();
                            var bindingList = new BindingList<eThongTinPhieuThue>(listTtPhieuThue);
                            var source = new BindingSource(bindingList, null);
                            dataGridView1.DataSource = source;
                        }
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Lỗi" + ex);
                }

            }
            else
            {
                dg = DialogResult.Cancel;
            }
        }

        private void tbTTIdDia_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}