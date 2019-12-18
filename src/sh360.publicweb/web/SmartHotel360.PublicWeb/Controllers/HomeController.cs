using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartHotel360.PublicWeb.Models;

namespace SmartHotel360.PublicWeb.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.reservation.StartDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ReservationModel reservation)
        {

            return RedirectToAction("SearchRooms", reservation);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ContactUs()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SearchRooms(ReservationModel reservation, int id)
        {

            return RedirectToAction("RoomDetails", reservation);
        }

        public IActionResult SearchRooms(ReservationModel reservation)
        {

            return View(reservation);
        }

        public IActionResult Pets()
        {

            return View();
        }

        public IActionResult RoomDetails(ReservationModel model)
        {
            return View(model);
        }

        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LogMeIn()
        {
            if (FakeAuthSettings.IsLoggedIn)
            {
                FakeAuthSettings.LogoffFakeAuthSettings();
            }
            else
            {
                FakeAuthSettings.LoginFakeAuthSettings();
            }

            return Json(new { name= FakeAuthSettings.Name, picUrl= FakeAuthSettings.PicUrl });
        }

    }
}
