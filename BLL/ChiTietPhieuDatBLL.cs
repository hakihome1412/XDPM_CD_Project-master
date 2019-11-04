using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ChiTietPhieuDatBLL
    {
        QLCDDataContext db;
        public ChiTietPhieuDatBLL()
        {
            db = new QLCDDataContext();
        }

        public int LayIdChiTietPhieuDatLonNhat()
        {
            if (db.ChiTietPhieuDats.Count() == 0)
                return 0;
            int idctpd = (from a in db.ChiTietPhieuDats
                          orderby a.IdChiTietPhieuDat descending
                          select (int)a.IdChiTietPhieuDat
                            ).Take(1).First();

            return idctpd;
        }

        public bool ThemChiTietPhieuDat(List<eThongTinPhieuThue> listTtPD, int idPhieuDat)
        {
            foreach (eThongTinPhieuThue item in listTtPD)
            {
                ChiTietPhieuDat ctpd = new ChiTietPhieuDat();
                ctpd.IdChiTietPhieuDat = LayIdChiTietPhieuDatLonNhat() + 1;
                ctpd.IdTieuDe = item.IdTieuDe;
                ctpd.TenTieuDe = item.TenTieuDe;
                ctpd.NgayXuLyDonDat = null;
                ctpd.IdPhieuDat = idPhieuDat;

                db.ChiTietPhieuDats.InsertOnSubmit(ctpd);
                db.SubmitChanges();

            }
                return true;
        }

        public bool XoaChiTietPhieuDat(int idChiTiet)
        {
            ChiTietPhieuDat ct = db.ChiTietPhieuDats.SingleOrDefault(p => p.IdChiTietPhieuDat == idChiTiet);
            if(ct != null)
            {
                db.ChiTietPhieuDats.DeleteOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }

            return false;

        }

        public List<eThongTinPhieuThue> LayDanhSachChiTietPhieuDatTheoIDKhach2(string idKhachHang)
        {
            List<eThongTinPhieuThue> list = new List<eThongTinPhieuThue>();

            var listtam = (from a in db.KhachHangs
                           join b in db.PhieuDats on a.IdKhachHang equals b.IdKhachHang
                           join c in db.ChiTietPhieuDats on b.IdPhieuDat equals c.IdPhieuDat
                           where a.IdKhachHang == idKhachHang
                           select new
                           {
                               c.IdChiTietPhieuDat,
                               c.IdTieuDe,
                               c.TenTieuDe,
                               b.NgayTao,
                               c.NgayXuLyDonDat,
                               c.IdPhieuDat
                           });

            foreach (var item in listtam)
            {
                //eChiTietPhieuDat ct = new eChiTietPhieuDat(item.IdChiTietPhieuDat, item.IdTieuDe, item.TenTieuDe, (DateTime)item.NgayXuLyDonDat,(int)item.IdPhieuDat);
                eThongTinPhieuThue ct = new eThongTinPhieuThue();
                ct.IdChiTietPhieuDat = item.IdChiTietPhieuDat;
                ct.IdPhieuDat = (int)item.IdPhieuDat;
                ct.IdTieuDe = item.IdTieuDe;
                ct.NgayDat = (DateTime)item.NgayTao;
                if (item.NgayXuLyDonDat == null)
                    ct.NgayXuLyDonDat = new DateTime(1900, 1, 1, 0, 0, 0);
                else
                    ct.NgayXuLyDonDat = (DateTime)item.NgayXuLyDonDat;
                ct.TenTieuDe = item.TenTieuDe;

                list.Add(ct);
            }

            if (list.Count() == 0)
                return null;
            return list;
        }

        public List<eChiTietPhieuDat> LayDanhSachChiTietPhieuDatTheoIDKhach(string idKhachHang)
        {
            List<eChiTietPhieuDat> list = new List<eChiTietPhieuDat>();

            var listtam = (from a in db.KhachHangs
                           join b in db.PhieuDats on a.IdKhachHang equals b.IdKhachHang
                           join c in db.ChiTietPhieuDats on b.IdPhieuDat equals c.IdPhieuDat
                           where a.IdKhachHang == idKhachHang
                           select new
                           {
                               c.IdChiTietPhieuDat,
                               c.IdTieuDe,
                               c.TenTieuDe,
                               c.NgayXuLyDonDat,
                               c.IdPhieuDat
                           });

            foreach (var item in listtam)
            {
                //eChiTietPhieuDat ct = new eChiTietPhieuDat(item.IdChiTietPhieuDat, item.IdTieuDe, item.TenTieuDe, (DateTime)item.NgayXuLyDonDat,(int)item.IdPhieuDat);
                eChiTietPhieuDat ct = new eChiTietPhieuDat();
                ct.IdChiTietPhieuDat = item.IdChiTietPhieuDat;
                ct.IdPhieuDat = (int)item.IdPhieuDat;
                ct.IdTieuDe = item.IdTieuDe;
                if (item.NgayXuLyDonDat == null)
                    ct.NgayXuLyDonDat = new DateTime(1900, 1, 1, 0, 0, 0);
                else
                    ct.NgayXuLyDonDat = (DateTime)item.NgayXuLyDonDat;
                ct.TenTieuDe = item.TenTieuDe;

                list.Add(ct);
            }

            if (list.Count() == 0)
                return null;
            return list;
        }
    }
}
