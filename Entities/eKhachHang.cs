using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eKhachHang
    {
        public String IdKhachHang { get; set; }
        public String HoTen { get; set; }
        public String DiaChi { get; set; }
        public String SoDienThoai { get; set; }
        public bool TrangThaiXoa { get; set; }


        //Thong tin phụ
        public decimal PhiTreHanPhaiTra { get; set; }



        public eKhachHang(string idKhachHang, string hoTen, string diaChi, string soDienThoai, bool trangThaiXoa)
        {
            IdKhachHang = idKhachHang;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            TrangThaiXoa = trangThaiXoa;
        }

        public eKhachHang( string hoTen, string diaChi, string soDienThoai, decimal phiTreHanPhaiTra)
        {        
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            PhiTreHanPhaiTra = phiTreHanPhaiTra;
            
        }

        public eKhachHang()
        {

        }


    }
}
