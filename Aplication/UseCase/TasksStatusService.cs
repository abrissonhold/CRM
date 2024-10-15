using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class TasksStatusService : ITaskStatusService
    {
        private readonly ITasksStatusQuery _query;

        public TasksStatusService(ITasksStatusQuery query)
        {
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            List<Domain.Entities.TaskStatus> TasksStatus = (List<Domain.Entities.TaskStatus>)await _query.GetAll();
            return TasksStatus.Select(TaskStatus => new GenericResponse
            {
                Id = TaskStatus.Id,
                Name = TaskStatus.Name,
            }
            ).ToList();
        }
    }
}
