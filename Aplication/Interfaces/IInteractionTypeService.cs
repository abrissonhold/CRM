using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface IInteractionTypeService
    {
        Task<IEnumerable<GenericResponse>> GetAll();

    }
}
