using HelloWorld;
using Npgsql;

public class MovieDAL
{
    private readonly ILogger<MovieDAL> logger;
    private readonly IConfiguration configuration;

    public MovieDAL(ILogger<MovieDAL> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
    }

    public async IAsyncEnumerable<Movie> GetMovies()
    {
        var cs = configuration.GetConnectionString("pgpsql");

        var selectQuery = "SELECT Id,\"Name\",\"Year\",Genre FROM Movie order by Id";

        using var connection = new NpgsqlConnection(cs);
        connection.Open();
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