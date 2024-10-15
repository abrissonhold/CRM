using Aplication.Request;
using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IClientService
    {
        public Task<List<ClientResponse>> GetAll();
        public Task<ClientResponse> CreateClient(ClientRequest client);
    }
}
