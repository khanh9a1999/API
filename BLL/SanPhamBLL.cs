using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
   public class SanPhamBLL:ISanPhamBLL
    {
        private ISanPhamDAL isanpham;
        public SanPhamBLL(ISanPhamDAL isanpham2)
        {
            isanpham = isanpham2;
        }
        public List<SanPham> getall()
        {
            return isanpham.GetData();
        }
    }
}
