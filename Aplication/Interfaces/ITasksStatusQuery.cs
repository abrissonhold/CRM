namespace Aplication.Interfaces
{
    public interface ITasksStatusQuery
    {
        Task<IEnumerable<Domain.Entities.TaskStatus>> GetAll();
        public Task<Domain.Entities.TaskStatus> GetById(int id);
    }
}
