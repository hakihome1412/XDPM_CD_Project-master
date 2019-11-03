﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ChiTietPhieuThueBLL
    {
        QLCDDataContext db;
        public ChiTietPhieuThueBLL()
        {
            db = new QLCDDataContext();
        }

        public int LayIdChiTietPhieuThueLonNhat()
        {
            if (db.ChiTietPhieuThues.Count() == 0)
                return 0;
            int idctpt = (from a in db.ChiTietPhieuThues
                          orderby a.IdChiTietPhieuThue descending
                          select (int)a.IdChiTietPhieuThue
                            ).Take(1).First();

            return idctpt;
        }

        //public bool ThayDoiTrangThaiNoPhiTreTatCa(List<eThongTinPhieuThue> list,string idKhachHang)
        //{
        //    //List<ChiTietPhieuThue> listchinh = new List<ChiTietPhieuThue>();
        //    foreach (var item in list)
        //    {
        //        foreach (var itemm in db.ChiTietPhieuThues)
        //        {
        //            if
        //        }
        //    }
        //    if(db.ChiTietPhieuThues.Contains())
        //}

        public List<eThongTinPhieuThue> DanhSachPhiTretheoIDKhachHang(string idKhachHang)
        {
            List<eThongTinPhieuThue> list = new List<eThongTinPhieuThue>();
            var listtam = (from a in db.KhachHangs
                        join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                        join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                        join d in db.Dias on c.IdDia equals d.IdDia
                        join e in db.TieuDes on d.IdTieuDe equals e.IdTieuDe
                        join f in db.DanhMucs on e.IdDanhMuc equals f.IdDanhMuc
                        where a.IdKhachHang == idKhachHang && c.TrangThaiNoPhiTre == true && c.TrangThaiTraPhiTre == false && c.NgayTraDiaThucTe != null
                        select new
                        {
                            c.IdChiTietPhieuThue,
                            b.NgayTao,
                            c.NgayTraDiaDuKien,
                            c.NgayTraDiaThucTe,
                            d.IdDia,
                            f.TenDanhMuc,
                            e.TenTieuDe,
                            f.PhiTreHan
                        });

            foreach (var item in listtam)
            {
                eThongTinPhieuThue tt = new eThongTinPhieuThue(item.IdChiTietPhieuThue,item.IdDia, item.TenTieuDe, item.TenDanhMuc, (decimal)item.PhiTreHan, (DateTime)item.NgayTao, (DateTime)item.NgayTraDiaDuKien, (DateTime)item.NgayTraDiaThucTe);
                list.Add(tt);
            }

            if (list.Count() == 0)
                return null;
            return list;
            
        }

        public eThongTinPhieuThue LayThongTinPhieuThue(string idDia,string idKhachHang)
        {
            eThongTinPhieuThue ettpt = new eThongTinPhieuThue();
            var ttpt = (from a in db.KhachHangs
                        join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                        join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                        join d in db.Dias on c.IdDia equals d.IdDia
                        join e in db.TieuDes on d.IdTieuDe equals e.IdTieuDe
                        join f in db.DanhMucs on e.IdDanhMuc equals f.IdDanhMuc
                     where a.IdKhachHang == idKhachHang && c.IdDia == idDia && c.NgayTraDiaThucTe == null
                     select new
                     {
                         c.IdChiTietPhieuThue,
                         b.NgayTao,
                         c.NgayTraDiaDuKien,
                         c.PhiTre,
                         f.SoNgayThue                    
                     }).Single();
            ettpt.IdChiTietPhieuThue = Convert.ToInt32(ttpt.IdChiTietPhieuThue);
            ettpt.NgayThue = Convert.ToDateTime( ttpt.NgayTao);
            ettpt.NgayTraDiaDuKien = Convert.ToDateTime( ttpt.NgayTraDiaDuKien);
            ettpt.SoNgayThue = (int)ttpt.SoNgayThue;
            TimeSpan songaytrehan = DateTime.Now.Subtract((DateTime)ttpt.NgayTraDiaDuKien);
            if (songaytrehan.Days < 0)
            {
                ettpt.SoNgayTreHan = 0;
                ettpt.PhiTreHan = 0;
            }
            else
            {
                ettpt.SoNgayTreHan = songaytrehan.Days;
                ettpt.PhiTreHan = (decimal)ttpt.PhiTre;
            }
                
            return ettpt;
        }

        public bool ThemChiTietPhieuThue(List<eThongTinPhieuThue> listTtPT, int idPhieuThue)
        {
            foreach (eThongTinPhieuThue item in listTtPT)
            {
                ChiTietPhieuThue ctpt = new ChiTietPhieuThue();
                ctpt.IdChiTietPhieuThue = LayIdChiTietPhieuThueLonNhat()+1;
                ctpt.IdDia = item.IdDia;
                ctpt.NgayTraDiaDuKien = item.NgayTraDiaDuKien;
                ctpt.PhiThue = item.PhiThue;
                ctpt.NgayTraDiaThucTe = null;
                ctpt.PhiTre = item.PhiTreHan;
                ctpt.TrangThaiNoPhiTre = false;
                ctpt.TrangThaiTraPhiTre = false;
                ctpt.IdPhieuThue = idPhieuThue;
              
                db.ChiTietPhieuThues.InsertOnSubmit(ctpt);
                db.SubmitChanges();

                Dia dia = new Dia();               
                dia = db.Dias.Where(a => a.IdDia== item.IdDia).SingleOrDefault();                      
                dia.TrangThaiThue = "duocthue";
                db.SubmitChanges();                
            }
            return true;
        }

        public bool XacNhanTraDia(eChiTietPhieuThue ectpt)
        {
            ChiTietPhieuThue ctpt = new ChiTietPhieuThue();
            ctpt = db.ChiTietPhieuThues.Where(a => a.IdChiTietPhieuThue== ectpt.IdChiTietPhieuThue).SingleOrDefault();
            if (ctpt != null)
            {
                ctpt.NgayTraDiaThucTe = ectpt.NgayTraDiaThucTe;
                ctpt.TrangThaiNoPhiTre = ectpt.TrangThaiNoPhiTre;
                ctpt.TrangThaiTraPhiTre = ectpt.TrangThaiTraPhiTre;

                db.SubmitChanges();
                return true;
            }
            return false;
        }
      
        public bool CapNhatKhoanNoCuaKhachHang(string idKhachHang)
        {
            int count = 0;
            var khs = (from a in db.KhachHangs
                                   join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                                   join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                                   join d in db.Dias on c.IdDia equals d.IdDia
                                   join e in db.TieuDes on d.IdTieuDe equals e.IdTieuDe
                                   join g in db.DanhMucs on e.IdDanhMuc equals g.IdDanhMuc
                                   where a.IdKhachHang == idKhachHang && c.TrangThaiNoPhiTre == true && c.TrangThaiTraPhiTre == false
                       select new {
                                       b.NgayTao,
                                       c.NgayTraDiaDuKien,
                                       c.NgayTraDiaThucTe,
                                       g.PhiTreHan,
                                       c.IdChiTietPhieuThue
                                   }).ToList();

            foreach (var item in khs)
            {
                ChiTietPhieuThue ctpt = new ChiTietPhieuThue();
                ctpt = db.ChiTietPhieuThues.Where(x => x.IdChiTietPhieuThue == item.IdChiTietPhieuThue).SingleOrDefault();
                int soNgayTreHan;
              
                //DateTime a = new DateTime(2019, 10, 15);//some datetime
                DateTime ngayHienTai = DateTime.Now;

                if(DateTime.Compare(ngayHienTai, Convert.ToDateTime(ctpt.NgayTraDiaDuKien)) > 0)
                {
                    TimeSpan ts = ngayHienTai - Convert.ToDateTime(ctpt.NgayTraDiaDuKien);
                    soNgayTreHan = Math.Abs(ts.Days);
                    if (soNgayTreHan > 0)
                    {
                        decimal phiTre = (decimal)item.PhiTreHan;
                    }
                    count = count + 1;
                }                  

            }
            if(count > 0)
            {
                return true;
            }
            return false;

        }
      
        public decimal LayKhoanNoCuaKhachHang(string idKhachHang)
        {
            
            decimal phiPhaiTra = (from a in db.KhachHangs
                       join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                       join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                       where a.IdKhachHang == idKhachHang && c.TrangThaiNoPhiTre ==  true && c.TrangThaiTraPhiTre == false
                       select (decimal) c.PhiTre).Sum();
            return phiPhaiTra;
        }

    }   
}
