using ElasticSearchCrudOperation.API.Extensions;
using ElasticSearchCrudOperation.API.Mapping;
using ElasticSearchCrudOperation.API.Repositories;
using ElasticSearchCrudOperation.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elastic Search API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();