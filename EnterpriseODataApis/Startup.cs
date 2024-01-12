using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace EnterpriseODataApis
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        { 
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents("api", GetEdmModel()))
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(Configuration.GetValue<String>("DataBaseConnectionString"),
                options => options.EnableRetryOnFailure()));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Enterprise Apis V1", Version = "v1" });
            });
            AddFormatters(services);

            services.AddScoped<CompanyRepository, CompanyRepository>();
            services.AddScoped<ProductRepository, ProductRepository>();
            services.AddScoped<EventRepository, EventRepository>();
            services.AddScoped<EventStatusRepository, EventStatusRepository>();
            services.AddScoped<AccountRepository, AccountRepository>();
            services.AddScoped<EventCategoryRepository, EventCategoryRepository>();
            services.AddScoped<EventClassRepository, EventClassRepository>();
            services.AddScoped<EventTypeRepository, EventTypeRepository>();
        }

        public void Configure(IApplicationBuilder app)
        { 
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                //endpoints.MapODataRoute(routeName: "api", routePrefix: "api", model: GetEdmModel());
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enterprise APIs V1");
            });
        }

        private IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder modelBuilder = new();
            modelBuilder.EntitySet<Company>("Companies");
            modelBuilder.EntitySet<Product>("Products");

            return modelBuilder.GetEdmModel();
        }

        private void AddFormatters(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }
    }
}
