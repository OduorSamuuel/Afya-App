using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.MedicalRecords.Update;

public sealed class UpdateMedicalRecordEndpoint
    : Endpoint<UpdateMedicalRecordRequest, Results<Ok<MedicalRecordResponse>, NotFound>>
{
    public override void Configure()
    {
        Put(UpdateMedicalRecordRequest.Route);
        Roles("Doctor");
    }

    public override async Task<Results<Ok<MedicalRecordResponse>, NotFound>> ExecuteAsync(
        UpdateMedicalRecordRequest request, CancellationToken ct)
    {
        var command = new UpdateMedicalRecordCommand(
            request.Id, request.VisitDate, request.Diagnosis, request.Prescription, request.Notes);

        var response = await command.ExecuteAsync(ct);
        return response is null ? TypedResults.NotFound() : TypedResults.Ok(response);
    }
}