﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class SanPhamBLL : ISanPhamBLL
    {
        private ISanPhamDAL _res;
        public SanPhamBLL(ISanPhamDAL LoaiSPRes)
        {
            _res = LoaiSPRes;
        }
        public bool Create(SanPham model)
        {
            return _res.Create(model);
        }
        public SanPham GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SanPham> GetDataByLoai(string id)
        {
            return _res.GetDataByLoai(id);
        }
        public List<SanPham> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<SanPham> Search(int pageIndex, int pageSize, out long total, string MaLoai)
        {
            return _res.Search(pageIndex, pageSize, out total, MaLoai);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SanPham model)
        {
            return _res.Update(model);
        }
        public List<SanPham> TK(int pageIndex, int pageSize, out long total, string TenSP, decimal DonGia)
        {
            return _res.TK(pageIndex, pageSize, out total, TenSP, DonGia);
        }
    }

}
