using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;    
    private readonly MovieRepository movieRepository;

    public MovieController(ILogger<MovieController> logger, MovieRepository movieRepository)
    {
        _logger = logger;        
        this.movieRepository = movieRepository;
    }

    [HttpGet(Name = "GetMovies")]
    public IAsyncEnumerable<Movie> Get() => movieRepository.GetMovies();
}
