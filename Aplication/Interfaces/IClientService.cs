using Aplication.Request;
using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientResponse>> GetAll();
        public Task<ClientResponse> CreateClient(ClientRequest client);
    }
}
