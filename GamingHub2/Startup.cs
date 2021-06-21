using GamingHub2.Filters;
using GamingHub2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GamingHub2.Model;
using GamingHub2.Model.Requests;

namespace GamingHub2
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
            // services.AddControllers();

 //           services.AddControllers().AddNewtonsoftJson(x =>
 //x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            //services.AddControllers(x =>
            //{
            //    x.Filters.Add<ErrorFilter>();
            //});

            services.AddSwaggerGen();
            services.AddMvc(options => options.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAutoMapper(typeof(Startup));
            //si jo
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddSwaggerGen(c =>
            //{
            //    //c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});

            //var connection = @"Server=.\REPORTING;Database=eProdaja;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IZanrService, ZanrService>();
            services.AddScoped<IKonzolaService, KonzolaService>();
            services.AddScoped<IIgraService, IgraService>();
            services.AddScoped<IProizvodService, ProizvodService>();
            services.AddScoped<IKonzolaService, KonzolaService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<ICRUDService<Model.Uloga, object,UlogaInsertRequest,object>, BaseCRUDService<Model.Uloga, Database.Uloga, object,UlogaInsertRequest,object>>();
            //services.AddScoped<IReadService<Model.Uloge, object>, BaseReadService<Model.Uloge, object, Database.Uloge>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
           // app.UseMvc();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
