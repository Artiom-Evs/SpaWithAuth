using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using System.Security.Claims;

namespace SpaWithAuth.Services;

public class ProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        context.IssuedClaims.AddRange(context.Subject.FindAll(JwtClaimTypes.Name));
        context.IssuedClaims.AddRange(context.Subject.FindAll(JwtClaimTypes.Role));
        context.IssuedClaims.AddRange(context.Subject.FindAll(ClaimTypes.Role));
        context.IssuedClaims.AddRange(context.Subject.FindAll("FullName"));
        
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
