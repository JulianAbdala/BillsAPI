using RatingAPI.Models;
using RatingAPI.Entities;
using static RatingAPI.Controllers.AuthenticationController;
namespace RatingAPI.Data
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public bool SaveChange();
        public User? GetUser(int userId);
        public IEnumerable<User> GetUser();
        public void DeleteUser(int userId);
        public void AddUser(User user);
    }
}
