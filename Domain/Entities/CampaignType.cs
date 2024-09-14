using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CampaignType
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public ICollection<Project> Projects { get; set; }  
    }
}
