using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class CampaignTypeService : ICampaignTypeService
    {
        private readonly ICampaignTypeQuery _query;

        public CampaignTypeService(ICampaignTypeQuery query)
        {
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            List<CampaignType> listCampaignType = (List<CampaignType>)await _query.GetAll();
            return listCampaignType.Select(listCampaignType => new GenericResponse
            {
                Id = listCampaignType.Id,
                Name = listCampaignType.Name,
            }
            ).ToList();
        }
    }
}
