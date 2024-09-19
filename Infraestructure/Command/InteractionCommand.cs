using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class InteractionCommand : IInteractionCommand
    {
        private readonly AppDbContext _context;

        public InteractionCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertInteraction(Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            await _context.SaveChangesAsync();
        }

    }
}
