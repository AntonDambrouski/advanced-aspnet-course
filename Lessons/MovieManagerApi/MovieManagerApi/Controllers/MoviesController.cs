using Microsoft.AspNetCore.Mvc;
using MovieManagerApi.Entities;
using MovieManagerApi.Filters;
using MovieManagerApi.Services;

namespace MovieManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMoviesService _moviesService;
    private readonly IReviewsService _reviewsService;

    public MoviesController(IMoviesService moviesService, IReviewsService reviewsService)
    {
        _moviesService = moviesService;
        _reviewsService = reviewsService;
    }

    // GET: api/<MoviesController>
    [HttpGet]
    [AddHeaderFilter("X-My-Custom-Header", "My custom value")]
    public IEnumerable<Movie> Get()
    {
        throw new ArgumentOutOfRangeException();
        return _moviesService.GetAllMovies();
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        var movie = _moviesService.GetMovie(id);
        if (movie == null)
        {
            return BadRequest();
        }

        return movie;
    }

    // POST api/<MoviesController>
    [HttpPost]
    public ActionResult Post([FromBody] Movie movie)
    {
        var movies = _moviesService.GetAllMovies();
        var maxId = movies.Count > 0 ? movies.Max(m => m.Id) : 0;
        movie.Id = maxId + 1;

        _moviesService.AddMovie(movie);

        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Movie movie)
    {
        var savedMovie = _moviesService.GetMovie(id);
        if (savedMovie == null)
        {
            return BadRequest();
        }

        var updatedMovie = new Movie
        {
            Id = id,
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre
        };

        _moviesService.UpdateMovie(id, updatedMovie);

        return Ok(updatedMovie);
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var movie = _moviesService.GetMovie(id);
        if (movie == null)
        {
            return BadRequest();
        }

        _moviesService.DeleteMovie(id);
        return NoContent();
    }

    [HttpGet("{movieId:int}/reviews")]
    public ActionResult<IEnumerable<Review>> GetReviews(int movieId)
    {
        var reviews = _reviewsService.GetReviewsByMovieId(movieId);

        return Ok(reviews);
    }

    [HttpPost("{movieId:int}/reviews")]
    public ActionResult<Review> AddReview(int movieId, [FromBody] Review review)
    {
        var movie = _moviesService.GetMovie(movieId);
        if (movie == null)
        {
            return NotFound();
        }

        var reviews = _reviewsService.GetAllReviews();
        var maxId = reviews.Count > 0 ? reviews.Max(r => r.Id) : 0;
        review.Id = maxId + 1;
        review.MovieId = movieId;

        _reviewsService.AddReview(review);

        return CreatedAtAction(nameof(GetReviews), new { movieId }, review);
    }
}
