using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using idobrin_aspnet_dal.Repositories;
using idobrin_aspnet_logic.Interfaces;
using idobrin_aspnet_logic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register DBContext
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("StagingConnection"), 
    serverVersion:ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("StagingConnection"))));
// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Register Repos
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// Register services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IMunicipalityService, MunicipalityService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();