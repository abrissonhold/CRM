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
    }
}
