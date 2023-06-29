using System.Security.Claims;

namespace simple_dotnet_core_7_crud.Common.HttpProfile
{
    public class HttpProfile : IHttpProfile
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpProfile(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
                .FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}