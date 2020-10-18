using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IKhachHangDAL
    {
        bool Create(KhachHang model);
    }
}
