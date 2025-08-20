using System.Security.Claims;

namespace DoTogetherDatabase.Helpers
{
    public static class UserHelper
    {
        public static Guid? GetUserId(ClaimsPrincipal user)
        {
            var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(id, out var guid) ? guid : (Guid?)null;
        }
    }
}