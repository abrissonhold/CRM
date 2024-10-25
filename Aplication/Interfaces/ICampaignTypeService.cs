using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ICampaignTypeService
    {
        Task<IEnumerable<GenericResponse>> GetAll();
    }
}
