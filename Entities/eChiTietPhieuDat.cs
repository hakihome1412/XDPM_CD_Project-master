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
        public string IdTieuDe { get; set; }
        public string TenTieuDe { get; set; }
        public DateTime NgayXuLyDonDat { get; set; }
        public int IdPhieuDat { get; set; }



        public eChiTietPhieuDat(int idChiTietPhieuDat, string idTieuDe, string tenTieuDe , DateTime ngayXuLyDonDat, int idPhieuDat)
        {
            IdChiTietPhieuDat = idChiTietPhieuDat;
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;
            NgayXuLyDonDat = ngayXuLyDonDat;
            IdPhieuDat = idPhieuDat;
        }


        public eChiTietPhieuDat()
        {

        }
     
    }
}
