using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IClientQuery
    {
        public Task<IEnumerable<Client>> GetAll();
        public Task<Client> GetById(int id);
    }
}
