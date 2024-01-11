using EnterpriseODataApis.Data;
using EnterpriseODataApis.Models;
using EnterpriseODataApis.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection.Emit;

static IEdmModel GetEdmModel()
{

    ODataConventionModelBuilder modelBuilder = new();
    var customerEntityTypeConfig = modelBuilder.EntitySet<Company>("Companies").EntityType;
    //customerEntityTypeConfig.Property(x => x.Name).IsNotFilterable();
    modelBuilder.EntitySet<Product>("Products");

    /*
    ODataModelBuilder modelBuilder = new();
    EntityTypeConfiguration<Product> productType = modelBuilder.EntityType<Product>();
    productType.HasKey(c => c.Id);
    productType.Property(c => c.Name);
    productType.Property(c => c.Price);
    productType.ContainsOptional(c => c.Company);
    modelBuilder.EntitySet<Product>("Products");

    EntityTypeConfiguration<Company> companyType = modelBuilder.EntityType<Company>();
    companyType.HasKey(c => c.id);
    companyType.Property(c => c.Name);
    companyType.Property(c => c.Size);
    companyType.HasMany(c => c.Products);

    var customerEntityTypeConfig = modelBuilder.EntitySet<Company>("Companies").EntityType;
    customerEntityTypeConfig.Property(x => x.Name).IsNotFilterable();
    */
    return modelBuilder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
    "api", GetEdmModel()));

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetValue<String>("DataBaseConnectionString"),
    options => options.EnableRetryOnFailure()));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ProductRepository, ProductRepository>();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
});
app.Run();