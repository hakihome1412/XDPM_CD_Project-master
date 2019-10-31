using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class NhanVienBLL
    {
        QLCDDataContext db;

        public NhanVienBLL()
        {
            db = new QLCDDataContext();
        }

        public eNhanVien KiemTraDangNhap(string userName, string passWord)
        {
            eNhanVien nv1;
            var nv = (from a in db.NhanViens
                       join b in db.TaiKhoans on a.IdNhanVien equals b.IdNhanVien              
                       where b.TenTaiKhoan == userName && b.MatKhau== passWord 
                       select a).FirstOrDefault();
            if(nv != null)
            {
                nv1 = DataToEntity(nv);
                return nv1;
            }
            nv1 = null;
            return nv1;
        }

        public eNhanVien DataToEntity(NhanVien nv)
        {
            eNhanVien nv1 = new eNhanVien();
            nv1.IdNhanVien = nv.IdNhanVien;
            nv1.HoTen = nv.HoTen;
            nv1.DiaChi = nv.DiaChi;
            nv1.SoDienThoai = nv.SoDienThoai;
            return nv1;
        }
       

        public bool SuaNhanVien(eNhanVien env)
        {
            NhanVien nv = new NhanVien();
            nv = db.NhanViens.Where(a => a.IdNhanVien == env.IdNhanVien).SingleOrDefault();
            if (nv != null)
            {
                nv.HoTen = env.HoTen;
                nv.DiaChi = env.DiaChi;
                nv.SoDienThoai = env.SoDienThoai;

                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
