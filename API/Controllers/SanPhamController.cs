using System;
using System.Collections.Generic;
using System.IO;
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
        private string _path;

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
        [Route("sp-get-by-loai/{id}")]
        [HttpGet]
        public List<SanPham> GetDataByLoai(string id)
        {
            return ispb.GetDataByLoai(id);
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("delete-product")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Dictionary<string, object> formData)
        {
            string MaSP = "";
            if (formData.Keys.Contains("MaSP") && !string.IsNullOrEmpty(Convert.ToString(formData["MaSP"]))) { MaSP = Convert.ToString(formData["MaSP"]); }
            ispb.Delete(MaSP);
            return Ok();
        }
        [Route("update-product")]
        [HttpPost]
        public SanPham UpdateProduct([FromBody] SanPham model)
        {
            ispb.Update(model);
            return model;
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
                string MaLoai = "";
                if (formData.Keys.Contains("TenSP") && !string.IsNullOrEmpty(Convert.ToString(formData["TenSP"]))) { MaLoai = Convert.ToString(formData["MaLoai"]); }
                long total = 0;
                var data = ispb.Search(page, pageSize, out total, MaLoai);
                response.TotalItems = total;
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

        [Route("search-product")]
        [HttpPost]
        public ResponseModel TK([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenSP = "";
                if (formData.Keys.Contains("TenSP") && !string.IsNullOrEmpty(Convert.ToString(formData["TenSP"]))) { TenSP = Convert.ToString(formData["TenSP"]); }
                decimal DonGia = 0;
                if (formData.Keys.Contains("DonGia") && (formData["DonGia"]) != null) { DonGia = Convert.ToDecimal(formData["DonGia"]); }
                long total = 0;
                var data = ispb.TK(page, pageSize, out total, TenSP, DonGia);
                response.TotalItems = total;
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
