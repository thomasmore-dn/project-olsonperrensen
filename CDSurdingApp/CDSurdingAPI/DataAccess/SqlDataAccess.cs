using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace PetsAPI.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    // Geldt voor GET, GET/{id} en POST
    public async Task<List<T>> LoadData<T, U>(string sp, U param)
    {
        using IDbConnection c = new SqlConnection(_config.GetConnectionString("Default"));
        return (await c.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure)).ToList();
    }

    // Geldt voor PUT, PUT (Complete ) en DELETE
    public async Task SaveData<T>(string sp, T param)
    {
        using IDbConnection c = new SqlConnection(_config.GetConnectionString("Default"));
        await c.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
    }
}
