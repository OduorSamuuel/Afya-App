using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.Patients.Delete;

public sealed class DeletePatientEndpoint
    : Endpoint<DeletePatientRequest, Results<NoContent, NotFound>>
{
    public override void Configure()
    {
        Delete(DeletePatientRequest.Route);
        Roles("Admin"); // Admin only
    }

    public override async Task<Results<NoContent, NotFound>> ExecuteAsync(
        DeletePatientRequest request, CancellationToken ct)
    {
        var command = new DeletePatientCommand(request.Id);
        var deleted = await command.ExecuteAsync(ct);

        return deleted ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}