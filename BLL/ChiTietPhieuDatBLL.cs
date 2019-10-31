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
    }
}
