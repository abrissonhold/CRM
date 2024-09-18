using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IInteractionTypeQuery
    {
        Task<IEnumerable<InteractionType>> GetAll();

    }
}
