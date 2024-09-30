namespace Aplication.Response
{
    public class TasksResponse
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public UserResponse? User { get; set; }
        public GenericResponse? TasksStatus { get; set; }
    }
}