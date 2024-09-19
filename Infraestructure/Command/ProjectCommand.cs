using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

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

    }
}
