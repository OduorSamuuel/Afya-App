using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.Patients.GetById;

public sealed class GetPatientByIdEndpoint
    : Endpoint<GetPatientByIdRequest, Results<Ok<PatientResponse>, NotFound>>
{
    public override void Configure()
    {
        Get(GetPatientByIdRequest.Route);
        Roles("Receptionist", "Admin", "Doctor");
    }

    public override async Task<Results<Ok<PatientResponse>, NotFound>> ExecuteAsync(
        GetPatientByIdRequest request, CancellationToken ct)
    {
        var command = new GetPatientByIdCommand(request.Id);
        var response = await command.ExecuteAsync(ct);

        return response is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(response);
    }
}