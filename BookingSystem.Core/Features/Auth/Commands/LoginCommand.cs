using BookingSystem.Core.DTOs.Auth;
using MediatR;

namespace BookingSystem.Core.Features.Auth.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
