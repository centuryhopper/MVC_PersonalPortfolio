namespace Personal_Portfolio.Services;


public interface IContactsDataRepository<T>
{
    T? PostData(T model);
    T? Update(T model);
    IEnumerable<T> GetData(string name);
    IEnumerable<T> GetData();
    T? Delete(int id);
    T? GetById(int id);
    int Commit();
}