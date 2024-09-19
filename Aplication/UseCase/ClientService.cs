using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplication.UseCase
{
    public class ClientService : IClientService
    {
        private readonly IClientQuery _query;
        private readonly IClientCommand _command;

        public ClientService(IClientQuery query, IClientCommand command)
        {
            _query = query;
            _command = command;
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
        public async Task<ClientRequest> CreateClient(ClientRequest client)
        {
            Client c = new Client
            {
                ClientID = client.ClientID,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Company = client.Company,
                Address = client.Address
            };
            await _command.InsertClient(c);
            return  client;
        }
    }
}
