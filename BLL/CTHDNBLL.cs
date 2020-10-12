using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CTHDNBLL:ICTHDNBLL
    {
        private ICTHDNDAL icthdn;
        public CTHDNBLL(ICTHDNDAL icthdn2)
        {
            icthdn = icthdn2;
        }
        public List<CTHDN> getall()
        {
            return icthdn.GetData();
        }
    }
}
