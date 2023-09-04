using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // Identity'deki User class'ının alanları haricinde isim, soyisim, image vs eklemek için bu sınıfı oluşturuyoruz
    public class AppUser:IdentityUser<int>
    {
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
