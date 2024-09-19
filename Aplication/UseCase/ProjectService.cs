using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

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

        public ProjectService(IProjectQuery query, IProjectCommand command, ICampaignTypeQuery querycampaigntype, IClientQuery queryclient, IInteractionQuery queryinteraction, ITaskQuery querytask)
        {
            _query = query;
            _command = command;
            _querycampaigntype = querycampaigntype;
            _queryclient = queryclient;
            _querytask = querytask;
            _queryinteraction = queryinteraction;
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

        public async Task<IEnumerable<ProjectResponse>> GetProjects(string name, int? campaignType, int? clientId, int offset, int size)
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
                tasks = p.Tasks.Select(t => new TasksResponse
                {
                    TaskID = t.TaskID,
                    Name = t.Name,
                    DueDate = t.DueDate,
                    ProjectID = t.ProjectID,
                    User = {
                        UserID = t.User.UserID,
                        Name = t.User.Name,
                        Email = t.User.Email
                    },
                    TasksStatus = {
                        Id = t.User.UserID,
                        Name = t.User.Name
                    },
                }).ToList(),
                interactions = p.Interactions.Select(t => new InteractionResponse
                {
                    InteractionID = t.InteractionID,
                    ProjectID = t.ProjectID,
                    Date = t.Date,
                    Notes = t.Notes,
                }
                ).ToList()
            };
        }

        public async Task<InteractionResponse> AddInteraction(Guid projectId, InteractionRequest interaction)
        {
            var p = await _query.GetById(projectId);
            
            Domain.Entities.Interaction i = new Domain.Entities.Interaction
            {
                //InteractionID = interaction.InteractionID,
                ProjectID = projectId,
                Date = interaction.Date,
                Notes = interaction.Notes,
                InteractionTypeID = interaction.InteractionTypeID
            };

            await _command.InsertInteraction(p, i);

      
            return new InteractionResponse
            {
                InteractionID = i.InteractionID,
                ProjectID = i.ProjectID,
                Interaction = new GenericResponse{
                    Id = i.InteractionType.Id,
                    Name = i.InteractionType.Name
                },
                Date = i.Date,
                Notes = i.Notes,
            };
        }

        public async Task<TasksResponse> AddTask(Guid projectId, TasksRequest task)
        {
            var p = await _query.GetById(projectId);

            Tasks t = new Tasks
            {
                TaskID = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectID = task.ProjectID,
                AssignedTo = task.AssignedTo,
                Status = task.Status
            };

            await _command.InsertTask(p, t);
            return new TasksResponse
            {
                TaskID = t.TaskID,
                Name = t.Name,
                DueDate = t.DueDate,
                ProjectID = t.ProjectID,
                User = 
                {
                        UserID = t.User.UserID,
                        Name = t.User.Name,
                        Email = t.User.Email
                },
                TasksStatus = 
                {
                        Id = t.User.UserID,
                        Name = t.User.Name
                },
            };
        }

    }
}
       
