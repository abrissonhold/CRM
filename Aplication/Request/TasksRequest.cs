using Aplication.Response;

namespace Aplication.Request
{
    public class TasksRequest
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public int AssignedTo { get; set; }
        public int Status { get; set; }
    }
}