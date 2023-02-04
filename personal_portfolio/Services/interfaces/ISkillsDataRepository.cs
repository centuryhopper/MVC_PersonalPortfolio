namespace Personal_Portfolio.Services;


public interface ISkillsDataRepository<T>
{
    Dictionary<string, IEnumerable<T>> GetData();
}
