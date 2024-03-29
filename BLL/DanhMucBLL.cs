﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class DanhMucBLL
    {
        QLCDDataContext db;
        public DanhMucBLL()
        {
            db = new QLCDDataContext();
        }

        public List<DanhMuc> LayDanhSachDanhMuc()
        {
            return db.DanhMucs.Where(x => x.TrangThaiXoa == false).ToList();
        }
        public int layIdDanhMuc(string tenDanhMuc)
        {
            int maTD = (from a in db.DanhMucs
                           where a.TenDanhMuc == tenDanhMuc
                           select a.IdDanhMuc).FirstOrDefault();
            return maTD;
        }

        public decimal PhiTreMin()
        {
            DanhMuc dm1 = db.DanhMucs.SingleOrDefault(p => p.TenDanhMuc == "DVD");
            DanhMuc dm2 = db.DanhMucs.SingleOrDefault(p => p.TenDanhMuc == "Game");

            decimal min = (decimal)dm1.PhiTreHan;

            if(min > (decimal)dm2.PhiTreHan)
            {
                min = (decimal)dm2.PhiTreHan;
                return min;
            }
            return min;
        }

        public eDanhMuc LayDanhMucTheoIDDanhMuc(int idDanhMuc)
        {
            eDanhMuc dm = new eDanhMuc();
            DanhMuc dmm = db.DanhMucs.SingleOrDefault(p => p.IdDanhMuc == idDanhMuc);
            if(dmm != null)
            {
                dm.IdDanhMuc = dmm.IdDanhMuc;
                dm.TenDanhMuc = dmm.TenDanhMuc;
                dm.PhiThue = (decimal) dmm.PhiThue;
                dm.PhiTreHan = (decimal)dmm.PhiTreHan;
                dm.SoNgayThue = (int)dmm.SoNgayThue;
                return dm;
            }
            return null;
        }

        public bool CapNhatPhiThue(int idDanhMuc,decimal phithuemoi)
        {
            DanhMuc dm = db.DanhMucs.SingleOrDefault(p => p.IdDanhMuc == idDanhMuc);
            if(dm != null)
            {
                dm.PhiThue = phithuemoi;
                db.SubmitChanges();
                return true;
            }

            return false;

        }

        public bool CapNhatPhiTreHan(int idDanhMuc, decimal phitrehanmoi)
        {
            DanhMuc dm = db.DanhMucs.SingleOrDefault(p => p.IdDanhMuc == idDanhMuc);
            if (dm != null)
            {
                dm.PhiTreHan = phitrehanmoi;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool CapNhatSoNgayThue(int idDanhMuc, int songaythuemoi)
        {
            DanhMuc dm = db.DanhMucs.SingleOrDefault(p => p.IdDanhMuc == idDanhMuc);
            if (dm != null)
            {
                dm.SoNgayThue = songaythuemoi;
                db.SubmitChanges();
                return true;
            }
            return false;

        }

        public int LayIdDanhMucCaoNhat()
        {
            string td = (from a in db.DanhMucs
                         orderby a.IdDanhMuc descending
                         select a.IdDanhMuc
                            ).Take(1).First().ToString();

            return Convert.ToInt32(td);
        }

        public List<eDanhMuc> LayDanhSachTenDanhMuc()
        {
            List<eDanhMuc> list = new List<eDanhMuc>();
            var query = (from a in db.DanhMucs
                         where a.TrangThaiXoa == false
                         select new
                         {
                             a.TenDanhMuc
                         }).ToList();

            foreach (var item in query)
            {
                eDanhMuc etd = new eDanhMuc(item.TenDanhMuc);
                list.Add(etd);
            }
            return list;

        }

        public string LayTenDanhMucBangIdDia(string idDia)
        {

            var tenDanhMuc = (from a in db.Dias
                             join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
                             join c in db.DanhMucs on b.IdDanhMuc equals c.IdDanhMuc
                             where b.TrangThaiXoa == false && a.IdDia == idDia
                             select c.TenDanhMuc).SingleOrDefault();
            return tenDanhMuc;

        }

        public decimal LayPhiThueBangIdDia(string idDia)
        {
       

            decimal phiThue = (from a in db.Dias
                              join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
                              join c in db.DanhMucs on b.IdDanhMuc equals c.IdDanhMuc
                              where a.IdDia == idDia
                              select (decimal)c.PhiThue).Single();
            return phiThue;

        }

        public decimal LayPhiTreHanBangIdDia(string idDia)
        {

            decimal phiThue = (from a in db.Dias
                           join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
                           join c in db.DanhMucs on b.IdDanhMuc equals c.IdDanhMuc
                           where a.IdDia == idDia
                           select (decimal)c.PhiTreHan).Single();
            return phiThue;

        }

        public int LaySoNgayThueTheoIDDia(string idDia)
        {
            int songaythue = (from a in db.Dias
                              join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
                              join c in db.DanhMucs on b.IdDanhMuc equals c.IdDanhMuc
                              where a.IdDia == idDia
                              select (int)c.SoNgayThue).Single();
            return songaythue;

        }

        public bool ThemDanhMuc(eDanhMuc edm)
        {
            DanhMuc dm = new DanhMuc();
            //dm.IdDanhMuc = edm.IdDanhMuc;
            dm.TenDanhMuc = edm.TenDanhMuc;
            dm.PhiThue = edm.PhiThue;
            dm.PhiTreHan = edm.PhiTreHan;
            dm.TrangThaiXoa = false;
            if (!db.DanhMucs.Contains(dm))
            {
                db.DanhMucs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool SuaDanhMuc(eDanhMuc edm)
        {
            DanhMuc dm = new DanhMuc();
            dm = db.DanhMucs.Where(a => a.IdDanhMuc== edm.IdDanhMuc).SingleOrDefault();
            if (dm != null)
            {
                dm.TenDanhMuc = edm.TenDanhMuc;
                dm.PhiThue = edm.PhiThue;
                dm.PhiTreHan = edm.PhiTreHan;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        //public bool XoaDanhMuc(TieuDe etd)
        //{
        //    TieuDe td = new TieuDe();
        //    td = db.TieuDes.Where(a => a.IdTieuDe== etd.IdTieuDe).SingleOrDefault();
        //    if (td != null)
        //    {
        //        td.TrangThaiXoa = etd.TrangThaiXoa;

        //        db.SubmitChanges();
        //        return true;
        //    }
        //    return false;
        //}

        //Kiểm tra khi thêm danh mục, chống trùng danh mục
        public bool kiemTraTrungDanhMuc(string tenDanhMuc)
        {
          
            List<DanhMuc> td = new List<DanhMuc>();
            td = db.DanhMucs.Where(a => a.TrangThaiXoa == false).ToList();
            foreach (var item in td)
            {
                if(item.TenDanhMuc == tenDanhMuc)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
