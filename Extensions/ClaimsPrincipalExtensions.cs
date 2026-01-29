using System.Security.Claims;

namespace AtomsBackend.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User ID claim missing");

            return int.Parse(userId);
        }
    }
}
