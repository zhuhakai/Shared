
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string sp,
        U parameters,
        string connStr = "Default")
    {
        using var conn = new SqlConnection(_config.GetConnectionString(connStr));

        return await conn.QueryAsync<T>(sp, parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);

    }

    public async Task SaveData<T>(
        string sp,
        T parameters,
        string connStr = "Default")
    {
        using var conn = new SqlConnection(_config.GetConnectionString(connStr));

        await conn.ExecuteAsync(sp, parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}
