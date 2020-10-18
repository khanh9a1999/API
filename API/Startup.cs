using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddControllers();
            services.AddTransient<ICTHDNBLL, CTHDNBLL>();
            services.AddTransient<ICTHDNDAL, CTHDNDAL>();
            services.AddTransient<ICTHDBBLL, CTHDBBLL>();
            services.AddTransient<ICTHDBDAL, CTHDBDAL>();
            services.AddTransient<IHDBDAL, HDBDAL>();
            services.AddTransient<IHDBBLL, HDBBLL>();
            services.AddTransient<IKhachHangBLL, KhachHangBLL>();
            services.AddTransient<IKhachHangDAL, KhachHangDAL>();
            services.AddTransient<ILoaiSPDAL, LoaiSPDAL>();
            services.AddTransient<INCCDAL, NCCDAL>();
            services.AddTransient<INCCBLL, NCCBLL>();
            services.AddTransient<IThuongHieuDAL, ThuongHieuDAL>();
            services.AddTransient<IThuongHieuBLL, ThuongHieuBLL>();
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<ILoaiSPDAL, LoaiSPDAL>();
            services.AddTransient<ILoaiSPBLL, LoaiSPBll>();
            services.AddTransient<ISanPhamDAL, SanPhamDAL>();
            services.AddTransient<ISanPhamBLL, SanPhamBLL>();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200").AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
