using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class TaiKhoanBLL
    {
        QLCDDataContext db;
        public TaiKhoanBLL()
        {
            db = new QLCDDataContext();
        }
 
        public eTaiKhoan LayTaiKhoan(string tenDN)
        {
            eTaiKhoan etk;
            var tk = (from a in db.TaiKhoans
                      where a.TenTaiKhoan == tenDN
                      select a).FirstOrDefault();
            if (tk != null)
            {
                etk = DataToEntity(tk);
                return etk;
            }
            etk = null;
            return etk;
        }
        public eTaiKhoan DataToEntity(TaiKhoan tk)
        {
            eTaiKhoan etk = new eTaiKhoan();
            etk.IdTaiKhoan = tk.IdTaiKhoan;
            etk.TenTaiKhoan = tk.TenTaiKhoan;
            etk.MatKhau = tk.MatKhau;
            etk.IdNhanVien = tk.IdNhanVien;
            return etk;
        }

        public bool SuaTaiKhoan(string tenTK, string matKhau)
        {
            TaiKhoan tk = new TaiKhoan();
            tk = db.TaiKhoans.Where(a => a.TenTaiKhoan == tenTK).SingleOrDefault();
            if (tk != null)
            {
                tk.MatKhau = matKhau;

                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
