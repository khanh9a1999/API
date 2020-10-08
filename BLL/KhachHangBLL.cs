using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
   public class KhachHangBLL:IKhachHangBLL
    {
        private IKhachHangDAL ikhachhang;
        public KhachHangBLL (IKhachHangDAL ikhachhang2)
        {
            ikhachhang = ikhachhang2;
        }
        public List<KhachHang> getall()
        {
            return ikhachhang.GetData();
        }
    }
}
