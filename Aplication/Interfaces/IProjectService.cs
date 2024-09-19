using Aplication.Request;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectResponse>> GetAll();
        public Task<ProjectResponse> CreateProject(ProjectRequest project);
        public Task<IEnumerable<ProjectResponse>> GetProjects(string name, int? campaignType, int? clientId, int offset, int size);
        public Task<ProjectRequestDetail> GetById(Guid id);
        public Task AddInteraction(Guid projectId, Interaction interaction);
        public Task AddTask(Guid projectId, Task task);
    }
}
