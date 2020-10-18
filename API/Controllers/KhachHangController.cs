using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhacHangBLL ikhbll;
        public KhachHangController(IKhacHangBLL ikhbll2)
        {
            ikhbll = ikhbll2;
        }

        [Route("create-kh")]
        [HttpPost]
        public KhachHang CreateItem([FromBody] KhachHang model)
        {
            ikhbll.Create(model);
            return model;
        }
    }
}