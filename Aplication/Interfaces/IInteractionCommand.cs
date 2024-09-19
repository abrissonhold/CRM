using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IInteractionCommand
    {
        public Task InsertInteraction(Interaction interaction);
    }
}
