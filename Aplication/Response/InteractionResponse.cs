using Domain.Entities;

namespace Aplication.Response
{
    public class InteractionResponse
    {
        public Guid InteractionID { get; set; }

        public Guid ProjectID { get; set; }
        public ProjectResponse Project { get; set; }

        public int InteractionTypeID { get; set; }
        public GenericResponse InteractionType { get; set; }

        public DateTime Date { get; set; }
        public int Notes { get; set; }
    }
}