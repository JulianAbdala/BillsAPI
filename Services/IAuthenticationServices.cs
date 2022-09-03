using RatingAPI.Entities;
using RatingAPI.Models;
using static RatingAPI.Controllers.AuthenticationController;

namespace RatingAPI.Services
{
    public interface IAuthenticationServices
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}