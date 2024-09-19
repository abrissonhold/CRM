
namespace Aplication.Response
{
    public class InteractionResponse
    {
        public Guid InteractionID { get; set; }
        public Guid ProyectID { get; set; }
        public int InteractionTypeID { get; set; }
        public DateTime Date { get; set; }
        public int Notes { get; set; }
    }
}