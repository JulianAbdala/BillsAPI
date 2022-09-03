using RatingAPI.Entities;
using RatingAPI.DBContext;
using RatingAPI.Models;
using System;

namespace RatingAPI.Data
{
        public class UsersRepository : IUserRepository
        {
            internal readonly BillsContext _context;

            public UsersRepository(BillsContext context)
            {
                this._context = context;
            }

            public User? ValidateUser(AuthenticationRequestBody authRequestBody)
            {
                return _context.User.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
            }

            public bool SaveChange()
            {
                return (_context.SaveChanges() >= 0);
            }
            public User? GetUser(int userId)
            {
                return _context.User.FirstOrDefault(p => p.Id == userId);
            }
            public IEnumerable<User> GetUser()
            {
            return _context.User.OrderBy(x => x.Id).ToList(); ;
            }
            public void AddUser(User user)
            {
                _context.User.Add(user);
            }
            public void DeleteUser(int userId)
            {
            var user = _context.User.Find(userId);
            if (user != null)
                _context.User.Remove(user);
            }
    }
}
