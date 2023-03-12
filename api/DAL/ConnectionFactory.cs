using Npgsql;

public class NpgSqlConnectionFactory 
{    
    private readonly string connectionString;
    private readonly ILogger<NpgSqlConnectionFactory> logger;

    public NpgSqlConnectionFactory(IConfiguration configuration, ILogger<NpgSqlConnectionFactory> logger)
    {
        this.connectionString = configuration.GetConnectionString("npgsql");
        this.logger = logger;
    }

    public NpgsqlConnection CreateConnection() => new(connectionString);

}