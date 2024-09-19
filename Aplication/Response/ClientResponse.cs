using Domain.Entities;

namespace Aplication.Response
{
    public class ClientResponse
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
    }
}