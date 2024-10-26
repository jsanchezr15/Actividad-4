using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CONEXION PARA SQLSERVER
/*
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionsqlserver")));
*/

//CONEXION PARA MYSQL
string? cadena = builder.Configuration.GetConnectionString("DefaultConnectionmysql");
if (cadena!=null){
    builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySQL(cadena));
}

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
