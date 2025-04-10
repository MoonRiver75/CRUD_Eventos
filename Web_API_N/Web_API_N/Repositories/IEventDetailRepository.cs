using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API_N.Models;

namespace Web_API_N.Repositories
{
    public interface IEventDetailRepository
    {
        Task<IEnumerable<EventDetail>> GetAllEventDetailsAsync();
        Task<EventDetail> GetEventDetailByIdAsync(int id);
        Task<EventDetail> AddEventDetailAsync(EventDetail eventDetail);
        Task UpdateEventDetailAsync(EventDetail eventDetail);
        Task DeleteEventDetailAsync(int id);
    }
}
