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
using Newtonsoft.Json;
using Stripe;
using System.Globalization;

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

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();
            //services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IZanrService, ZanrService>();
            services.AddScoped<IKonzolaService, KonzolaService>();
            services.AddScoped<IIgraService, IgraService>();
            services.AddScoped<IProizvodService, ProizvodService>();
            services.AddScoped<IKonzolaService, KonzolaService>();
            services.AddScoped<IKorisnikService, KorisniciService>();
            services.AddScoped<IRecommenderService, RecommenderService>();

            //services.AddScoped<ICRUDService<Model.Uloga, object,UlogaInsertRequest,object>, BaseCRUDService<Model.Uloga, Database.Uloga, object,UlogaInsertRequest,object>>();
            //services.AddScoped<IReadService<Model.Uloge, object>, BaseReadService<Model.Uloge, Database.Uloge, object>>();
            services.AddScoped<ICRUDService<Model.Uloge, object, UlogaInsertRequest, object>, BaseCRUDService<Model.Uloge, Database.Uloge, object, UlogaInsertRequest, object>>();
            services.AddScoped<IRecenzijaService, RecenzijaService>();
            services.AddScoped<IIgraKonzolaService, IgraKonzolaService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<INarudzbaStavkaService, NarudzbaStavkaService>();
            services.AddScoped<IAutorizacijskiTokenService, AutorizacijskiTokenService>();
            services.AddScoped<ICRUDService<Model.Ocjena, OcjenaSearchRequest, OcjenaUpsertRequest, OcjenaUpsertRequest>, OcjenaService>();

            services.AddScoped<ICRUDService<Model.Kupac, KupacSearchRequest, KupacUpsertRequest, KupacUpsertRequest>, KupacService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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
