using EntityLayer.Concrete;
using System.Collections.Generic;

namespace TraversalProject.Models
{
    public class AramaModel
    {
        public string AramaKey { get; set; }
        public List<About> Abouts { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<ContactUs> ContactUses { get; set; }
        public Reservation Reservations { get; set; }
        public Guide Guides { get; set; }
        public Announcement Announcements { get; set; }
        public Newsletter Newsletters { get; set; }
        public AppRole AppRoles { get; set; }
    }
}
