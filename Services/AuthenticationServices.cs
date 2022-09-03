using RatingAPI.Data;
using RatingAPI.Entities;
using RatingAPI.Models;
using RatingAPI.Services;

namespace RatingAPI.Services
{
    public class AutenticacionServices : IAuthenticationServices
    {
        private readonly IUserRepository _userRepository;

        public AutenticacionServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}