using Microsoft.Identity.Web;
using System;
using System.Security.Claims;

namespace GenericComputationPlatform.Extensions;

public static class PrincipalExtensions
{
    public static string GetEmail(this ClaimsPrincipal principal)
    {
        string email = principal.FindFirst(ClaimTypes.Email)?.Value;
        if (!string.IsNullOrWhiteSpace(email))
            return email;

        email = principal.FindFirst(ClaimConstants.PreferredUserName)?.Value;
        return email;
    }

    public static string GetUserId(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimConstants.PreferredUserName)?.Value;
    }

    public static string GetName(this ClaimsPrincipal principal)
    {
        string givenName = principal.FindFirst(ClaimTypes.GivenName)?.Value;
        string surName = principal.FindFirst(ClaimTypes.Surname)?.Value;
        if (!string.IsNullOrWhiteSpace(givenName) || !string.IsNullOrWhiteSpace(surName))
            return $"{givenName} {surName}".Trim();

        string name = principal.FindFirst(ClaimTypes.Name)?.Value;
        if (!string.IsNullOrWhiteSpace(name))
            return name;

        name = principal.FindFirst(ClaimConstants.Name)?.Value;
        if (!string.IsNullOrWhiteSpace(name))
            return name;

        return principal.FindFirst(ClaimConstants.PreferredUserName)?.Value;
    }

    public static string GetFirstName(this ClaimsPrincipal principal)
    {
        string name = GetName(principal);
        string[] f = name.Split(',', StringSplitOptions.RemoveEmptyEntries);
        if (f.Length > 1)
            return f[1].Trim();
        f = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (f.Length > 1)
            return f[0];
        f = name.Split('@', StringSplitOptions.RemoveEmptyEntries);
        if (f.Length > 1)
            return f[0];
        return name;
    }
}
