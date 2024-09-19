using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IProjectCommand
    {
        public Task InsertProject(Project project);
        public Task InsertTask(Project project, Tasks task); 
        public Task InsertInteraction(Project project, Interaction interaction);
    }
}
