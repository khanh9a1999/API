using DAL;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using DAL.Helper;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace BLL
{
   public class KhachHangBLL:IKhachHangBLL
    {
        private IKhachHangDAL _res;
        private string Secret;
        public KhachHangBLL (IKhachHangDAL ikhachhang2, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = ikhachhang2;
        }
        public KhachHang Authenticate(string username, string password)
        {
            var kh = _res.GetKH(username, password);
            // return null if user not found
            if (kh == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, kh.tenkh.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            kh.token = tokenHandler.WriteToken(token);

            return kh;

        }
        public bool CreateCustomer(KhachHang model)
        {
            return _res.CreateCustomer(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public KhachHang GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Update(KhachHang model)
        {
            return _res.Update(model);
        }
        public List<KhachHang> Search(int pageIndex, int pageSize, out long total, string tenkh, string email)
        {
            return _res.Search(pageIndex, pageSize, out total, tenkh, email);
        }
    }

}
