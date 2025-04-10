using Microsoft.AspNetCore.Mvc;
using Web_API_N.Models;
using Web_API_N.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API_N.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailController : ControllerBase
    {
        private readonly IEventDetailRepository _repository;

        public EventDetailController(IEventDetailRepository repository)
        {
            _repository = repository;
        }

        // GET: api/EventDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetail>>> GetEventDetails()
        {
            var eventDetails = await _repository.GetAllEventDetailsAsync();
            return Ok(eventDetails);
        }

        // GET: api/EventDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetail>> GetEventDetail(int id)
        {
            var eventDetail = await _repository.GetEventDetailByIdAsync(id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            return Ok(eventDetail);
        }

        // POST: api/EventDetail
        [HttpPost]
        public async Task<ActionResult<EventDetail>> PostEventDetail(EventDetail eventDetail)
        {
            var createdEvent = await _repository.AddEventDetailAsync(eventDetail);
            return CreatedAtAction("GetEventDetail", new { id = createdEvent.Id }, createdEvent);
        }

        // PUT: api/EventDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventDetail(int id, EventDetail eventDetail)
        {
            if (id != eventDetail.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateEventDetailAsync(eventDetail);
            return NoContent();
        }

        // DELETE: api/EventDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventDetail(int id)
        {
            await _repository.DeleteEventDetailAsync(id);
            return NoContent();
        }
    }
}
