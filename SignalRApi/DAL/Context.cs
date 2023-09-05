using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class Context:DbContext // Postgre SQL ile veritabanı işlemleri
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
