using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apidiasfestivos.Core.repositorios;
using apidiasfestivos.Core.servicios;
using ApiDiasFestivosDominio;
using ApiDiasFestivosDominio.DTos;


namespace apiDiasfestivos.Aplicacion
{
    public class FestivosServicio : IFestivoServicio
    {
        private readonly IFestivosRepositorio repositorio;

        public FestivosServicio(IFestivosRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerFestivos();
        }

        public  async Task<Festivo> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto)
        {
            return await repositorio.Buscar(IndiceDato, Texto);
        }

        public async Task<Festivo> Agregar(Festivo Festivo)
        {
            try
            {
                return await repositorio.Agregar(Festivo);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<Festivo> Modificar(Festivo Festivo)
        {
            return await repositorio.Modificar(Festivo);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public Task<IEnumerable<FestivosDTos>> ValidarFestivoAño(int Idpais, int año)
        {
            throw new NotImplementedException();
        }
    }
}
