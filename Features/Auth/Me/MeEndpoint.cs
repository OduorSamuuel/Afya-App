using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace AfyaApp.Features.Auth.Me;

public sealed record MeResponse(string? Email, List<string> Roles);

public sealed class MeEndpoint : EndpointWithoutRequest<Ok<MeResponse>>
{
    public override void Configure()
    {
        Get("/me");
       
    }

    public override async Task<Ok<MeResponse>> ExecuteAsync(CancellationToken ct)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value
                    ?? User.FindFirst("email")?.Value;

        var roles = User.FindAll(ClaimTypes.Role)
                        .Select(c => c.Value)
                        .ToList();

        return TypedResults.Ok(new MeResponse(email, roles));
    }
}