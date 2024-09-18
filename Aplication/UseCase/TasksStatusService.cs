using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class TasksStatusService : ITasksStatusService
    {
        private readonly ITasksStatusQuery _query;

        public TasksStatusService(ITasksStatusQuery query)
        {
            _query = query;
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            List<TasksStatus> TasksStatusType = (List<TasksStatus>)await _query.GetAll();
            return TasksStatusType.Select(listTasksStatus => new GenericResponse
            {
                Id = listTasksStatus.Id,
                Name = listTasksStatus.Name,
            }
            ).ToList();
        }
    }
}
