using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SpaWithAuth.Models;
using System.Security.Claims;

namespace SpaWithAuth.Factories;

public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
{
    public ApplicationUserClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager, 
        IOptions<IdentityOptions> optionsAccessor) 
        : base(userManager, optionsAccessor) { }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim(nameof(ApplicationUser.FullName), user.FullName));
        return identity;
    }
}
