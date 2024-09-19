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
        public string Notes { get; set; }
    }
}
