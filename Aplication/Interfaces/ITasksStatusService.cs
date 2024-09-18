using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ITasksStatusService
    {
        Task<List<GenericResponse>> GetAll();
    }
}
