using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.QueueEntries.Create;

public sealed class CreateQueueEntryEndpoint
    : Endpoint<CreateQueueEntryRequest, Ok<QueueEntryResponse>>
{
    public override void Configure()
    {
        Post(CreateQueueEntryRequest.Route);
        Roles("Receptionist", "Admin");
    }

    public override async Task<Ok<QueueEntryResponse>> ExecuteAsync(
        CreateQueueEntryRequest request, CancellationToken ct)
    {
        var command = new CreateQueueEntryCommand(request.PatientId, request.AssignedDoctorId);
        var response = await command.ExecuteAsync(ct);
        return TypedResults.Ok(response);
    }
}