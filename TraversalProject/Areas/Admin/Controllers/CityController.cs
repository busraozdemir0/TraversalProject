using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalProject.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CityController : Controller
    {
        // AJAX ile çalışma

        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID= 1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID= 2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID= 3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};

        //public IActionResult CityList()
        //{
        //    // Static bir şekilde tanımlanmış olan şehir listesini ajax sayesinde listeleme
        //    var jsonCity = JsonConvert.SerializeObject(cities); // cities'den gelen değerleri json'a çeviriyoruz
        //    return Json(jsonCity);
        //}
        public IActionResult CityList()
        {
            // Destination'ları ajax sayesinde listeleme
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList()); // cities'den gelen değerleri json'a çeviriyoruz
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
        public IActionResult GetById(int DestinationID)
        {
            var value = _destinationService.TGetByID(DestinationID);
            if (value == null)
            {

            }
            else
            {
                var serivalues = JsonConvert.SerializeObject(value);
                return Json(serivalues);

            }
            return View();
        }

        public IActionResult DeleteCity(int id)
        {
            var deleteID = _destinationService.TGetByID(id);
            _destinationService.TDelete(deleteID);
            return NoContent();  // boş bir içerik döndürsün(hata almamak için)
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);

            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
    }
}
