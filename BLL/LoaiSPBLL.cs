using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class LoaiSPBll : ILoaiSPBLL
    {
        private ILoaiSPDAL iloaisp;
        public LoaiSPBll(ILoaiSPDAL iloaisp2)
        {
            iloaisp = iloaisp2;
        }
        public List<LoaiSP> getall()
        {
            return iloaisp.GetData();
        }
    }
}
