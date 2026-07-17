using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.MedicalRecords.Delete;

public sealed class DeleteMedicalRecordEndpoint
    : Endpoint<DeleteMedicalRecordRequest, Results<NoContent, NotFound>>
{
    public override void Configure()
    {
        Delete(DeleteMedicalRecordRequest.Route);
        Roles("Admin");
    }

    public override async Task<Results<NoContent, NotFound>> ExecuteAsync(
        DeleteMedicalRecordRequest request, CancellationToken ct)
    {
        var command = new DeleteMedicalRecordCommand(request.Id);
        var deleted = await command.ExecuteAsync(ct);

        return deleted ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}