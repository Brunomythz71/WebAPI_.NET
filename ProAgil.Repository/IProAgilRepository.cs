using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T> (T entity) where T : class;
         Task<bool> SaveChanges();
         Task<Evento[]> GetAllEventoByTema(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEvento(bool includePalestrantes);
         Task<Evento> GetAllEventoById(int EventoId, bool includePalestrantes);
         Task<Palestrante[]> GetAllPalestrantesByName(string NamePalestrante, bool includeEventos);
         Task<Palestrante> GetPalestrantesId(int PalestranteID, bool includeEventos);
    }
}