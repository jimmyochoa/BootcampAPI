using System.Collections.Immutable;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces;
using Proyecto.Models;
using Proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProducto, ProductoService>();
builder.Services.AddScoped<ICatalogo, CatalogoService>();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICliente, ClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VentasContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();