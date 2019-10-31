using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eNhanVien
    {
         public String IdNhanVien { get; set; }
         public String HoTen { get; set; }
         public String DiaChi { get; set; }
         public String SoDienThoai { get; set; }



        public eNhanVien(string idNhanVien, string hoTen, string diaChi, string soDienThoai)
        {
            IdNhanVien = idNhanVien;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }


        public eNhanVien()
        {
                
        }
    }
}
