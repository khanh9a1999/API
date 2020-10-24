using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ISanPhamDAL
    {
        bool Create(SanPham model);
        SanPham GetDatabyID(string id);
        List<SanPham> GetDataAll();
        List<SanPham> GetDataByLoai(string MaLoai);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string MaLoai);
        List<SanPham> TK(int pageIndex, int pageSize, out long total, string TenSP, decimal DonGia);
        bool Update(SanPham model);
        bool Delete(string id);
    }
}
