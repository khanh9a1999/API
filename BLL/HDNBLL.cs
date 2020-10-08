using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class HDNBLL:IHDNBLL 
    {
        private IHDNDAL ihdn;
        public HDNBLL (IHDNDAL ihdn2)
        {
            ihdn = ihdn2;
        }
        public List<HDN> getall()
        {
            return ihdn.GetData();
        }
    }
}
