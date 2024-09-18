using Domain.Entities;

namespace Aplication.Response
{
    public class TasksResponse
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }

        public Guid ProjectID { get; set; }
        public ProjectResponse Project { get; set; }

        public int AssignedTo { get; set; }
        public UserResponse User { get; set; }

        public int Status { get; set; }
        public GenericResponse TasksStatus { get; set; }
    }
}