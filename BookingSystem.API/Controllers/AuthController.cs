using AutoMapper;
using BookingSystem.Core.DTOs.Auth;
using BookingSystem.Core.Features.Auth.Commands;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var command = _mapper.Map<LoginCommand>(request);
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (ValidationException validationEx)
            {
                return BadRequest(validationEx.Errors);
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
    }

}
