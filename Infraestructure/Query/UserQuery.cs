using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly AppDbContext _context;

        public UserQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
