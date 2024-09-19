using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IProjectCommand
    {
        public Task InsertProject(Project project);
    }
}
