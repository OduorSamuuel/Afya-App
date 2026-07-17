using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.Update;

public sealed class UpdateQueueEntryEndpoint
    : Endpoint<UpdateQueueEntryRequest, Results<Ok<QueueEntryResponse>, NotFound>>
{
    public override void Configure()
    {
        Put(UpdateQueueEntryRequest.Route);
        Roles("Receptionist", "Doctor", "Admin");
    }

    public override async Task<Results<Ok<QueueEntryResponse>, NotFound>> ExecuteAsync(
        UpdateQueueEntryRequest request, CancellationToken ct)
    {
        var command = new UpdateQueueEntryCommand(request.Id, request.Status, request.AssignedDoctorId);
        var response = await command.ExecuteAsync(ct);

        return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
    }
}