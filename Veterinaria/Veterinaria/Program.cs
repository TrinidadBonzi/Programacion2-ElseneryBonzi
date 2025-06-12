using Microsoft.EntityFrameworkCore;
using Veterinaria.Datos;
using Veterinaria.Logica.Animal;
using Veterinaria.Logica.Atencion;
using Veterinaria.Logica.Duenio;
using Veterinaria.Repositorio.Animal;
using Veterinaria.Repositorio.Atencion;
using Veterinaria.Repositorio.Duenio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

builder.Services.AddScoped<IAnimalRepositorio, AnimalRepositorio>();
builder.Services.AddScoped<IAnimalLogica, AnimalLogica>();
builder.Services.AddScoped<IAtencionRepositorio, AtencionRepositorio>();
builder.Services.AddScoped<IAtencionLogica, AtencionLogica>();
builder.Services.AddScoped<IDuenioRepositorio, DuenioRepositorio>();
builder.Services.AddScoped<IDuenioLogica, DuenioLogica>();


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
