using apidiasfestivos.Core.repositorios;
using ApiDiasFestivosDominio;
using ApiDiasFestivosInfraestructura.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace ApiDiasFestivosInfraestructura.Repositorios
{
    public class TipoFestivoRepositorio : ITipoFestivoRepositorio
    {
        private readonly ContadorDeDIasFestivosContext Contexto;

        public TipoFestivoRepositorio(ContadorDeDIasFestivosContext contexto)
        {
            this.Contexto = contexto;
        }

        public async Task<IEnumerable<TipoFestivo>> ObtenerTipoFestivo()
        {
            return await Contexto.TiposFestivos.ToListAsync();
        }

        public async Task<TipoFestivo> Agregar(TipoFestivo tipoFestivo)
        {
            Contexto.TiposFestivos.Add(tipoFestivo);
            await Contexto.SaveChangesAsync();
            return Contexto.TiposFestivos.FirstOrDefault(tf => tf.Id == tipoFestivo.Id);
        }

        public async Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo)
        {
            
            var TipoFestivoExistente = await Contexto.TiposFestivos.FindAsync(TipoFestivo.Id);
            if (TipoFestivoExistente == null)
            {
                return null;
            }
                  Contexto.Entry(TipoFestivoExistente).CurrentValues.SetValues(TipoFestivo);
            await Contexto.SaveChangesAsync();
            return Contexto.TiposFestivos.FirstOrDefault(tf => tf.Id == TipoFestivo.Id);
        }

        public async Task<bool> Eliminar(int Id)
        {
            var TipoFestivoExistente = await Contexto.TiposFestivos.FindAsync(Id);
            if (TipoFestivoExistente == null)
            {
                return false;
            }
            try
            {
                Contexto.TiposFestivos.Remove(TipoFestivoExistente);
                await Contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
