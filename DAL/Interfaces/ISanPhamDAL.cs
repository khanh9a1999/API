using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ISanPhamDAL
    {
        public List<SanPham> GetData();
    }
}
