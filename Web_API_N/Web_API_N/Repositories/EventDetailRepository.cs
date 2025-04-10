using Microsoft.EntityFrameworkCore;
using Web_API_N.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API_N.Repositories
{
    public class EventDetailRepository : IEventDetailRepository
    {
        private readonly EventDetailsContext _context;

        public EventDetailRepository(EventDetailsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDetail>> GetAllEventDetailsAsync()
        {
            return await _context.EventDetails.ToListAsync();
        }

        public async Task<EventDetail> GetEventDetailByIdAsync(int id)
        {
            return await _context.EventDetails.FindAsync(id);
        }

        public async Task<EventDetail> AddEventDetailAsync(EventDetail eventDetail)
        {
            _context.EventDetails.Add(eventDetail);
            await _context.SaveChangesAsync();
            return eventDetail;
        }

        public async Task UpdateEventDetailAsync(EventDetail eventDetail) 
        {
            _context.Entry(eventDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventDetailAsync(int id)
        {
            var eventDetail = await _context.EventDetails.FindAsync(id);
            if (eventDetail != null)
            {
                _context.EventDetails.Remove(eventDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
