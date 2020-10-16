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
    public class HDBController : ControllerBase
    {
        private IHDBBLL ihdb;
        public HDBController(IHDBBLL ihdb2)
        {
            ihdb = ihdb2;
        }

        [Route("create-hdb")]
        [HttpPost]
        public HDB CreateItem([FromBody] HDB model)
        {
            model.MaHDB = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach (var item in model.listjson_chitiet)
                    item.MaHDB = Guid.NewGuid().ToString();
            }
            ihdb.Create(model);
            return model;
        }
    }
}