using apidiasfestivos.Core.repositorios;
using apidiasfestivos.Core.servicios;
using ApiDiasFestivosDominio;

namespace apiDiasfestivos.Aplicacion
{
    public class TipoFestivosServicio : ITipoFestivoServicio
    {

        private readonly ITipoFestivoServicio repositorio;

        public TipoFestivosServicio(ITipoFestivoServicio repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<IEnumerable<TipoFestivo>> ObtenerTipoFestivo()
        {
            return await repositorio.ObtenerTipoFestivo();
        }

        public async Task<TipoFestivo> Agregar(TipoFestivo TipoFestivo)
        {
            
                try
                {
                    return await repositorio.Agregar(TipoFestivo);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            
        }

        public async Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo)
        {
            return await repositorio.Modificar(TipoFestivo);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }
    }
}
