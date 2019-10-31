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
    }
}
