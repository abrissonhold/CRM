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

        public Task<TasksRequest> CreateTask(TasksRequest task)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TasksResponse>> GetAll()
            {
                List<Tasks> list = (List<Tasks>)await _query.GetAll();
                return list.Select(list => new TasksResponse
                {
                    TaskID = list.TaskID,
                    Name = list.Name,
                    DueDate = list.DueDate,
                    ProjectID = list.ProjectID,
                    User = {
                    UserID = list.User.UserID,
                    Name = list.User.Name,
                    Email = list.User.Email
                },
                    TasksStatus = {
                    Id = list.TasksStatus.Id,
                    Name = list.TasksStatus.Name
                }
                }).ToList();
            }

        }

    }

