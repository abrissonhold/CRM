using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectQuery _query;
        private readonly IProjectCommand _command;
        private readonly ICampaignTypeQuery _querycampaigntype;
        private readonly IClientQuery _queryclient;
        private readonly IInteractionQuery _queryinteraction;
        private readonly IInteractionTypeQuery _queryinteractiontype;
        private readonly ITaskQuery _querytask;
        private readonly IUserQuery _queryuser;
        private readonly ITasksStatusQuery _querytaskstatus;

        public ProjectService(IProjectQuery query, IProjectCommand command, ICampaignTypeQuery querycampaigntype,
            IClientQuery queryclient, IInteractionQuery queryinteraction, IInteractionTypeQuery queryinteractiontype,
            ITaskQuery querytask, IUserQuery queryuser, ITasksStatusQuery querytaskstatus)
        {
            _query = query;
            _command = command;
            _querycampaigntype = querycampaigntype;
            _queryclient = queryclient;
            _queryinteraction = queryinteraction;
            _queryinteractiontype = queryinteractiontype;
            _querytask = querytask;
            _queryuser = queryuser;
            _querytaskstatus = querytaskstatus;
        }

        public async Task<List<ProjectResponse>> GetAll()
        {
            List<Project> projects = (List<Project>)await _query.GetAll();
            return projects.Select(pr => new ProjectResponse
            {
                ProjectID = pr.ProjectID,
                ProjectName = pr.ProjectName,
                CampaignTypeID = pr.CampaignTypeID,
                ClientID = pr.ClientID,
                StartDate = pr.StartDate,
                EndDate = pr.EndDate,
                CampaignType = new GenericResponse
                {
                    Id = pr.CampaignType.Id,
                    Name = pr.CampaignType.Name
                },
                Client = new ClientResponse
                {
                    ClientID = pr.Client.ClientID,
                    Name = pr.Client.Name,
                    Email = pr.Client.Email,
                    Phone = pr.Client.Phone,
                    Company = pr.Client.Company,
                    Address = pr.Client.Address
                }
            }
            ).ToList();
        }

        public async Task<IEnumerable<ProjectResponse>> GetProjects(string? name, int? campaignType, int? clientId, int offset, int size)
        {
            List<Project> projects = (List<Project>)await _query.GetProjects(name, campaignType, clientId, offset, size);
            return projects.Select(pr => new ProjectResponse
            {
                ProjectID = pr.ProjectID,
                ProjectName = pr.ProjectName,
                CampaignTypeID = pr.CampaignTypeID,
                ClientID = pr.ClientID,
                StartDate = pr.StartDate,
                EndDate = pr.EndDate,
                CampaignType = new GenericResponse
                {
                    Id = pr.CampaignType.Id,
                    Name = pr.CampaignType.Name
                },
                Client = new ClientResponse
                {
                    ClientID = pr.Client.ClientID,
                    Name = pr.Client.Name,
                    Email = pr.Client.Email,
                    Phone = pr.Client.Phone,
                    Company = pr.Client.Company,
                    Address = pr.Client.Address
                }
            }).ToList();
        }

        public async Task<ProjectResponse> CreateProject(ProjectRequest pr) 
        {
            var existingProject = await _query.GetByName(pr.ProjectName);
            if (existingProject != null)
            {
                throw new Exception("Ya existe un proyecto con ese nombre");
            }
            var campaignType = await _querycampaigntype.GetById(pr.CampaignTypeID);
            var client = await _queryclient.GetById(pr.ClientID);

            if (campaignType == null || client == null)
            {
                throw new Exception("Datos mal ingresados");
            }

            Project p = new Project
            {
                ProjectName = pr.ProjectName,
                CampaignTypeID = pr.CampaignTypeID,
                ClientID = pr.ClientID,
                StartDate = pr.StartDate,
                EndDate = pr.EndDate,
            };

            await _command.InsertProject(p);
            return new ProjectResponse
            {
                ProjectID = p.ProjectID,
                ProjectName = p.ProjectName,
                CampaignTypeID = p.CampaignTypeID,
                ClientID = p.ClientID,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Client = new ClientResponse
                {
                    ClientID = client.ClientID,
                    Name = client.Name,
                    Phone = client.Phone,
                    Email = client.Email,
                    Company = client.Company,
                    Address = client.Address,
                },
                CampaignType = new GenericResponse
                {
                    Id = campaignType.Id,
                    Name = campaignType.Name
                }
            };
        }

        public async Task<ProjectResponseDetail> GetById(Guid id)
        {
            var p = await _query.GetById(id);
            return new ProjectResponseDetail
            {
                project = new ProjectResponse
                {
                    ProjectID = p.ProjectID,
                    ProjectName = p.ProjectName,
                    CampaignTypeID = p.CampaignTypeID,
                    ClientID = p.ClientID,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Client = new ClientResponse
                    {
                        ClientID = p.Client.ClientID,
                        Name = p.Client.Name,
                        Email = p.Client.Email,
                        Phone = p.Client.Phone,
                        Company = p.Client.Company,
                        Address = p.Client.Address,
                    },
                    CampaignType = new GenericResponse
                    {
                        Id = p.CampaignType.Id,
                        Name = p.CampaignType.Name
                    },
                },
                tasks = p.Tasks.Select(static t => new TasksResponse
                {
                    TaskID = t.TaskID,
                    Name = t.Name,
                    DueDate = t.DueDate,
                    ProjectID = t.ProjectID,
                    User = new UserResponse
                    { 
                        UserID = t.User.UserID,
                        Name = t.User.Name,
                        Email = t.User.Email
                    },
                    TasksStatus = new GenericResponse
                    {
                        Id = t.TasksStatus.Id,
                        Name = t.TasksStatus.Name
                    },
                }).ToList(),
                interactions = p.Interactions.Select(i => new InteractionResponse
                {
                    InteractionID = i.InteractionID,
                    Interaction = new GenericResponse
                    {
                        Id = i.InteractionType.Id,
                        Name = i.InteractionType.Name
                    },
                    Date = i.Date,
                    Notes = i.Notes,
                }
                ).ToList()
            };
        }

        public async Task<InteractionResponse> AddInteraction(Guid projectId, InteractionRequest interaction)
        {
            var p = await _query.GetById(projectId);
            var it = await _queryinteractiontype.GetById(interaction.InteractionTypeID);

            Interaction i = new Interaction
            {
                ProjectID = projectId,
                Date = interaction.Date,
                Notes = interaction.Notes,
                InteractionTypeID = interaction.InteractionTypeID
            };

            await _command.InsertInteraction(p, i);

            return new InteractionResponse
            {
                InteractionID = i.InteractionID,
                Interaction = new GenericResponse
                {
                    Id = it.Id,
                    Name = it.Name
                },
                Date = i.Date,
                Notes = i.Notes,
            };
        }

        public async Task<TasksResponse> AddTask(Guid projectId, TasksRequest task)
        {
            var p = await _query.GetById(projectId);
            var user = await _queryuser.GetById(task.AssignedTo);
            var ts = await _querytaskstatus.GetById(task.Status);

            Tasks t = new Tasks
            {
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectID = projectId,
                AssignedTo = task.AssignedTo,
                Status = ts.Id,
            };

            await _command.InsertTask(p, t);
            return new TasksResponse
            {
                TaskID = t.TaskID,
                Name = t.Name,
                DueDate = t.DueDate,
                ProjectID = t.ProjectID,
                User = new UserResponse
                {
                    UserID = user.UserID,
                    Name = user.Name,
                    Email = user.Email
                },
                TasksStatus = new GenericResponse
                {
                    Id = ts.Id,
                    Name = ts.Name
                },
            };
        }

        public async Task<ProjectResponseDetail> GetByName(string name)
        {
            var project = await _query.GetByName(name);

            if (project == null)
            {
                return null;
            }
            return new ProjectResponseDetail
            {
                project = new ProjectResponse
                {
                    ProjectID = project.ProjectID,
                    ProjectName = project.ProjectName,
                    CampaignTypeID = project.CampaignTypeID,
                    ClientID = project.ClientID,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Client = new ClientResponse
                    {
                        ClientID = project.Client.ClientID,
                        Name = project.Client.Name,
                        Phone = project.Client.Phone,
                        Company = project.Client.Company,
                        Address = project.Client.Address,
                    },
                    CampaignType = new GenericResponse
                    {
                        Id = project.CampaignType.Id,
                        Name = project.CampaignType.Name
                    }
                },
                tasks = project.Tasks.Select(t => new TasksResponse
                {
                    TaskID = t.TaskID,
                    Name = t.Name,
                    DueDate = t.DueDate,
                    ProjectID = t.ProjectID,
                    User = new UserResponse
                    {
                        UserID = t.User.UserID,
                        Name = t.User.Name,
                        Email = t.User.Email
                    },
                    TasksStatus = new GenericResponse
                    {
                        Id = t.TasksStatus.Id,
                        Name = t.TasksStatus.Name
                    }
                }).ToList(),
                interactions = project.Interactions.Select(i => new InteractionResponse
                {
                    InteractionID = i.InteractionID,
                    Interaction = new GenericResponse
                    {
                        Id = i.InteractionType.Id,
                        Name = i.InteractionType.Name
                    },
                    Date = i.Date,
                    Notes = i.Notes,
                }).ToList()
            };
        }

        public async Task<TasksResponse> UpdateTask(Guid projectId, Guid taskId, TasksRequest taskRequest)
        {
            var p = await _query.GetById(projectId);
            var user = await _queryuser.GetById(taskRequest.AssignedTo);
            var ts = await _querytaskstatus.GetById(taskRequest.Status);

            if (p == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            var task = p.Tasks.FirstOrDefault(t => t.TaskID == taskId);

            if (task == null)
            {
                throw new Exception("Tarea no encontrada");
            }
            if (user == null || ts == null)
            {
                throw new Exception("Datos inválidos para la tarea");
            }

            task.Name = taskRequest.Name;
            task.DueDate = taskRequest.DueDate;
            task.AssignedTo = taskRequest.AssignedTo;
            task.Status = taskRequest.Status;

            await _command.UpdateTask(p, task);

            return new TasksResponse
            {
                TaskID = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectID = task.ProjectID,
                User = new UserResponse
                {
                    UserID = user.UserID,
                    Name = user.Name,
                    Email = user.Email
                },
                TasksStatus = new GenericResponse
                {
                    Id = ts.Id,
                    Name = ts.Name
                }
            };
        }
    }
}

