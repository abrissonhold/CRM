using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly AppDbContext _context;

        public ProjectQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjects(string? name, int? campaignType, int? clientId, int offset, int size)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Interactions)
                .Include(p => p.Client)
                .Include(p => p.CampaignType).Where(p => (name == null || p.ProjectName.Contains(name))
                                                         && (campaignType == null || p.CampaignTypeID == campaignType)
                                                         && (clientId == null || p.ClientID == clientId))
                                                        .Skip(offset)
                                                        .Take(size)
                                                        .ToListAsync();
        }


        public async Task<Project> GetById(Guid id)
        {
            var project = _context.Projects.Include(p => p.CampaignType).Include(p => p.Client)
                                 .FirstOrDefault(p => p.ProjectID == id);
            return project;
        }
    }
}
