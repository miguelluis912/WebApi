using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//**** inyectamos la conexion a la base de datos
builder.Services.AddDbContext<chinookContext>(option =>
{
    // str_conn :: definimos la cadena de conexion para pasarselo a metodo ( UseMySql ) 
    String str_conn = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseMySql(str_conn, ServerVersion.AutoDetect(str_conn));
});
// inyectamos el uso de las clases de los servicios.
builder.Services.AddScoped<ArtistaService>();

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
