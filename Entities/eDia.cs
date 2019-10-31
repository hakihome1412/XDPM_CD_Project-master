using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eDia
    {
        public String IdDia { get; set; }
        public String TrangThaiThue { get; set; }
        public bool TrangThaiXoa { get; set; }
        public String IdTieuDe { get; set; }



        //Thông tin phụ
        public String TenTieuDe { get; set; }
        public String TenDanhMuc { get; set; }
        public decimal PhiThue { get; set; }
        public decimal PhiTreHan { get; set; }
        

        public eDia(String idDia, String trangThaiThue, bool trangThaiXoa, String idTieuDe)
        {
            IdDia = idDia;
            TrangThaiThue = trangThaiThue;
            TrangThaiXoa = trangThaiXoa;
            IdTieuDe = idTieuDe;

        }


        //Dùng cho dtgv đĩa bên form quản lý kho đĩa
        public eDia(String idDia, String trangThaiThue)
        {
            IdDia = idDia;
            TrangThaiThue = trangThaiThue;           

        }

        public eDia(string idDia, string tenTieuDe, string tenDanhMuc, decimal phiThue, decimal phiTreHan)
        {
            IdDia = idDia;
            TenTieuDe = tenTieuDe;
            TenDanhMuc = tenDanhMuc;
            PhiThue = phiThue;
            PhiTreHan = phiTreHan;
        }


        public eDia()
        {

        }

     
    }
}
