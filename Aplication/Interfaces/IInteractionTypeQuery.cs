using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IInteractionTypeQuery
    {
        public Task<IEnumerable<InteractionType>> GetAll();
        public Task<InteractionType> GetById(int id);
    }
}
