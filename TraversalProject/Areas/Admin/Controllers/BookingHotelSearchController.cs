using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TraversalProject.Areas.Admin.Models;
using System.Collections.Generic;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com13.p.rapidapi.com/stays/properties/list-v2?location=Benidorm%2C%20Valencia%20Community%2C%20Spain&checkin_date=2023-10-01&checkout_date=2023-10-28&language_code=en-us&currency_code=USD&adults=2&children=1&children_age=3"),
                Headers =
    {
        { "X-RapidAPI-Key", "cf0f154e91msh5b813d6399529d8p1bbbc9jsnc488a4aa5f20" },
        { "X-RapidAPI-Host", "booking-com13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);  
                return View(values.data);
            }
        }
        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com13.p.rapidapi.com/stays/properties/list-v2?location={p}&checkin_date=2023-10-01&checkout_date=2023-10-28&language_code=en-us&currency_code=USD"),
                Headers =
    {
        { "X-RapidAPI-Key", "cf0f154e91msh5b813d6399529d8p1bbbc9jsnc488a4aa5f20" },
        { "X-RapidAPI-Host", "booking-com13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }
        }
    }
}
