using AutoMapper;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Model;
using Newtonsoft.Json.Serialization;
using Mapper = Model.Mapper;

namespace TuristickaAgencijaAPI
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TuristickaAgencijaAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    options =>
                    {
                        options.WithOrigins("http://localhost:4200/");
                        options.AllowAnyHeader();
                        options.AllowAnyMethod();
                        options.AllowCredentials();
                    });
            });

            services.AddScoped<IUnitOfWork, AgencijaUnitOfWork>();
            services.AddDbContext<TuristickaOrgContext>();

            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5443";
                        options.ApiName = "CoffeeAPI";
                        options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Jwt;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TuristickaAgencijaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }   
}
