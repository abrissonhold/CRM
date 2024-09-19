using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class ClientService : IClientService
    {
        private readonly IClientQuery _query;

        public ClientService(IClientQuery query)
        {
            _query = query;
        }

        public async Task<List<ClientResponse>> GetAll()
        {
            List<Client> clients = (List<Client>)await _query.GetAll();
            return clients.Select(c => new ClientResponse
            {
                ClientID = c.ClientID,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Company = c.Company,
                Address = c.Address
            }
            ).ToList();
        }
    }
}
