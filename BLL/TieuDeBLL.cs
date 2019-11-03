using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class TieuDeBLL
    {
        QLCDDataContext db;
        public TieuDeBLL()
        {
            db = new QLCDDataContext();
        }
        public List<eTieuDe> LayDanhSachTieuDe_QuanLyKhoDia(string tenDanhMuc)
        {
            List<eTieuDe> list = new List<eTieuDe>();
            var query = (from a in db.TieuDes
                         join b in db.DanhMucs on a.IdDanhMuc equals b.IdDanhMuc
                         where a.TrangThaiXoa == false && b.TenDanhMuc == tenDanhMuc
                         select new
                         {
                             a.IdTieuDe,
                             a.TenTieuDe,
                             b.TenDanhMuc,
                             a.SoLuongDia
                         }).ToList();

            foreach (var item in query)
            {
                eTieuDe etd = new eTieuDe(item.IdTieuDe, item.TenTieuDe, item.TenDanhMuc, Convert.ToInt32(item.SoLuongDia));
                list.Add(etd);
            }
            return list;

        }

        public bool kiemtraSoLuongDiaConLai(string idTieuDe)
        {
            int count = db.Dias.Where(p => p.IdTieuDe == idTieuDe).Count();
            if (count > 0)
                return true;
            return false;
        }

        public List<eTieuDe> LayDanhSachTieuDeTheoTenDanhMuc(string tenDanhMuc)
        {
            List<eTieuDe> list = new List<eTieuDe>();
            var query = (from a in db.TieuDes
                         join b in db.DanhMucs on a.IdDanhMuc equals b.IdDanhMuc
                         where a.TrangThaiXoa == false && b.TenDanhMuc == tenDanhMuc
                         select new
                         {
                             a.IdTieuDe,
                             a.TenTieuDe,
                             a.SoLuongDia,
                             b.TenDanhMuc,
                         }).ToList();

            foreach (var item in query)
            {
                eTieuDe etd = new eTieuDe(item.IdTieuDe, item.TenTieuDe,item.TenDanhMuc,Convert.ToInt32(item.SoLuongDia));
                list.Add(etd);
            }
            return list;

        }


        //Khi cần thì xài lại, ko nên xóa
        //public List<eTieuDe> LayDanhSachTieuDe()
        //{
        //    List<eTieuDe> list = new List<eTieuDe>();
        //    var query = (from a in db.TieuDes
        //                join b in db.DanhMucs on a.IdDanhMuc equals b.IdDanhMuc
        //                where a.TrangThaiXoa == false
        //                select new
        //                {
        //                    a.IdTieuDe,
        //                    a.TenTieuDe,
        //                    a.SoLuongDia,
        //                    b.TenDanhMuc,                            
        //                }).ToList();

        //    foreach (var item in query)
        //    {
        //        eTieuDe etd = new eTieuDe (item.IdTieuDe, item.TenTieuDe, Convert.ToInt32(item.SoLuongDia), item.TenDanhMuc);          
        //        list.Add(etd);
        //    }
        //    return list;

        //}

        public List<eTieuDe> LayDanhSachTenTieuDe()
        {
            List<eTieuDe> list = new List<eTieuDe>();
            var query = (from a in db.TieuDes
                         where a.TrangThaiXoa == false
                         select new
                         {
                            a.TenTieuDe
                         }).ToList();

            foreach (var item in query)
            {
                eTieuDe etd = new eTieuDe(item.TenTieuDe);
                list.Add(etd);
            }
            return list;

        }

        public string LayMaTieuDeCaoNhat()
        {
            string td = (from a in db.TieuDes
                         orderby a.IdTieuDe descending
                         select a.IdTieuDe
                            ).Take(1).First().ToString();
            return td;
        }
   
        public bool ThemTieuDe(eTieuDe etd)
        {
            TieuDe td = new TieuDe();
            td.IdTieuDe = etd.IdTieuDe;
            td.TenTieuDe = etd.TenTieuDe;
            td.SoLuongDia = etd.SoLuongDia;
            td.IdDanhMuc = etd.IdDanhMuc;           
            td.TrangThaiXoa = etd.TrangThaiXoa;
            td.SoLuongDiaCoSan = etd.SoLuongDiaCoSan;
            if (!db.TieuDes.Contains(td))
            {
                db.TieuDes.InsertOnSubmit(td);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool SuaTieuDe(eTieuDe etd)
        {
            TieuDe td = new TieuDe();
            td = db.TieuDes.Where(a => a.IdTieuDe== etd.IdTieuDe).SingleOrDefault();
            if (td != null)
            {
                td.TenTieuDe = etd.TenTieuDe;
                td.IdDanhMuc= etd.IdDanhMuc;

                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaTieuDe(eTieuDe etd)
        {
            TieuDe td = new TieuDe();
            td = db.TieuDes.Where(a => a.IdTieuDe== etd.IdTieuDe).SingleOrDefault();
            if (td != null)
            {
                td.TrangThaiXoa = etd.TrangThaiXoa;

                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public string layIdTieuDeBangTenTieuDe(string tenTieuDe)
        {
            string id = (from a in db.TieuDes
                         where a.TenTieuDe == tenTieuDe
                         select a.IdTieuDe
                      ).FirstOrDefault();
            return id;
        }
        public string layTenTieuDeBangIdTieuDe(string idTieuDe)
        {
            string ten = (from a in db.TieuDes
                         where a.IdTieuDe == idTieuDe
                         select a.TenTieuDe
                      ).FirstOrDefault();
            return ten;
        }

        //lấy tên tiêu đề cho form quản lý thuê đĩa
        public string LayTenTieuDeBangIdDia(string idDia)
        {

            string tenTieuDe = (from a in db.Dias
                             join b in db.TieuDes on a.IdTieuDe equals b.IdTieuDe
                             where b.TrangThaiXoa == false && a.IdDia == idDia
                             select b.TenTieuDe).SingleOrDefault();  
            if(tenTieuDe == null)
            {
                return "null";
            }   
                return tenTieuDe;
         
                   
        }

        public eTieuDe LayTieuDeTheoIDTieuDe(string idTieuDe)
        {
            eTieuDe td = new eTieuDe();

            TieuDe tdd = db.TieuDes.SingleOrDefault(p => p.IdTieuDe == idTieuDe);
            if(tdd != null)
            {
                td.IdTieuDe = tdd.IdTieuDe;
                td.TenTieuDe = tdd.TenTieuDe;
                td.IdDanhMuc = (int) tdd.IdDanhMuc;
                td.SoLuongDia =(int) tdd.SoLuongDia;
                td.SoLuongDiaCoSan =(int) tdd.SoLuongDiaCoSan;
                tdd.TrangThaiXoa = tdd.TrangThaiXoa;

                return td;
            }

            return null;
        }

        public bool kiemtraTieuDeDaTonTai(string tenTieuDe)
        {
            TieuDe td = db.TieuDes.SingleOrDefault(p => p.TenTieuDe == tenTieuDe);
            if (td != null)
                return true;
            return false;
        }

        public bool capnhatTrangThaiXoa(string tenTieuDe , bool e)
        {
            TieuDe td = db.TieuDes.SingleOrDefault(p => p.TenTieuDe == tenTieuDe);
            if(td!=null)
            {
                td.TrangThaiXoa = e;
                db.SubmitChanges();
                return true;
            }

            return false;
        }

        public void capnhatSoLuong(string idTieuDe)
        {
            TieuDe td = db.TieuDes.SingleOrDefault(p => p.IdTieuDe == idTieuDe);

            int tongdia = db.Dias.Where(p => p.IdTieuDe == idTieuDe && p.TrangThaiXoa==false).Count();
            int tongdiacosan = db.Dias.Where(p => p.IdTieuDe == idTieuDe && p.TrangThaiXoa == false && p.TrangThaiThue == "cosan").Count();

            td.SoLuongDia = tongdia;
            td.SoLuongDiaCoSan = tongdiacosan;
            db.SubmitChanges();
        }
    }
}
