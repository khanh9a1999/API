using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HDBBLL : IHDBBLL
    {
        private IHDBDAL _res;
        public HDBBLL(IHDBDAL res)
        {
            _res = res;
        }
        public bool Create(HDB model)
        {
            return _res.Create(model);
        }
    }

}