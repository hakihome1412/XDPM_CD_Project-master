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

        //Thông tin phụ cho đặt đĩa
        public int IdPhieuDat { get; set; }
        public int IdChiTietPhieuDat { get; set; }
        public String IdTieuDe { get; set; }
        public String TenTieuDe { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayXuLyDonDat { get; set; }

        
        public eThongTinPhieuThue(string idTieuDe, string tenTieuDe,DateTime ngayDat)
        {
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;
            NgayDat = ngayDat;
        }

        public eThongTinPhieuThue(int idChiTietPhieuDat, String idTieuDe, String tenTieuDe, DateTime ngayDat, DateTime ngayXuLyDonDat, int idPhieuDat)
        {
            IdChiTietPhieuDat = idChiTietPhieuDat;
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;
            NgayDat = ngayDat;
            NgayXuLyDonDat = ngayXuLyDonDat;
            IdPhieuDat = idPhieuDat;
        }


        public eThongTinPhieuThue(string idDia, string tenDia, string danhMuc, decimal phiThue, decimal phiTreHan,int soNgayThue, DateTime ngayTraDiaDuKien, int idPhieuThue)
        {
            IdDia = idDia;
            TenDia = tenDia;
            DanhMuc = danhMuc;
            PhiThue = phiThue;            
            PhiTreHan = phiTreHan;          
            SoNgayThue = soNgayThue;
            NgayTraDiaDuKien = ngayTraDiaDuKien;
            IdPhieuThue = idPhieuThue;
        }

        public eThongTinPhieuThue(int idchitiet,string idDia, string tenDia, string danhMuc , decimal phiTreHan ,DateTime ngayThue ,DateTime ngayTraDiaDuKien, DateTime ngayTraDiaThucTe)
        {
            IdChiTietPhieuThue = idchitiet;
            IdDia = idDia;
            TenDia = tenDia;
            DanhMuc = danhMuc;
            PhiTreHan = phiTreHan;
            NgayThue = ngayThue;
            NgayTraDiaDuKien = ngayTraDiaDuKien;
            NgayTraDiaThucTe = ngayTraDiaThucTe;
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
