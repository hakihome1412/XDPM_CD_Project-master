using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class eDanhMuc
    {
        public int IdDanhMuc { get; set; }
        public String TenDanhMuc { get; set; }
        public bool TrangThaiXoa { get; set; }
        public decimal PhiThue { get; set; }
        public decimal PhiTreHan { get; set; }
        public int SoNgayThue { get; set; }



        public eDanhMuc(int idDanhMuc, string tenDanhMuc,bool trangThaiXoa,decimal phiThue, decimal phiTreHan, int soNgayThue)
        {
            IdDanhMuc = idDanhMuc;
            TenDanhMuc = tenDanhMuc;
            TrangThaiXoa = trangThaiXoa;
            PhiThue = phiThue;
            PhiTreHan = PhiTreHan;
            SoNgayThue = soNgayThue;
        }

        public eDanhMuc(string tenDanhMuc)
        {
            TenDanhMuc = tenDanhMuc;
        }
        public eDanhMuc()
        {

        }

    }
}
