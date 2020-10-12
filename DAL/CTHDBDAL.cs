using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class CTHDBDAL : ICTHDBDAL
    {

        public IDatabaseHelper _dbHelper;
        public CTHDBDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<CTHDB> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "cthdb_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CTHDB>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
