using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.Patients.Update;

public sealed class UpdatePatientEndpoint
    : Endpoint<UpdatePatientRequest, Results<Ok<PatientResponse>, NotFound>>
{
    public override void Configure()
    {
        Put(UpdatePatientRequest.Route);
        Roles("Receptionist", "Admin");
    }

    public override async Task<Results<Ok<PatientResponse>, NotFound>> ExecuteAsync(
        UpdatePatientRequest request, CancellationToken ct)
    {
        var command = new UpdatePatientCommand(
            request.Id, request.FullName, request.DateOfBirth, request.Gender, request.PhoneNumber);

        var response = await command.ExecuteAsync(ct);

        return response is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(response);
    }
}