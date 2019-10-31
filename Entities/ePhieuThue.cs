using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ePhieuThue
    {
        public int IdPhieuThue { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TongPhiThue { get; set; }
        public String IdKhachHang { get; set; }


        public ePhieuThue(int idPhieuThue, DateTime ngayTao, decimal tongPhiThue, string idKhachHang)
        {
            IdPhieuThue = idPhieuThue;
            NgayTao = ngayTao;
            TongPhiThue = tongPhiThue;
            IdKhachHang = idKhachHang;
        }


        public ePhieuThue()
        {

        }
    }
}
