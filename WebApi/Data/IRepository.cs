using WebApi.Models;

namespace WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioAsyncById(int id);
    }
}
