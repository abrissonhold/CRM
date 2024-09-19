using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ITaskStatusService
    {
        Task<List<GenericResponse>> GetAll();
    }
}
