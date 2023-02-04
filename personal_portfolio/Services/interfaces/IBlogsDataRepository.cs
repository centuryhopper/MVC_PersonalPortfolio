namespace Personal_Portfolio.Services;



public interface IBlogsDataRepository<T>
{
    IEnumerable<T> Sort(bool isNewest);
    IEnumerable<T> GetData();
}