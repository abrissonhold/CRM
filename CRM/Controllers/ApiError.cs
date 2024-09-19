using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRM.Controllers
{
    class ApiError : ModelStateDictionary
    {
        public string Message { get; set; }
    }
}
