using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HDBController : ControllerBase
    {
        private IHDBBLL _HDBBusiness;
        public HDBController(IHDBBLL HDBBusiness)
        {
            _HDBBusiness = HDBBusiness;
        }

        [Route("create")]
        [HttpPost]
        public HDB CreateItem([FromBody] HDB model)
        {
            model.ma_hoa_don = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach (var item in model.listjson_chitiet)
                    item.ma_chi_tiet = Guid.NewGuid().ToString();
            }
            _HDBBusiness.Create(model);
            return model;
        }
    }
}
