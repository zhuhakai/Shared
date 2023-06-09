namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string sp, U parameters, string connStr = "Default");
    Task SaveData<T>(string sp, T parameters, string connStr = "Default");
}