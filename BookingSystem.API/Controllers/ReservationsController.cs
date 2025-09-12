using BookingSystem.Core.Features.Reservations.Commands;
using BookingSystem.Core.Features.Reservations.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReservationsController(IMediator _mediator) : ControllerBase
    {

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var reservations = await _mediator.Send(new GetAllReservationsQuery());
                return Ok(reservations);
            }

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
                catch (Exception ex) 
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

         [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            try
            {
                var reservation = await _mediator.Send(command);
                return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
            }
            catch (ValidationException validationEx)
            {
                return BadRequest(validationEx.Errors);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


            [HttpPut("{id:int}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdateReservationCommand command)
            {
                try
                {
                    command = command with { Id = id };

                    var updated = await _mediator.Send(command);
                    return Ok(updated);
                    }
                catch (ValidationException validationEx)
                {
                    return BadRequest(validationEx.Errors);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound("Reservation not found");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteReservationCommand(id));
                return Ok(new { message = "Reservation deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Reservation not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }

    }
}


