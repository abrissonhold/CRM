using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class TaskService : ITaskService
    {
        private readonly ITaskQuery _query;

        public TaskService(ITaskQuery query)
        {
            _query = query;
        }

        public async Task<List<TasksResponse>> GetAll()
        {
            List<Tasks> list = (List<Tasks>)await _query.GetAll();
            return list.Select(t => new TasksResponse
            {
                TaskID = t.TaskID,
                Name = t.Name,
                DueDate = t.DueDate,
                ProjectID = t.ProjectID,
                User = t.User != null ? new UserResponse
                {
                    UserID = t.User.UserID,
                    Name = t.User.Name,
                    Email = t.User.Email
                } : null,
                TasksStatus =
                {
                    Id = t.TasksStatus.Id,
                    Name = t.TasksStatus.Name
                }
            }).ToList();
        }

        public async Task<TasksRequest> UpdateTask(TasksRequest tasksRequest)
        {
            Tasks task = await _query.Tasks.FirstOrDefaultAsync(t => t.TaskID == tasksRequest.TaskID);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            // Actualizamos los campos de la tarea
            task.Name = tasksRequest.Name;
            task.DueDate = tasksRequest.DueDate;
            task.AssignedTo = tasksRequest.AssignedTo;
            task.Status = tasksRequest.Status;

            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();
        }
    }

}

