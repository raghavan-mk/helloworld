using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private readonly ILogger<MovieController> _logger;
    private readonly MovieDAL movieDAL;

    public MovieController(ILogger<MovieController> logger, MovieDAL movieDAL)
    {
        _logger = logger;
        this.movieDAL = movieDAL;
    }

    [HttpGet(Name = "GetMovies")]
    public IAsyncEnumerable<Movie> Get() => movieDAL.GetMovies();
}
