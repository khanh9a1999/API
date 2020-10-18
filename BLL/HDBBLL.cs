using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public partial class HDBBLL:IHDBBLL
    {
        private IHDBDAL ihdb;
        public HDBBLL (IHDBDAL ihdb2)
        {
            ihdb = ihdb2;
        }
        public bool Create(HDB model)
        {
            return ihdb.Create(model);
        }
    }

}
