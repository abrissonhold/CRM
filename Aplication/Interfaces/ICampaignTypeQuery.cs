using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface ICampaignTypeQuery
    {
        Task<IEnumerable<CampaignType>> GetAll();
        public Task<CampaignType> GetById(int id);

    }
}
