﻿using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly AppDbContext _context;

        public ClientCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

    }
}
