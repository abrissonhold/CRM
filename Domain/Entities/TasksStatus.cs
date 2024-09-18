namespace Domain.Entities
{
    public class TasksStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
