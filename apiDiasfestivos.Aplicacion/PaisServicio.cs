using apidiasfestivos.Core.repositorios;
using apidiasfestivos.Core.servicios;
using ApiDiasFestivosDominio;

namespace apiDiasFestivos.Aplicacion
{

    public class PaisServicio : IpaisServicio

    {
        private readonly IpaisRepositorio repositorio;

        public PaisServicio(IpaisRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<Pais> Agregar(Pais Pais)
        {
            try
            {
                return await repositorio.Agregar(Pais);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Pais> Modificar(Pais Pais)
        {
            return await repositorio.Modificar(Pais);
        }

        public async Task<Pais> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Pais>> PaisObtenertodosPaises()
        {
            return await repositorio.ObtenertodosPaises();
        }
    }
}
