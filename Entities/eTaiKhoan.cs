using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eTaiKhoan
    {
        public int IdTaiKhoan { get; set; }
        public String TenTaiKhoan { get; set; }
        public String MatKhau { get; set; }
        public String IdNhanVien { get; set; }


        public eTaiKhoan(int idTaiKhoan, string tenTaiKhoan, string matKhau, string idNhanVien)
        {
            IdTaiKhoan = idTaiKhoan;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            IdNhanVien = idNhanVien;
        }


        public eTaiKhoan()
        {

        }
    }
}
