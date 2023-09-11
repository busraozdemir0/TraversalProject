using Microsoft.AspNetCore.Http;

namespace TraversalProject.Areas.Admin.Models
{
    public class AboutUpdateViewModel
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public IFormFile Image { get; set; }
    }
}
