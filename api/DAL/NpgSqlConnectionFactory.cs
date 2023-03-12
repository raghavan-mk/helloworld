using System.Data;
using System.Data.Common;
using Npgsql;

public class NpgSqlConnectionFactory
{    
    private readonly string connectionString;
    public NpgSqlConnectionFactory(IConfiguration configuration) =>
        this.connectionString = configuration.GetConnectionString("npgsql")!;
    public NpgsqlConnection CreateConnection() => new(connectionString);
}
