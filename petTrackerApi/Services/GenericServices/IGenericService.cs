namespace petTrackerApi.Services.GenericServices
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Create(T dto);
        Task<T> Update(int id, T dto);
        Task<T> Delete(int id);
    }
}
