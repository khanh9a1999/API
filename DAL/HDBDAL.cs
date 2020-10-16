using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HDBDAL : IHDBDAL
    {

        public IDatabaseHelper _dbHelper;
        public HDBDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(HDB model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "hoa_don_create",
                "@MaHDB", model.MaHDB,
                "@MaKH", model.MaKH,
                "@NgayBan", model.NgayBan,
                "@PTTT", model.PTTT,
                "@TongTien", model.TongTien,
                "@TrangThai", model.TrangThai,
                "@listjson_chitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
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
