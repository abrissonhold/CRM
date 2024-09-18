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
    }
}
