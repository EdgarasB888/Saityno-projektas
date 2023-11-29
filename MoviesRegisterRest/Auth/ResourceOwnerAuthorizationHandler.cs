using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MoviesRegisterRest.Auth.Model;

namespace MoviesRegisterRest.Auth;

public class ResourceOwnerAuthorizationHandler : AuthorizationHandler<ResourceOwnerRequirement, IUserOwnedResource>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOwnerRequirement requirement, IUserOwnedResource resource)
    {
        if (context.User.IsInRole(MoviesWebRoles.Admin) || context.User.FindFirstValue(JwtRegisteredClaimNames.Sub) == resource.UserId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public record ResourceOwnerRequirement : IAuthorizationRequirement;

