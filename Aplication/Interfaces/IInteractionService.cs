using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IInteractionService
    {
        public Task<IEnumerable<InteractionResponse>> GetAll();
    }
}
