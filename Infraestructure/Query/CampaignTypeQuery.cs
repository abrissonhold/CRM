using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly AppDbContext _context;

        public CampaignTypeQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CampaignType>> GetAll()
        {
            return await _context.CampaignTypes.ToListAsync();
        }

        public async Task<CampaignType> GetById(int id)
        {
            var campaignType = await _context.CampaignTypes.FindAsync(id);
            if (campaignType == null)
            {
                return null;
            }

            return new CampaignType
            {
                Id = campaignType.Id,
                Name = campaignType.Name
            };
        }
    }
}
