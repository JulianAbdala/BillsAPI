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
        }
}
