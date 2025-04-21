using System.Net.WebSockets;
using HotelManagerApi.Entities;
using HotelManagerApi.Filters;
using HotelManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using reviewManagerApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;
    private readonly IReviewService _reviewService;

    public HotelsController(IHotelService hotelService, IReviewService reviewService)
    {
        _hotelService = hotelService;
        _reviewService = reviewService;
    }
    // GET: api/<HotelsController>
    [HttpGet]
    [AddHeaderFilter("Test_Header", "Test value")]
    public IEnumerable<Hotel> Get()
    {
        return _hotelService.GetAllHotels();
    }

    // GET api/<HotelsController>/5
    [HttpGet("{id}")]
    public ActionResult<Hotel> Get(int id)
    {
        var hotel = _hotelService.GetHotel(id);
        if (hotel == null)
        {
            return BadRequest();
        }
        return hotel;
    }

    // POST api/<HotelsController>
    [HttpPost]
    public ActionResult Post([FromBody] Hotel hotel)
    {
        var hotels = _hotelService.GetAllHotels();
        var maxId = hotels.Count>0 ? hotels.Max(h=> h.Id) : 0;
        hotel.Id = maxId + 1;
        _hotelService.AddHotel(hotel);
        return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
    }

    // PUT api/<HotelsController>/5
    [HttpPut("{id}")]
    public ActionResult<Hotel> Put(int id, [FromBody] Hotel hotel)
    {
        var savedHotel = _hotelService.GetHotel(id);
        if (hotel == null)
        {
            return BadRequest();
        }
        var updatedHotel = new Hotel
        {
            Id = id,
            Name = hotel.Name,
            NumberOfStars = hotel.NumberOfStars,
            Address = hotel.Address,
        };
        _hotelService.UpdateHotel(id, updatedHotel);

        return Ok(updatedHotel);
    }

    // DELETE api/<HotelsController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hotel = _hotelService.GetHotel(id);
        if (hotel == null)
        {
            return BadRequest();
        }
        _hotelService.DeleteHotel(id);
        return NoContent();
    }

    [HttpGet("{hotelId:int}/reviews")]
    public ActionResult<IEnumerable<Review>> GetByHotelId(int hotelId)
    {
        var reviews = _reviewService.GetReviewsByHotelId(hotelId);
        return Ok(reviews);
    }

    [HttpPost("{hotelId:int}/reviews")]
    public ActionResult<Review> AddReview(int hotelId, [FromBody] Review review)
    {
        var hotel = _hotelService.GetHotel(hotelId);
        if (hotel == null)
        {
            return NotFound();
        }
        var reviews = _reviewService.GetAllReviews();
        var maxId = reviews.Count > 0 ? reviews.Max(h => h.Id) : 0;
        review.Id = maxId + 1;
        review.HotelId = hotelId;
        _reviewService.AddReview(review);
        return CreatedAtAction(nameof(AddReview), new { hotelId }, review);
    }
}
