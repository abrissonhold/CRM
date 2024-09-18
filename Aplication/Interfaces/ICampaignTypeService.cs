using Aplication.Response;

namespace Aplication.Interfaces
{
    public interface ICampaignTypeService
    {
        Task<List<GenericResponse>> GetAll();
    }
}
