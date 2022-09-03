using RatingAPI.Models;
using RatingAPI.Entities;
using static RatingAPI.Controllers.AuthenticationController;
namespace RatingAPI.Data
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public bool SaveChange();
    }
}
