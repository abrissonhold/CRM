namespace Domain.Entities
{
    public class Tasks
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }

        public Guid ProjectID { get; set; }
        public Project Project { get; set; }

        public int AssignedTo { get; set; }
        public User? User { get; set; }

        public int Status { get; set; }
        public TaskStatus? TasksStatus { get; set; }
    }
}
