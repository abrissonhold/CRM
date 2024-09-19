using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly AppDbContext _context;

        public ProjectCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task InsertProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task InsertInteraction(Project project, Domain.Entities.Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task InsertTask(Project project, Tasks task)
        {
            _context.Tasks.Add(task);       
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
