using BookingSystem.Core.Features.Reservations.Commands;
using BookingSystem.Core.Features.Reservations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class ReservationsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllReservationsQuery()));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var reservation = await _mediator.Send(new GetReservationByIdQuery(id));
                return Ok(reservation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Reservation not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            var reservation = await _mediator.Send(command with { ReservedById = 1 });
            return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReservationCommand command)
        {
            try
            {
                var updated = await _mediator.Send(command with { Id = id });
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Reservation not found");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteReservationCommand(id));
            return NoContent();
        }
    }

}
