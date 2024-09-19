using Aplication.Request;
using Aplication.Response;
using Domain.Entities;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectResponse>> GetAll();
        public Task<ProjectResponse> CreateProject(ProjectRequest project);
        public Task<IEnumerable<ProjectResponse>> GetProjects(string name, int? campaignType, int? clientId, int offset, int size);
        public Task<ProjectResponseDetail> GetById(Guid id);
        public Task<InteractionResponse> AddInteraction(Guid projectId, InteractionRequest interaction);
        public Task<TasksResponse> AddTask(Guid projectId, TasksRequest task);
    }
}
