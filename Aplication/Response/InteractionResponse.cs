
namespace Aplication.Response
{
    public class InteractionResponse
    {
        public Guid InteractionID { get; set; }
        public Guid ProjectID { get; set; }
        public int InteractionTypeID { get; set; }
        public GenericResponse? Interaction { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}