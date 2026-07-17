using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.GetById;

public sealed class GetQueueEntryByIdEndpoint
    : Endpoint<GetQueueEntryByIdRequest, Results<Ok<QueueEntryResponse>, NotFound>>
{
    public override void Configure()
    {
        Get(GetQueueEntryByIdRequest.Route);
        Roles("Receptionist", "Doctor", "Admin");
    }

    public override async Task<Results<Ok<QueueEntryResponse>, NotFound>> ExecuteAsync(
        GetQueueEntryByIdRequest request, CancellationToken ct)
    {
        var command = new GetQueueEntryByIdCommand(request.Id);
        var response = await command.ExecuteAsync(ct);

        return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
    }
}