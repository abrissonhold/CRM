using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ITaskStatusService
    {
        Task<IEnumerable<GenericResponse>> GetAll();
    }
}
