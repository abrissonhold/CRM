using Aplication.Response;

namespace Aplication.Request
{
    public class ProjectRequest
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }

        public int CampaignTypeID { get; set; }
        public GenericResponse? CampaignType { get; set; }

        public int ClientID { get; set; }
        public ClientResponse? Client { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ProjectRequestDetail
    {
        public ProjectResponse Project { get; set; }
        public List<TasksResponse> Tasks { get; set; }
        public List<InteractionResponse> Interactions { get; set; }
    }
}