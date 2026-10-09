using ApiDiasFestivosDominio;
using ApiDiasFestivosDominio.DTos;


namespace apidiasfestivos.Core.repositorios
{
    public interface IFestivosRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerFestivos();
        
        Task<Festivo> Obtener(int Id);
        Task<Festivo> Agregar(Festivo Festivo);

        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto);

        Task<Festivo> Modificar(Festivo Festivo);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Festivo>> ValidarFechas(int Idpais, int dia, int mes , int año);
        Task<IEnumerable<Festivo>> ValidarFestivoAño(int Idpais, int año);
       
    }
}
