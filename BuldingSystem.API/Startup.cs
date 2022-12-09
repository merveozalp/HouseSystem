using Autofac.Core;
using BuildingSystem.Business.Abstract;
using BuildingSystem.Business.AutoMapper;
using BuildingSystem.Business.Concrete;
using BuildingSystem.Business.UnitOfWork;
using BuildingSystem.DataAccess.Abstract;
using BuildingSystem.DataAccess.Concrete;
using BuildingSystem.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BuldingSystem.API
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
            

            //services.AddTransient<IRoleRepository, RoleRepository>();
            //services.AddTransient<IRoleService, RoleService>();

            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserService, UserService>();


            services.AddDbContext<ApplicationDbContext>(
                opts =>
                {
                    opts.UseSqlServer(Configuration.GetConnectionString("BuildingSystem"));
                });
            services.AddControllers();

            // Filter ile validation iþlemini merkezileþtirdim.
            //services.AddControllers(opt =>  opt.Filters.Add(new ValidateFilterAttribute()))
            //.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            // benim istediðim filter dönmesi için API kendi hata çýktýsýný kapatýyorum.
            //services.Configure<ApiBehaviorOptions>(x =>
            //{
            //    x.SuppressModelStateInvalidFilter = true;
            //});

            
          









            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuldingSystem.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuldingSystem.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
