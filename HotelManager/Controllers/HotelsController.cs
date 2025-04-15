using HotelManager.DTOs;
using HotelManager.Models;
using HotelManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace HotelManager.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelManagerService _hotelManagerService;
        private readonly IReviewManagerService _reviewManagerService;

        public HotelsController(IHotelManagerService hotelManagerService, IReviewManagerService reviewManagerService)
        {
            _hotelManagerService = hotelManagerService;
            _reviewManagerService = reviewManagerService;
        }
        // GET: HotelController
        public ActionResult Index()
        {
            var hotels = _hotelManagerService.GetHotels();
            return View(hotels);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            var hotel = _hotelManagerService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            var reviews = _reviewManagerService.GetReviewsByHotelId(id);
            var averageRating = reviews.Any() ? reviews.Average(review=>review.Rating): 0.00;
            var hotelDTO = new HotelWithReviewsDTO
            {
                Id = id,
                Name = hotel.Name,
                Address = hotel.Address,
                NumberOfStars = hotel.NumberOfStars,
                Reviews = reviews.Select(review => new ReviewDTO
                {
                    Rating = review.Rating,
                    Reviewer = review.Reviewer,
                    ReviewText = review.ReviewText,
                    HotelName = hotel.Name,
                }).ToList(),
                AverageRating = averageRating,
            };
            return View(hotelDTO);
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            var hotels = _hotelManagerService.GetHotels();
            var newId = hotels.Any() ? hotels.Max(h => h.Id) + 1 : 1;
            var newHotel = new Hotel { Id =  newId };
            return View(newHotel);
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            try
            {
                _hotelManagerService.AddHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            var hotel = _hotelManagerService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel hotel)
        {
            try
            {
                _hotelManagerService.UpdateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            var hotel = _hotelManagerService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _hotelManagerService.DeleteHotel(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
