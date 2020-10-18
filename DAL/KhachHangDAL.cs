using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class KhachHangDAL : IKhachHangDAL
    {

        public IDatabaseHelper _dbHelper;
        public KhachHangDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(KhachHang model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "khachhang_create",
                "@MaKH", model.MaKH,
                "@TenKH", model.TenKH,
                "@DiaChi", model.DiaChi,
                "@SĐT", model.SDT,
                "@Email", model.Email,
                "@PW", model.PW);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

