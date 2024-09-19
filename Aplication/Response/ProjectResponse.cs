using Domain.Entities;

namespace Aplication.Response
{
    public class ProjectResponse
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CampaignTypeID { get; set; }
        public GenericResponse CampaignType { get; set; }

        public int ClientID { get; set; }
        public ClientResponse Client { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ProyectResponseDetail
    {
        public ProjectResponse Proyect {  get; set; }
        public List<TasksResponse> Tasks { get; set; }
        public List<InteractionResponse> Interactions { get; set; }
    } 
}