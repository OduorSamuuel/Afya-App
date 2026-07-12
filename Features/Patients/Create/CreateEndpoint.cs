using FastEndpoints;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.Patients.Create;

public sealed class CreatePatientEndpoint(IMediator mediator)
    : Endpoint<CreatePatientRequest,Results<Ok <PatientResponse>,NotFound
        ,ValidationProblem,ProblemHttpResult>>
{
    public override void Configure()
    {
        Post(CreatePatientRequest.Route);
        AllowAnonymous();
    }

    public override async Task<
    Results<
        Ok<PatientResponse>,
        NotFound,
        ValidationProblem,
        ProblemHttpResult>>
ExecuteAsync(
    CreatePatientRequest request,
    CancellationToken ct)
    {
        var command = new CreatePatientCommand(
            request.FullName,
            request.DateOfBirth,
            request.Gender,
            request.PhoneNumber);

        var response = await mediator.Send(command, ct);

        return TypedResults.Ok(response);
    }
}