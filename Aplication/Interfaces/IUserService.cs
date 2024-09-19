using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAll();
    }
}
