using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class InteractionQuery : IInteractionQuery
    {
        private readonly AppDbContext _context;

        public InteractionQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Interaction>> GetAll()
        {
            return await _context.Interactions.ToListAsync();
        }
    }
}
