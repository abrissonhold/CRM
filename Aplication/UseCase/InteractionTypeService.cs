using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class InteractionTypeService : IInteractionTypeService
    {
        private readonly IInteractionTypeQuery _query;

        public InteractionTypeService(IInteractionTypeQuery query)
        {
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            List<InteractionType> listInteractionType = (List<InteractionType>)await _query.GetAll();
            return listInteractionType.Select(listInteractionType => new GenericResponse
            {
                Id = listInteractionType.Id,
                Name = listInteractionType.Name,
            }
            ).ToList();
        }
    }
}
