using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.Delete;

public sealed class DeleteQueueEntryEndpoint
    : Endpoint<DeleteQueueEntryRequest, Results<NoContent, NotFound>>
{
    public override void Configure()
    {
        Delete(DeleteQueueEntryRequest.Route);
        Roles("Admin");
    }

    public override async Task<Results<NoContent, NotFound>> ExecuteAsync(
        DeleteQueueEntryRequest request, CancellationToken ct)
    {
        var command = new DeleteQueueEntryCommand(request.Id);
        var deleted = await command.ExecuteAsync(ct);

        return deleted ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}