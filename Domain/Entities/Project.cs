using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CampaignTypeId {  get; set; }
        public CampaignType CampaignType { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }        
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
        

    }
}
