using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class InteractionTypeQuery : IInteractionTypeQuery
    {
        private readonly AppDbContext _context;

        public InteractionTypeQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InteractionType>> GetAll()
        {
            return await _context.InteractionTypes.ToListAsync();
        }
        public async Task<InteractionType> GetById(int id)
        {
            return await _context.InteractionTypes.FindAsync(id);
        }
    }
}
