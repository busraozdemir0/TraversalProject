using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;

using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DefaultController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationSearch(string city, DateTime date)
        {
            var valueID = _destinationService.TDestinationSearch(city, date);

            if (valueID == 0) // id 0 dönerse belirtilen kriterlere uygun rota yoktur.
            {
                return RedirectToAction("Index", "Destination");
            }
                
            return RedirectToAction("DestinationDetails", "Destination", new { id = valueID });
        }
        

    }
}
