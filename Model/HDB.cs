using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HDB
    {
        public string MaHDB { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayBan { get; set; }
        public string PTTT { get; set; }
        public int TongTien { get; set; }
        public string TrangThai { get; set; }
        public List<CTHDB> listjson_chitiet { get; set; }
    }
}
