using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ePhieuDat
    {
        public int IdPhieuDat { get; set; }
        public DateTime NgayTao { get; set; }
        public String IdKhachHang { get; set; }



        public ePhieuDat(int idPhieuDat, DateTime ngayTao, string idKhachHang)
        {
            IdPhieuDat = idPhieuDat;
            NgayTao = ngayTao;
            IdKhachHang = idKhachHang;
        }


        public ePhieuDat()
        {

        }
    }
}
