using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimeiroBlazor.API.Config;
using PrimeiroBlazor.API.Context;
using PrimeiroBlazor.API.Repository;
using PrimeiroBlazor.API.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SqlServerContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddEndpointsApiExplorer();
IMapper mapper = MapperConfig.ConfigureMapper().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin  
    .AllowCredentials());               // allow credentials 
app.MapControllers();

app.Run();
