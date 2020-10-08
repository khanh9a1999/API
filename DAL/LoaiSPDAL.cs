using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class LoaiSPDAL : ILoaiSPDAL
    {

        public IDatabaseHelper _dbHelper;
        public LoaiSPDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<LoaiSP> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_loaisp_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiSP>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
