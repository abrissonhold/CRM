using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IInteractionQuery
    {
        public Task<IEnumerable<Interaction>> GetAll();

    }
}
