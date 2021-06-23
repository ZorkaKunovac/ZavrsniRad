using GamingHub2.Filters;
using GamingHub2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GamingHub2.Model.Requests;
using GamingHub2.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
//Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;

namespace GamingHub2
{
    //public class BasicAuthDocumentFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    //    {
    //        var securityRequirements = new Dictionary<string, IEnumerable<string>>()
    //    {
    //        { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
    //    };

    //        swaggerDoc.Security = new[] { securityRequirements };
    //    }
    //}
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

            //services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Swagger", "");
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eProdaja API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });


            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //services.AddMvc(option => option.EnableEndpointRouting = false)
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //  services.AddControllers(.)
            // services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
           // JsonConvert.SerializeObject(model, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();
            //services.AddMvc(options => options.EnableEndpointRouting = false);

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
            services.AddScoped<IKorisnikService, KorisniciService>();
            //   services.AddScoped<IUlogaService, UlogaService>();

            //services.AddScoped<ICRUDService<Model.Uloga, object,UlogaInsertRequest,object>, BaseCRUDService<Model.Uloga, Database.Uloga, object,UlogaInsertRequest,object>>();
            services.AddScoped<IReadService<Model.Uloge, object>, BaseReadService<Model.Uloge, Database.Uloge, object>>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});
            //// app.UseMvc();
            ////app.UseHttpsRedirection();

            ////app.UseRouting();

            ////app.UseAuthorization();

            ////app.UseEndpoints(endpoints =>
            ////{
            ////    endpoints.MapControllers();
            ////});

            //app.UseHttpsRedirection();
            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();

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
