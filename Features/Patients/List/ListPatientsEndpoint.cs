using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.Patients.List;

public sealed class ListPatientsEndpoint : EndpointWithoutRequest<Ok<List<PatientResponse>>>
{
    public override void Configure()
    {
        Get("/patients");
        Roles("Receptionist", "Admin", "Doctor");
    }

    public override async Task<Ok<List<PatientResponse>>> ExecuteAsync(CancellationToken ct)
    {
        var response = await new ListPatientsCommand().ExecuteAsync(ct);
        return TypedResults.Ok(response);
    }
}