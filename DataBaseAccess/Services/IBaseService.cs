namespace DataBaseAccess.Services
{
    public interface IBaseService <T>
    {
        List<T> GetAll();

        T? Get(int id);

        bool Add(T newItem);

        bool Edit(int id, T editItem);

        bool Delete(int id);
    }
}
