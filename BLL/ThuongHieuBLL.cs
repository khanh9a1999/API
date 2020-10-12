using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class ThuongHieuBLL : IThuongHieuBLL
    {
        private IThuongHieuDAL ithuonghieu;
        public ThuongHieuBLL(IThuongHieuDAL ithuonghieu2)
        {
            ithuonghieu = ithuonghieu2;
        }
        public List<ThuongHieu> getall()
        {
            return ithuonghieu.GetData();
        }
    }
}
