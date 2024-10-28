using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Aplication.UserCase
{
    public class ApiError : ModelStateDictionary
    {
        public required string Message { get; set; }
    }
}
