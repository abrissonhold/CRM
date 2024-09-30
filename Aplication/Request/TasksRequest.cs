namespace Aplication.Request
{
    public class TasksRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedTo { get; set; }
        public int Status { get; set; }
    }
}