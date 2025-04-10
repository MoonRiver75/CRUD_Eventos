using Microsoft.EntityFrameworkCore;

namespace Web_API_N.Models
{
    public class EventDetailsContext : DbContext
    {
        public EventDetailsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventDetail> EventDetails { get; set; }
    }
}
