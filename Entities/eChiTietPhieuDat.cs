using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eChiTietPhieuDat
    {
        public int IdChiTietPhieuDat { get; set; }
        public int IdTieuDe { get; set; }
        public int SoLuong { get; set; }
        public int IdPhieuDat { get; set; }



        public eChiTietPhieuDat(int idChiTietPhieuDat, int idTieuDe, int soLuong, int idPhieuDat)
        {
            IdChiTietPhieuDat = idChiTietPhieuDat;
            IdTieuDe = idTieuDe;
            SoLuong = soLuong;
            IdPhieuDat = idPhieuDat;
        }


        public eChiTietPhieuDat()
        {

        }
     
    }
}
