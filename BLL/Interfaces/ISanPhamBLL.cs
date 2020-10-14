using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ISanPhamBLL
    {
        bool Create(SanPham model);
        SanPham GetDatabyID(string id);
        List<SanPham> GetDataAll();
        List<SanPham> GetDataByLoai(string id);
        List<SanPham> Search(int pageIndex, int pageSize, out long total, string MaLoai);
    }
}
