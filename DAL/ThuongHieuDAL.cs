using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ThuongHieuDAL : IThuongHieuDAL
    {

        public IDatabaseHelper _dbHelper;
        public ThuongHieuDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ThuongHieu> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "thuonghieu_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuongHieu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
