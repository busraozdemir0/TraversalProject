using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace TraversalProject.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _SliderPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = _destinationService.TGetList();
            return View(destinations);
        }
    }
}
