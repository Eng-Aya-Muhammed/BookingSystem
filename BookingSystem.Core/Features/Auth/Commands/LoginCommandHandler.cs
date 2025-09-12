using BookingSystem.Core.DTOs.Auth;
using BookingSystem.Core.Models;
using BookingSystem.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace BookingSystem.Core.Features.Auth.Commands
{
    public class LoginCommandHandler(
     UserManager<User> _userManager,
     JwtTokenService _jwtTokenService
 ) : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var token = await _jwtTokenService.GenerateTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            return new LoginResponse
            {
                Token = token,
                UserId = user.Id.ToString(),
                Email = user.Email!,
                Roles = roles
            };
        }
    }

}
