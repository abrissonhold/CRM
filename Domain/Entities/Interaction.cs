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
        public Guid InteractionId { get; set; }

        public Guid ProyectId { get; set; }
        public Project Project { get; set; }

        public int InteractionTypeId { get; set; }
        public InteractionType InteractionType { get; set; }        
        
        public DateTime Date { get; set; }
        public int Notes { get; set; }
    }
}
