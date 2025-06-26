using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces;
using MovieManagerApi.DTOs;
using MovieManagerApi.Filters;

namespace MovieManagerApi.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class MoviesController(IMoviesService moviesService,
    IReviewsService reviewsService, IMapper mapper) : ControllerBase
{
    // GET: api/<MoviesController>
    [HttpGet]
    [AddHeaderFilter("X-My-Custom-Header", "My custom value")]
    public async Task<IActionResult> Get()
    {
        var movies = await moviesService.GetAllMoviesAsync();
        var moviesDto = mapper.Map<List<MovieDTO>>(movies);

        return Ok(moviesDto);
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> Get(int id)
    {
        var movie = await moviesService.GetAsync(id);
        if (movie == null)
        {
            return BadRequest();
        }

        var reviews = await moviesService.GetReviewsByMovieIdAsync(id);
        var movieDto = mapper.Map<MovieDTO>(movie);
        movieDto.Reviews = mapper.Map<List<ReviewDTO>>(reviews);

        return Ok(movieDto);
    }

    // POST api/<MoviesController>
    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateMoveDTO movieDTO)
    {
        var movie = mapper.Map<Movie>(movieDTO);
        var created = await moviesService.CreateAsync(movie);

        var createdDTO = mapper.Map<MovieDTO>(created);

        return CreatedAtAction(nameof(Get), new { id = created.Id }, createdDTO);
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateMovieDTO movie)
    {
        var savedMovie = await moviesService.GetAsync(id);
        if (savedMovie == null)
        {
            return NotFound();
        }

        mapper.Map(movie, savedMovie);
        var updated = await moviesService.UpdateMovieAsync(id, savedMovie);

        var updatedDTO = mapper.Map<MovieDTO>(updated);
        return Ok(updatedDTO);
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await moviesService.DeleteMovieAsync(id);
       
        return Ok(deleted);
    }

    [HttpGet("{movieId:int}/reviews")]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int movieId)
    {
        var reviews = await moviesService.GetReviewsByMovieIdAsync(movieId);
        var reviewsDTO = mapper.Map<List<ReviewDTO>>(reviews);

        return Ok(reviewsDTO);
    }

    [HttpPost("{movieId:int}/reviews")]
    public async Task<ActionResult<Review>> AddReview(int movieId, [FromBody] CreateReviewDTO reviewDTO)
    {
        var movie = await moviesService.GetAsync(movieId);
        if (movie == null)
        {
            return NotFound();
        }

        var review = mapper.Map<Review>(reviewDTO);
        var created = await moviesService.AddReviewToMovieAsync(movieId, review);

        var createdDTO = mapper.Map<ReviewDTO>(created);

        return CreatedAtAction(nameof(GetReviews), new { movieId }, createdDTO);
    }

    [HttpPost("{movieId:int}/upload-poster")]
    public async Task<IActionResult> UploadPosterAsync(int movieId, IFormFile file)
    {
        if( file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var filename = await moviesService.UploadPosterAsync(movieId, file);

        return Ok(new { FileName = filename });
    }
}
