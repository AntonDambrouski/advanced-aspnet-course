using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManager.DTOs;
using MovieManager.Models;
using MovieManager.Services;

namespace MovieManager.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieManagerService _movieManagerService;
        private readonly IReviewManagerService _reviewManagerService;

        public MoviesController([FromKeyedServices("real")] IMovieManagerService movieManagerService,
            IReviewManagerService reviewManagerService)
        {
            _movieManagerService = movieManagerService;
            _reviewManagerService = reviewManagerService;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            var movies = _movieManagerService.GetMovies();
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movieManagerService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            var reviews = _reviewManagerService.GetReviewsByMovieId(id);
            var averageRating = reviews.Any() ? reviews.Average(review => review.Rating) : 0.0D;
            var movieDto = new MovieWithReviewsDTO
            {
                Id = id,
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
                Reviews = reviews.Select(review => new ReviewDTO
                {
                    Rating = review.Rating,
                    Reviewer = review.Reviewer,
                    Message = review.Message,
                    MovieName = movie.Title,
                }).ToList(),
                AverageRating = averageRating,
            };

            return View(movieDto);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            var movies = _movieManagerService.GetMovies();
            var newId = movies.Any() ? movies.Max(movie => movie.Id) + 1 : 1;
            var newMovie = new Movie { Id = newId };
            return View(newMovie);
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                _movieManagerService.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movieManagerService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                _movieManagerService.UpdateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = _movieManagerService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection _)
        {
            try
            {
                _movieManagerService.DeleteMovie(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
