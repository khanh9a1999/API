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
    public class LoaiSPController : ControllerBase
    {
        private ILoaiSPBLL iloaispb;
        public LoaiSPController(ILoaiSPBLL iloaispb2)
        {
            iloaispb = iloaispb2;
        }
        // GET: api/<LoaiController>
        [Route("all")]
        [HttpGet]
        public IEnumerable<LoaiSP> Get()
        {
            return iloaispb.getall();
        }

        // GET api/<LoaiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoaiSPController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoaiSPController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoaiSPController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
