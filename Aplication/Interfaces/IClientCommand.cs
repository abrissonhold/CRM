using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IClientCommand
    {
        public Task InsertClient(Client client);
    }
}
