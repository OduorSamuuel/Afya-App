using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace AfyaApp.Features.Patients.Create;

public sealed class CreatePatientEndpoint
    : Endpoint<CreatePatientRequest, Results<Ok<PatientResponse>, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post(CreatePatientRequest.Route);
        Roles("Receptionist", "Admin");
    }

    public override async Task<Results<Ok<PatientResponse>, ProblemHttpResult>> ExecuteAsync(
        CreatePatientRequest request,
        CancellationToken ct)
    {
        var registeredById = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (registeredById is null)
        {
            return TypedResults.Problem("No user id claim found.", statusCode: 401);
        }

        var command = new CreatePatientCommand(
            request.FullName,
            request.DateOfBirth,
            request.Gender,
            request.PhoneNumber,
            registeredById);

        var response = await command.ExecuteAsync(ct);

        return TypedResults.Ok(response);
    }
}