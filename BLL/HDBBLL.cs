using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class HDBBLL:IHDBBLL
    {
        private IHDBDAL ihdb;
        public HDBBLL (IHDBDAL ihdb2)
        {
            ihdb = ihdb2;
        }
        public List<HDB> getall()
        {
            return ihdb.GetData();
        }
    }
}
