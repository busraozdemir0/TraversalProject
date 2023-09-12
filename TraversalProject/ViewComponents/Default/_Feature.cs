using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _Feature(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                // son öne çıkardığımız rotayı alalım (solda büyük css'e sahip olduğu için)
                var firstFeatured= context.Destinations.Where(x => x.Status.Equals(true)).OrderByDescending(y => y.DestinationID).Take(1).FirstOrDefault();
                
                ViewBag.city=firstFeatured.City;
                ViewBag.daynight = firstFeatured.DayNight;
                ViewBag.price = firstFeatured.Price;
                ViewBag.image=firstFeatured.CoverImage;
            }

            // ilk 4 tane öne çıkan değeri aldık
            var values = _featureService.TFeaturedDestinations();
            return View(values);
        }
    }
}
