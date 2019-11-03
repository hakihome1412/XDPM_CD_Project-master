using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class DiaBLL
    {
        QLCDDataContext db;
        public DiaBLL()
        {
            db = new QLCDDataContext();
        }
        public List<eDia> LayDanhSachDia(string IdTieuDe)
        {
            List<eDia> list = new List<eDia>();
            var query = (from a in db.TieuDes
                                        join b in db.Dias on a.IdTieuDe equals b.IdTieuDe
                                        where b.TrangThaiXoa == false && a.IdTieuDe == IdTieuDe
                                        select new
                                        {
                                            b.IdDia,
                                            b.TrangThaiThue

                                        });
            foreach (var item in query)
            {
                eDia etd = new eDia(item.IdDia,item.TrangThaiThue);
                list.Add(etd);
            }
            return list;
        }
        public string LayMaDiaCaoNhat()
        {
            string td = (from a in db.Dias
                         orderby a.IdDia descending
                         select a.IdDia
                            ).Take(1).First().ToString();
            return td;
        }
       
        public string LayTenNguoiThue(string idDia)
        {
        
            var tenNguoiThue = (from a in db.KhachHangs
                                join b in db.PhieuThues on a.IdKhachHang equals b.IdKhachHang
                                join c in db.ChiTietPhieuThues on b.IdPhieuThue equals c.IdPhieuThue
                                join d in db.Dias on c.IdDia equals d.IdDia
                                where c.IdDia == idDia
                                select new
                                {
                                    a.HoTen
                                }).FirstOrDefault();
            if(tenNguoiThue != null)
            {
                return tenNguoiThue.ToString();
            }
            return "Chưa được thuê";
        }

        public eDia LayThongTinDiaBangIdDia(string idDia)
        {
            eDia ed = new eDia();         
            var d =(from a in db.Dias join b in db.TieuDes on a.IdTieuDe equals b. IdTieuDe
                                        join c in db.DanhMucs on b.IdDanhMuc equals c.IdDanhMuc
                    where a.IdDia == idDia
                    select new
                    {
                        a.IdDia,
                        b.TenTieuDe,
                        c.TenDanhMuc,
                        c.PhiThue,
                        c.PhiTreHan
                    }).Single();
            ed.IdDia = d.IdDia;
            ed.TenTieuDe = d.TenTieuDe;
            ed.TenDanhMuc = d.TenDanhMuc;
            ed.PhiTreHan = Convert.ToDecimal(d.PhiTreHan);
            ed.PhiThue = Convert.ToDecimal(d.PhiThue);
            return ed;
        }
      
        //public string layIdDiaBangTenDia(string tenDia)
        //{
        //    string id = (from a in db.Dias
        //              join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
        //              select  a.IdDia
        //              ).Take(1).First().ToString();
        //    return id;
        //}
        public bool kiemTraTrungDia(string idDia)
        {
            
            List<Dia> td = new List<Dia>();
            td = db.Dias.Where(a => a.TrangThaiXoa == false).ToList();
            foreach (var item in td)
            {
                if (item.IdDia == idDia)
                {
                    return false;
                }
            }
            return true;
        }
        public bool ThemDia(eDia ed)
        {
            Dia d = new Dia();
            d.IdDia = ed.IdDia;
            d.TrangThaiThue = ed.TrangThaiThue;
            d.TrangThaiXoa = ed.TrangThaiXoa;
            d.IdTieuDe = ed.IdTieuDe;
            if (!db.Dias.Contains(d))
            {
                db.Dias.InsertOnSubmit(d);
                db.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool XoaDia(eDia ed)
        {
            Dia d = new Dia();
            d = db.Dias.Where(a => a.IdDia == ed.IdDia).SingleOrDefault();
            if (d != null && d.TrangThaiThue =="cosan")
            {
                d.TrangThaiXoa = ed.TrangThaiXoa;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool SuaTrangThaiThueDia(string idDia)
        {
            Dia dia = new Dia();
            dia = db.Dias.Where(a => a.IdDia== idDia).SingleOrDefault();
            if (dia != null)
            {
                dia.TrangThaiThue = "cosan";

                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool kiemtraIDDiaCoTonTai(string idDia)
        {
            Dia d = db.Dias.SingleOrDefault(p => p.IdDia == idDia);
            if (d == null)
                return false;
            return true;
        }

        // true: đĩa đang được thuê
        public bool kiemTraDiaTaiCuaHang(string idDia)
        {
            Dia d = new Dia();
            d = db.Dias.Where(a => a.IdDia == idDia && a.TrangThaiThue == "duocthue").SingleOrDefault();
            if (d != null)
                return true;
            return false;

            //foreach (Dia item in db.Dias)
            //{ 
            //    if (item.IdDia == idDia && item.TrangThaiThue == true)
            //    {
            //        return true;
                    
            //    }   
            //}
            //return false;
        }

        public bool kiemTraTinhTrangDiaCoSan(string idDia)
        {
            Dia d = new Dia();
            d = db.Dias.Where(a => a.IdDia == idDia && a.TrangThaiThue == "cosan").SingleOrDefault();
            if (d != null)
                return true; // Đĩa đó có sẵn
            return false; // Đĩa đó không có sẵn
        }

    }
}
