using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IUserQuery
    {
        Task<IEnumerable<User>> GetAll();
    }
}
