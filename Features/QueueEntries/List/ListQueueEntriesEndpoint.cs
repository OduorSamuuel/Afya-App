using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.List;

public sealed class ListQueueEntriesEndpoint : EndpointWithoutRequest<Ok<List<QueueEntryResponse>>>
{
    public override void Configure()
    {
        Get("/queue-entries");
        Roles("Receptionist", "Doctor", "Admin");
    }

    public override async Task<Ok<List<QueueEntryResponse>>> ExecuteAsync(CancellationToken ct)
    {
        var response = await new ListQueueEntriesCommand().ExecuteAsync(ct);
        return TypedResults.Ok(response);
    }
}