using HelloWorld;
using Npgsql;

public class MovieRepository
{
    private readonly ILogger<MovieRepository> logger;
    private readonly NpgSqlConnectionFactory npgSqlConnectionFactory;

    public MovieRepository(ILogger<MovieRepository> logger, NpgSqlConnectionFactory npgSqlConnectionFactory)
    {
        this.logger = logger;
        this.npgSqlConnectionFactory = npgSqlConnectionFactory;
    }

    public async IAsyncEnumerable<Movie> GetMovies()
    {
        var selectQuery = "SELECT Id,\"Name\",\"Year\",Genre FROM Movie order by Id";

        using var connection = npgSqlConnectionFactory.CreateConnection();
        await connection.OpenAsync();
        using var command = new NpgsqlCommand(selectQuery, connection);
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            yield return new Movie
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Year = reader.GetInt32(2),
                Genre = reader.GetString(3)
            };
        }
    }
}