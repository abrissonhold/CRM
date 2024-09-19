using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IProjectQuery
    {
        public Task<IEnumerable<Project>> GetAll();
        public Task<Project> GetById(Guid id);
        public Task<IEnumerable<Project>> GetProjects(string? name, int? campaignType, int? clientId, int offset, int size);

    }
}
