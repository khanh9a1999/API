using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
   public class NCCBLL:INCCBLL
    {
        private INCCDAL incc;
        public NCCBLL (INCCDAL incc2)
        {
            incc = incc2;
        }
        public List<NCC> getall()
        {
            return incc.GetData();
        }
    }
}
