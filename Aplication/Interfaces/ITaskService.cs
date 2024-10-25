using Aplication.Request;
using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ITaskService
    {
        public Task<IEnumerable<TasksResponse>> GetAll();

        public Task<TasksResponse> UpdateTask(Guid Id, TasksRequest tasksRequest);


    }
}
