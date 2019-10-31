﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class PhieuThueBLL
    {
        QLCDDataContext db;
        public PhieuThueBLL()
        {
            db = new QLCDDataContext();
        }

        public int LayIdPhieuThueLonNhat()
        {
            int idpt = (from a in db.PhieuThues
                         orderby a.IdPhieuThue descending
                         select a.IdPhieuThue
                            ).Take(1).First();
            return Convert.ToInt32(idpt);
        }


        public bool ThemPhieuThue(ePhieuThue ept)
        {
            PhieuThue pt = new PhieuThue();
            pt.IdPhieuThue= ept.IdPhieuThue;
            pt.NgayTao = ept.NgayTao;
            pt.TongPhiThue = ept.TongPhiThue;
            pt.IdKhachHang = ept.IdKhachHang;
            if (!db.PhieuThues.Contains(pt))
            {
                db.PhieuThues.InsertOnSubmit(pt);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
