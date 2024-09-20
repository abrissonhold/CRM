using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserQuery
    {
        Task<IEnumerable<User>> GetAll();
        public Task<User> GetById(int id);
    }
}
