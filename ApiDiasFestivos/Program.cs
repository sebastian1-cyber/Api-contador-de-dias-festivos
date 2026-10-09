using Presentacion.InyeccionDependencias;


var builder = WebApplication.CreateBuilder(args);

var configuracion = builder.Configuration;

builder.Services.AgregarDependencias(configuracion);
builder.Services.AddControllers();




var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
