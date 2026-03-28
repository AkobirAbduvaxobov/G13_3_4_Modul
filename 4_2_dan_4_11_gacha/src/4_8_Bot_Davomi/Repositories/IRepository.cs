namespace _4_8_Bot_Davomi.Repositories;

public interface IRepository<T>
{
    public Task<List<T>> GetAllAsync();
    public Task SaveAllAsync(List<T> items);
}