using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAll();
    }
}
