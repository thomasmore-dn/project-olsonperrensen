
namespace PetsAPI.DataAccess;

public interface ISqlDataAccess
{
    Task<List<T>> LoadData<T, U>(string sp, U param);
    Task SaveData<T>(string sp, T param);
}