using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CampaignTypeID {  get; set; }
        public CampaignType CampaignType { get; set; }
        
        public int ClientID { get; set; }
        public Client Client { get; set; }        
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
        

    }
}
