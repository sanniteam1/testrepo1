using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHotel360.DataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartHotel360.PublicWeb.Controllers
{
    [Route("api/[controller]")]
    public class DataAPIController : Controller
    {
		private DataLayer.DataLayer dataLayer = new DataLayer.DataLayer();

        // GET: api/values
		[Route("getCities")]
		[HttpGet("{searchString}")]
		public JsonResult GetCities(string searchString)
        {
			var result = dataLayer.cities.Where(x => x.name.ToLower().Contains(searchString.ToLower())).ToList();

			return Json(result);
        }

		[Route("getHotels")]
        [HttpGet("{id}")]
        public JsonResult GetHotels(int id)
        {
			var result = dataLayer.hotels.Where(x => x.cityId == id).ToList();

            return Json(result);
        }
        
		[Route("getSortHotels")]
        [HttpGet("{id, rating, max, min}")]
        public JsonResult GetSortHotels(int id, int rating, int max, int min)
        {
			if (max <= min) {
				max = 1000;
			}

			var result = dataLayer.hotels.Where(x => x.cityId == id && x.rating >= rating && x.price <= max && x.price >= min).ToList();

            return Json(result);
        }

        
		[Route("getHotel")]
        [HttpGet("{id}")]
        public JsonResult GetHotel(int id)
        {
			var result = dataLayer.hotels.Where(x => x.id == id).FirstOrDefault();

            return Json(result);
        }

		[Route("getReviews")]
        [HttpGet]
        public JsonResult GetReviews()
        {       
			return Json(dataLayer.GenerateReviews());
        }

      
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [Route("bookConfirmation")]
        [HttpPost]
        public string bookConfirmation(string id, string checkinDate, string checkoutDate, string roomCout)
        {
            return "success";
        }

    }
}
