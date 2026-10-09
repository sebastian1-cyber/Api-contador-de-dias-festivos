using apidiasfestivos.Core.repositorios;
using apidiasfestivos.Core.servicios;
using apiDiasfestivos.Aplicacion;
using apiDiasFestivos.Aplicacion;
using ApiDiasFestivosInfraestructura.Persistencias;
using ApiDiasFestivosInfraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;


namespace Presentacion.InyeccionDependencias
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                               IConfiguration configuracion
                                               )
        {
            // agregar el DBContext
            servicios.AddDbContext<ContadorDeDIasFestivosContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("Festivos"));
            });

            // agregar los repositorios
            servicios.AddTransient<IFestivosRepositorio, FestivoRepositorio>();
            servicios.AddTransient<IpaisRepositorio, PaisRepositorio>();
           
             
            // agregar los servicios
            servicios.AddTransient<IFestivoServicio, FestivosServicio>();
            servicios.AddTransient<IpaisServicio, PaisServicio>();
            



            return servicios;   

        }

    }
}
