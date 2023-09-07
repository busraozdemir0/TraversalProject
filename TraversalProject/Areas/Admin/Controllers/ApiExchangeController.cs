using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using TraversalProject.Areas.Admin.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class ApiExchangeController : Controller
    {
        // https://rapidapi.com/ntd119/api/booking-com13/ sitesinden bilgiler 
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel2> bookingExchangeViewModels= new List<BookingExchangeViewModel2>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com13.p.rapidapi.com/currencies?language_code=en-us"),
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
                var values=JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);  // nested dönüşümü için 2. bir model oluşturduk  
                return View(values.data);
            }
           
        }
    }
}
