using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.UpdateStatus;

public sealed class UpdateQueueEntryStatusEndpoint
    : Endpoint<UpdateQueueEntryStatusRequest, Results<Ok<QueueEntryResponse>, NotFound>>
{
    public override void Configure()
    {
        Put(UpdateQueueEntryStatusRequest.Route);
        Roles("Doctor", "Admin");
    }

    public override async Task<Results<Ok<QueueEntryResponse>, NotFound>> ExecuteAsync(
        UpdateQueueEntryStatusRequest request, CancellationToken ct)
    {
        var command = new UpdateQueueEntryStatusCommand(request.Id, request.Status);
        var response = await command.ExecuteAsync(ct);

        return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
    }
}