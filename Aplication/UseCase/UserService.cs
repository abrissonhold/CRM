using Aplication.Interfaces;
using Aplication.Response;
using Domain.Entities;

namespace Aplication.UseCase
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _query;

        public UserService(IUserQuery query)
        {
            _query = query;
        }

        public async Task<List<UserResponse>> GetAll()
        {
            List<User> users = (List<User>)await _query.GetAll();
            return users.Select(user => new UserResponse
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
            }
            ).ToList();
        }
    }
}
