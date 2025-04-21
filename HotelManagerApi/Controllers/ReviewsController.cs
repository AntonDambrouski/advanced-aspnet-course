using HotelManagerApi.Entities;
using Microsoft.AspNetCore.Mvc;
using reviewManagerApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        // GET: api/<ReviewsController>
        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return _reviewService.GetAllReviews();
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            var review = _reviewService.GetReview(id);
            if (review == null)
            {
                return BadRequest();
            }
            return review;
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public ActionResult<Review> Post([FromBody] Review review)
        {
            var reviews = _reviewService.GetAllReviews();
            var maxId = reviews.Count>0 ? reviews.Max(r=>r.Id) : 0;
            review.Id = maxId+1;
            _reviewService.AddReview(review);
            return CreatedAtAction(nameof(Get), new {id = review.Id}, review);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public ActionResult<Review> Put(int id, [FromBody] Review review)
        {
            var savedReview = _reviewService.GetReview(id);
            if (review == null)
            {
                return BadRequest();
            }
            var updatedReview = new Review
            {
                Id = id,
                Reviewer = review.Reviewer,
                Rating = review.Rating,
                ReviewText = review.ReviewText,
            };
            _reviewService.UpdateReview(id, updatedReview);

            return Ok(updatedReview);
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var review = _reviewService.GetReview(id);
            if (review == null)
            {
                return BadRequest();
            }
            _reviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
