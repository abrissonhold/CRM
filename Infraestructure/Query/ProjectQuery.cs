﻿using Aplication.Interfaces;
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
            var p = _context.Projects
                .Include(p => p.Tasks)
                    .ThenInclude(p => p.TasksStatus)
                .Include(p => p.Tasks)
                    .ThenInclude(p => p.User)
                .Include(p => p.Interactions)
                    .ThenInclude(p => p.InteractionType)
                .Include(p => p.Client)
                .Include(p => p.CampaignType)
                .FirstOrDefault(p => p.ProjectID == id);

            return p;
        }

        public async Task<Project> GetByName(string name)
        {
            var p = _context.Projects
                .Include(p => p.Tasks)
                    .ThenInclude(p => p.TasksStatus)
                .Include(p => p.Tasks)
                    .ThenInclude(p => p.User)
                .Include(p => p.Interactions)
                    .ThenInclude(p => p.InteractionType)
                .Include(p => p.Client)
                .Include(p => p.CampaignType)
                .FirstOrDefault(p => p.ProjectName == name);

            return p;
        }
    }
}
