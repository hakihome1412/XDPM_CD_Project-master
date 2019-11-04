using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class PhieuDatBLL
    {
        QLCDDataContext db;
        public PhieuDatBLL()
        {
            db = new QLCDDataContext();
        }

        public int LayIdPhieuDatLonNhat()
        {
            if (db.PhieuDats.Count() == 0)
                return 0;
            int idpd = (from a in db.PhieuDats
                        orderby a.IdPhieuDat descending
                        select (int)a.IdPhieuDat
                            ).Take(1).First();
            return idpd;
        }

        public bool ThemPhieuDat(ePhieuDat epd)
        {
            PhieuDat pd = new PhieuDat();
            pd.IdPhieuDat = epd.IdPhieuDat;
            pd.NgayTao = epd.NgayTao;
            pd.IdKhachHang = epd.IdKhachHang;
            if (!db.PhieuDats.Contains(pd))
            {
                db.PhieuDats.InsertOnSubmit(pd);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
