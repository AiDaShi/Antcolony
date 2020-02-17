using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntcolonyProgram.Filter;
using AntcolonyProgram.JWT;
using AntcolonyProgram.Log;
using AntcolonyProgram.Models;
using AntcolonyProgram.Services.Instantiation;
using AntcolonyProgram.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AntcolonyProgram
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //֧��Xml
            //services.AddControllers(option =>
            //{
            //    option.ReturnHttpNotAcceptable = true;
            //}).AddXmlDataContractSerializerFormatters();
            services.AddControllersWithViews(option =>
            {
                option.ReturnHttpNotAcceptable = true;
                //option.EnableEndpointRouting = false;
            }).AddXmlDataContractSerializerFormatters();

            //AutoMapper��ע��
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //�ĵ�˵��
            services.AddSwaggerDocument();

            services.AddScoped<CheckTokenFilter>();

            #region jwt���

            //services.AddScoped<CheckTokenFilter>();

            services.AddTransient<ITokenHelper, TokenHelper>();
            //��ȡ�����ļ����õ�jwt�������
            services.Configure<JWTConfig>(Configuration.GetSection("JWT"));
            //����JWT
            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer();
            #endregion



            //ע�����ݿ����
            //services.AddTransient(factory => new DbContentFactory(new AntcolonyContext()));
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped(IUserService,);
            //services.AddTransient(AntcolonyContext, DbContentFactory);
            
            //ef�����ַ���
            var connection = Configuration.GetConnectionString("BloggingDatabase");

            services.AddDbContext<AntcolonyContext>(options => options.UseSqlServer(connection));
            

            //��ʼ����־ϵͳ
            //�ο� http://www.tnblog.net/hb/article/details/2709
            SerilogConfigurationLog.CreateLogger(connection + ";autoCreateSqlTable=true", "AntcolonyProgram");

            //services.AddEntityFrameworkSqlServer();
            //services.AddDbContextPool<AntcolonyContext>((serviceProvider, optionsBuilder) =>
            //{
            //    if (!optionsBuilder.IsConfigured)
            //    {
            //        optionsBuilder.UseSqlServer(connection);
            //        optionsBuilder.UseInternalServiceProvider(serviceProvider);
            //    }
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            //������֤�м��
            app.UseAuthentication();
            app.UseAuthorization();

            //ע��Swagger UI���
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LoginHandle}/{action=LoginPage}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
