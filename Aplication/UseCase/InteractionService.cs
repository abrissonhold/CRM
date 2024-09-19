using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplication.UseCase
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionQuery _query;

        public InteractionService(IInteractionQuery query)
        {
            _query = query;
        }

        public Task<InteractionRequest> CreateInteraction(InteractionRequest interactionRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InteractionResponse>> GetAll()
         {
            List<Interaction> listInteraction = (List<Interaction>)await _query.GetAll();
            return listInteraction.Select(listInteraction => new InteractionResponse
            {
                InteractionID = listInteraction.InteractionID,
                ProjectID = listInteraction.ProjectID,
                InteractionTypeID = listInteraction.InteractionTypeID,
                Date = listInteraction.Date,
                Notes = listInteraction.Notes
            }).ToList();
         }
    }
}
