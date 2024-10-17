
namespace Aplication.Response
{
    public class InteractionResponse
    {
        public Guid InteractionID { get; set; }
        public GenericResponse? Interaction { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}