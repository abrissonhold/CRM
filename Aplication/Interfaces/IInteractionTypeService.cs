using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IInteractionTypeService
    {
        Task<List<GenericResponse>> GetAll();

    }
}
