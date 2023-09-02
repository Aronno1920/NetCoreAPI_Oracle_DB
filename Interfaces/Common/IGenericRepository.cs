namespace DMSAPI.Interfaces.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string query);

        Task<List<T>> GetAllAsync(string query);
    }
}
