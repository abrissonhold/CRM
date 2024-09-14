using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interaction
    {
        public Guid InteractionID { get; set; }

        public Guid ProjectID { get; set; }
        public Project Project { get; set; }

        public int InteractionTypeID { get; set; }
        public InteractionType InteractionType { get; set; }        
        
        public DateTime Date { get; set; }
        public int Notes { get; set; }
    }
}
