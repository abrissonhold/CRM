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


        public ProjectService(IProjectQuery query, IProjectCommand command, ICampaignTypeQuery querycampaigntype, IClientQuery queryclient)
        {
            _query = query;
            _command = command;
            _querycampaigntype = querycampaigntype;
            _queryclient = queryclient;
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

        public Task<ProjectResponseDetail> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddInteraction(Guid projectId, Interaction interaction)
        {
            throw new NotImplementedException();
        }

        public Task AddTask(Guid projectId, Task task)
        {
            throw new NotImplementedException();
        }
    }
}
       
