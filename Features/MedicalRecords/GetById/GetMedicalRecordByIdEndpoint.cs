using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.MedicalRecords.GetById;

public sealed class GetMedicalRecordByIdEndpoint
    : Endpoint<GetMedicalRecordByIdRequest, Results<Ok<MedicalRecordResponse>, NotFound>>
{
    public override void Configure()
    {
        Get(GetMedicalRecordByIdRequest.Route);
        Roles("Doctor", "Admin");
    }

    public override async Task<Results<Ok<MedicalRecordResponse>, NotFound>> ExecuteAsync(
        GetMedicalRecordByIdRequest request, CancellationToken ct)
    {
        var command = new GetMedicalRecordByIdCommand(request.Id);
        var response = await command.ExecuteAsync(ct);

        return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
    }
}