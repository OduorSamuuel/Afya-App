using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace AfyaApp.Features.MedicalRecords.Create;

public sealed class CreateMedicalRecordEndpoint
    : Endpoint<CreateMedicalRecordRequest, Results<Ok<MedicalRecordResponse>, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post(CreateMedicalRecordRequest.Route);
        Roles("Doctor");
    }

    public override async Task<Results<Ok<MedicalRecordResponse>, ProblemHttpResult>> ExecuteAsync(
        CreateMedicalRecordRequest request, CancellationToken ct)
    {
        var doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (doctorId is null)
        {
            return TypedResults.Problem("No user id claim found.", statusCode: 401);
        }

        var command = new CreateMedicalRecordCommand(
            request.PatientId, doctorId, request.VisitDate,
            request.Diagnosis, request.Prescription, request.Notes);

        var response = await command.ExecuteAsync(ct);
        return TypedResults.Ok(response);
    }
}