using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManager.Models;
using MovieManager.Services;

namespace MovieManager.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewManagerService _reviewManagerService;
        public ReviewsController(IReviewManagerService reviewManagerService)
        {
            _reviewManagerService = reviewManagerService;
        }

        // GET: ReviewsController
        public ActionResult Index()
        {
            var reviews = _reviewManagerService.GetAllReviews();
            return View(reviews);
        }

        // GET: ReviewsController/Details/5
        public ActionResult Details(int id)
        {
            var review = _reviewManagerService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: ReviewsController/Create
        public ActionResult Create(int movieId)
        {
            var movie = new Review
            {
                MovieId = movieId
            };

            return View(movie);
        }

        // POST: ReviewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            try
            {
                var reviews = _reviewManagerService.GetAllReviews();
                review.Id = reviews.Any() ? reviews.Max(review => review.Id) + 1 : 1;

                _reviewManagerService.AddReview(review);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewsController/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _reviewManagerService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: ReviewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Review review)
        {
            try
            {
                _reviewManagerService.UpdateReview(id, review);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewsController/Delete/5
        public ActionResult Delete(int id)
        {
            var review = _reviewManagerService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: ReviewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection _)
        {
            try
            {
                _reviewManagerService.RemoveReview(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
