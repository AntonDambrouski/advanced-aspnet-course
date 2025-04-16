using Microsoft.AspNetCore.Mvc;
using MovieManager.Core.Entities;
using MovieManager.Core.Exceptions;
using MovieManager.Core.Interfaces;
using MovieManagerApi.Filters;

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
    public async ValueTask<IEnumerable<Movie>> Get()
    {
        return await _moviesService.GetAllMoviesAsync();
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public async ValueTask<ActionResult<Movie>> Get(int id)
    {
        var movie = await _moviesService.GetAsync(id);
        if (movie == null)
        {
            return BadRequest();
        }

        return movie;
    }

    // POST api/<MoviesController>
    [HttpPost]
    public async ValueTask<ActionResult> Post([FromBody] Movie movie)
    {
        var created = await _moviesService.CreateAsync(movie);

        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public async ValueTask<ActionResult> Put(int id, [FromBody] Movie movie)
    {
        var updated = await _moviesService.UpdateMovieAsync(id, movie);
        return Ok(updated);
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public async ValueTask<ActionResult> Delete(int id)
    {
        var deleted = await _moviesService.DeleteMovieAsync(id);
       
        return Ok(deleted);
    }

    //[HttpGet("{movieId:int}/reviews")]
    //public ValueTask<ActionResult<IEnumerable<Review>>> GetReviews(int movieId)
    //{
    //    var reviews = _reviewsService.GetReviewsByMovieId(movieId);

    //    return Ok(reviews);
    //}

    //[HttpPost("{movieId:int}/reviews")]
    //public ActionResult<Review> AddReview(int movieId, [FromBody] Review review)
    //{
    //    var movie = _moviesService.GetMovie(movieId);
    //    if (movie == null)
    //    {
    //        return NotFound();
    //    }

    //    var reviews = _reviewsService.GetAllReviews();
    //    var maxId = reviews.Count > 0 ? reviews.Max(r => r.Id) : 0;
    //    review.Id = maxId + 1;
    //    review.MovieId = movieId;

    //    _reviewsService.AddReview(review);

    //    return CreatedAtAction(nameof(GetReviews), new { movieId }, review);
    //}
}
