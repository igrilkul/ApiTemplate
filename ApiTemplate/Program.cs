using TextualRPG.API.Contracts;
using TextualRPG.DAL.Data;
using TextualRPG.EF.Services;
using TextualRPG.Filters;
using TextualRPG.SwaggerFilters;
using TextualRPG.TransformerConventions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Newtonsoft.Json.Converters;

namespace TextualRPG
{
    public class Program
    {
        // CORS policy name
        private static readonly string allowedOrigins = "_myAllowSpecificOrigins";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            services.AddCors(options =>
                options.AddPolicy(
                    name: allowedOrigins,
                    policy => policy.WithOrigins("http://localhost:3000/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            ));

            services.AddRouting(options => options.LowercaseUrls = true);
            services
                .AddControllers(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
                    options.Filters.Add<ResultFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMvcCore()
                .AddApiExplorer();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SchemaFilter<EnumSchemaFilter>();

            });
            services.AddSwaggerGenNewtonsoftSupport();

            // Dependencies
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IZoneService, ZoneService>();
            services.AddScoped<IEnemyService, EnemyService>();


            var app = builder.Build();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(allowedOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}