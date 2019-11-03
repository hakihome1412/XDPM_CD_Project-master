using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eTieuDe
    {
        public String IdTieuDe { get; set; }
        public String TenTieuDe { get; set; }
        public int SoLuongDia { get; set; }
        public int SoLuongDiaCoSan { get; set; }
        public bool TrangThaiXoa { get; set; }
        public int IdDanhMuc { get; set; }
        public string TenDanhMuc{ get; set; }

        public eTieuDe(string idTieuDe, string tenTieuDe, int soLuongDia,int soLuongDiaCoSan, bool trangThaiXoa, int idDanhMuc)
        {
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;         
            SoLuongDia = soLuongDia;
            SoLuongDiaCoSan = soLuongDiaCoSan;
            TrangThaiXoa = trangThaiXoa;
            IdDanhMuc = idDanhMuc;
           
        }

        

        //Dùng để hiển thị dtgv form quản lý tiêu đề
        public eTieuDe(string idTieuDe, string tenTieuDe, int soLuongDia)
        {
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;
            SoLuongDia = soLuongDia;
           
   
        }
        //Dùng để hiển thị dtgv form quản lý kho đĩa
        public eTieuDe(string idTieuDe, string tenTieuDe, string tenDanhMuc, int soLuongDia)
        {
            IdTieuDe = idTieuDe;
            TenTieuDe = tenTieuDe;
            TenDanhMuc = tenDanhMuc;
            SoLuongDia = soLuongDia;
        }

        public eTieuDe(string tenTieuDe)
        {    
            TenTieuDe = tenTieuDe;
        }

        public eTieuDe()
        {
                
        }
      
   
    }
}
