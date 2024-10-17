using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionQuery _query;

        public InteractionService(IInteractionQuery query)
        {
            _query = query;
        }

        public async Task<List<InteractionResponse>> GetAll()
        {
            List<Interaction> listInteraction = (List<Interaction>)await _query.GetAll();
            return listInteraction.Select(listInteraction => new InteractionResponse
            {
                InteractionID = listInteraction.InteractionID,
                Interaction = new GenericResponse
                {
                    Id = listInteraction.InteractionType.Id,
                    Name = listInteraction.InteractionType.Name
                },
                Date = listInteraction.Date,
                Notes = listInteraction.Notes
            }).ToList();
        }
    }
}
