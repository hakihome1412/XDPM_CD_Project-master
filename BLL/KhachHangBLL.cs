using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class KhachHangBLL
    {
        QLCDDataContext db;
        public KhachHangBLL()
        {
            db = new QLCDDataContext();
        }
        public List<KhachHang> LayDanhSachKhachHang()
        {
            List<KhachHang> list = db.KhachHangs.Where(x => x.TrangThaiXoa == false).ToList();
            return list;


        }

        public string LayMaKhachHangCaoNhat()
        {
            string kh = (from a in db.KhachHangs
                            orderby a.IdKhachHang descending
                            select a.IdKhachHang
                            ).Take(1).First().ToString();
            return kh;
        }

        //Láy thông tin kh cho form quản lý thuê dĩa.
        public eKhachHang LayThongTinKhachHang(string idKhachHang)
        {
            eKhachHang ekh = new eKhachHang();
            KhachHang kh = db.KhachHangs.Where(x => x.IdKhachHang == idKhachHang).SingleOrDefault();
            if(kh== null)
            {
                ekh = null;
            }
            else if(kh!= null)
            {
                ekh.IdKhachHang = kh.IdKhachHang;
                ekh.HoTen = kh.HoTen;
                ekh.DiaChi = kh.DiaChi;
                ekh.SoDienThoai = kh.SoDienThoai;

                return ekh;
            }
            return ekh;
        }

        public string LayTenKhachHangBangId(string idKhachHang)
        {
            string tenkh = (from a in db.KhachHangs
                         where a.IdKhachHang == idKhachHang
                         select a.HoTen
                           ).Take(1).First().ToString();
            return tenkh;
        }


        public eKhachHang LayThongTinKhachHangBangIdDia(string idDia)
        {
            eKhachHang ekh = new eKhachHang();
            var kh = (from a in db.KhachHangs
                       join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                       join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                       where c.IdDia == idDia
                       select new
                       {
                         a.IdKhachHang,
                         a.HoTen,
                         a.DiaChi,
                         a.SoDienThoai,
                         c.PhiTre
                       }).Single();
            ekh.IdKhachHang = kh.IdKhachHang;
            ekh.HoTen = kh.HoTen;
            ekh.DiaChi = kh.DiaChi;
            ekh.SoDienThoai = kh.SoDienThoai;
            ekh.PhiTreHanPhaiTra = Convert.ToDecimal(kh.PhiTre);

            return ekh;
        }

        public bool ThemKhachHang(eKhachHang ekh)
        {
            KhachHang kh = new KhachHang();
            kh.IdKhachHang = ekh.IdKhachHang;
            kh.HoTen = ekh.HoTen;
            kh.DiaChi = ekh.DiaChi;
            kh.SoDienThoai = ekh.SoDienThoai;
            kh.TrangThaiXoa = false;
            if (!db.KhachHangs.Contains(kh))
            {
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool SuaKhachHang(eKhachHang ekh)
        {
            KhachHang kh = new KhachHang();
            kh = db.KhachHangs.Where(a => a.IdKhachHang == ekh.IdKhachHang).SingleOrDefault();
            if (kh != null)
            {            
                kh.HoTen = ekh.HoTen;
                kh.DiaChi = ekh.DiaChi;         
                kh.SoDienThoai = ekh.SoDienThoai;
             
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaKhachHang(eKhachHang ekh)
        {
            KhachHang kh = new KhachHang();
            kh = db.KhachHangs.Where(a => a.IdKhachHang == ekh.IdKhachHang).SingleOrDefault();
            if (kh != null)
            {
                kh.TrangThaiXoa = ekh.TrangThaiXoa;

                db.SubmitChanges();
                return true;
            }
            return false;
        }


    }
}
