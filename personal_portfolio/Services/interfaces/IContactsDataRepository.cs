namespace Personal_Portfolio.Services;


public interface IContactsDataRepository<T>
{
    Task<IResult> PostDataAsync(T model);
    T? Update(T model);
    IEnumerable<T> GetData(string name);
    IEnumerable<T> GetData();
    T? Delete(int id);
    T? GetById(int id);
    Task<int> Commit();
}