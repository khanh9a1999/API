using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBLL ispb;
        public SanPhamController(ISanPhamBLL ispb2)
        {
            ispb = ispb2;
        }
        [Route("sp-all")]
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return ispb.GetDataAll();
        }
        [Route("sp-create")]
        [HttpPost]
        public SanPham CreateItem([FromBody] SanPham model)
        {
            ispb.Create(model);
            return model;
        }
        // GET api/<SanPhamController>/5
        [Route("sp-get-by-id/{id}")]
        [HttpGet]
        public SanPham GetDatabyID(string id)
        {
            return ispb.GetDatabyID(id);
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [Route("sp-search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string item_group_id = "";
                if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
                long total = 0;
                var data = ispb.Search(page, pageSize, out total, item_group_id);
                response.TotalSachs = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
