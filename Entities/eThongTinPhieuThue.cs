using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eThongTinPhieuThue
    {  
        public String IdDia { get; set; }
        public String TenDia { get; set; }
        public String DanhMuc{ get; set; }
        public decimal PhiThue { get; set; }
        public DateTime NgayTraDiaDuKien { get; set; }
        public decimal PhiTreHan { get; set; }
        public string IdKhachHang { get; set; }
        public DateTime NgayTraDiaThucTe { get; set; }
        public bool TrangThai { get; set; }
        public int IdPhieuThue { get; set; }
        public int SoNgayThue { get; set; }



        //Thông tin phụ
        public DateTime NgayThue { get; set; }
        public int SoNgayTreHan { get; set; }
        public int IdChiTietPhieuThue { get; set; }

        public eThongTinPhieuThue(string idDia, string tenDia, string danhMuc, decimal phiThue, decimal phiTreHan,int soNgayThue, DateTime ngayTraDia, int idPhieuThue)
        {
            IdDia = idDia;
            TenDia = tenDia;
            DanhMuc = danhMuc;
            PhiThue = phiThue;            
            PhiTreHan = phiTreHan;          
            SoNgayThue = soNgayThue;
            NgayTraDiaDuKien = ngayTraDia;
            IdPhieuThue = idPhieuThue;
        }

        public eThongTinPhieuThue(DateTime ngayThue, DateTime ngayTraDia,  decimal phiTreHan, int soNgayThue)
        {
            NgayThue = ngayThue;
            NgayTraDiaDuKien = ngayTraDia;
            SoNgayThue = soNgayThue;
            PhiTreHan = phiTreHan;
        }
        public eThongTinPhieuThue()
        {

        }
    }
}
