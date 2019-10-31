using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eChiTietPhieuThue
    {
        public int IdChiTietPhieuThue { get; set; }
        public String IdDia { get; set; }
        public DateTime NgayTraDiaDuKien { get; set; }
        public decimal PhiThue{ get; set; }
        public DateTime NgayTraDiaThucTe { get; set; }
        public decimal PhiTre { get; set; }
        public bool TrangThaiNoPhiTre { get; set; }
        public bool TrangThaiTraPhiTre { get; set; }
        public int IdPhieuThue { get; set; }

        public eChiTietPhieuThue(int idChiTietPhieuThue, string idDia, DateTime ngayTraDiaDuKien,decimal phiThue, DateTime ngayTraDiaThucTe, decimal phiTre, bool trangThaiNoPhiTre, bool trangThaiTraPhiTre, int idPhieuThue)
        {
            IdChiTietPhieuThue = idChiTietPhieuThue;
            IdDia = idDia;
            NgayTraDiaDuKien = ngayTraDiaDuKien;
            PhiThue = phiThue;
            NgayTraDiaThucTe = ngayTraDiaThucTe;
            PhiTre = phiTre;
            TrangThaiNoPhiTre = trangThaiNoPhiTre;
            TrangThaiTraPhiTre = trangThaiTraPhiTre;
            IdPhieuThue = idPhieuThue;
        }

        public eChiTietPhieuThue()
        {

        }

     
    }
}
