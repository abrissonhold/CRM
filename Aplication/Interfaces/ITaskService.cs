using Aplication.Request;
using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TasksResponse>> GetAll();
        public Task<TasksRequest> CreateTask(TasksRequest tasksRequest);
    }
}
