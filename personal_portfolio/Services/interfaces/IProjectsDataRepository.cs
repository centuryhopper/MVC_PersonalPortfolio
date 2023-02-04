namespace Personal_Portfolio.Services;



public interface IProjectsDataRepository<T>
{
    IEnumerable<T> GetData();
    IEnumerable<T> Search(string searchTerm);
}
