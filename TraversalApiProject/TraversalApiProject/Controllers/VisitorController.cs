using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Windows.Markup;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]  // farklı projelerden gelen isteklere cevap vermek için CORS yapısı kullanılır.
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);  // başarılı bir işlem gerçekleştiği anlamına gelir
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]  //id'ye göre getirmek için attribute
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var visitorID = context.Visitors.Find(id);
                if (visitorID == null)
                {
                    return NotFound();  // eğer böyle bir id yoksa 404 koduyla hata dönecek
                }
                else
                {
                    return Ok(visitorID);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                var visitorID = context.Visitors.Find(id);
                if (visitorID == null)
                { return NotFound(); }
                else
                {
                    context.Visitors.Remove(visitorID);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var visitorID = context.Find<Visitor>(visitor.VisitorID);
                if (visitorID == null)
                {
                    return NotFound();  
                }
                else
                {
                    visitorID.Name = visitor.Name;
                    visitorID.Surname = visitor.Surname;
                    visitorID.Mail = visitor.Mail;
                    visitorID.City = visitor.City;
                    visitorID.Country = visitor.Country;
                    context.Visitors.Update(visitorID);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
