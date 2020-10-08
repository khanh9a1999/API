using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class CTHDBBLL:ICTHDBBLL

    {
        private ICTHDBDAL icthdb;
        public CTHDBBLL(ICTHDBDAL icthdb2)
        {
            icthdb = icthdb2;
        }
        public List<CTHDB> getall()
        {
            return icthdb.GetData();
        }
    }
}
