using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class TasksStatusService : ITaskService
    {
        private readonly ITasksStatusQuery _query;

        public TasksStatusService(ITasksStatusQuery query)
        {
            _query = query;
        }

        public Task<TasksRequest> CreateTask(TasksRequest tasksRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenericResponse>> GetAll()
        {
            List<TasksStatus> TasksStatus = (List<TasksStatus>)await _query.GetAll();
            return TasksStatus.Select(TaskStatus => new GenericResponse
            {
                Id = TaskStatus.Id,
                Name = TaskStatus.Name,
            }
            ).ToList();
        }

        Task<List<TasksResponse>> ITaskService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
