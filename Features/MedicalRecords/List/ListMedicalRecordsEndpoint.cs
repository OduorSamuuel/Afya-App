using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AfyaApp.Features.MedicalRecords.List;

public sealed class ListMedicalRecordsEndpoint
    : Endpoint<ListMedicalRecordsRequest, Ok<List<MedicalRecordResponse>>>
{
    public override void Configure()
    {
        Get(ListMedicalRecordsRequest.Route);
        Roles("Doctor", "Admin", "Receptionist");
    }

    public override async Task<Ok<List<MedicalRecordResponse>>> ExecuteAsync(
        ListMedicalRecordsRequest request, CancellationToken ct)
    {
        var response = await new ListMedicalRecordsCommand(request.PatientId).ExecuteAsync(ct);
        return TypedResults.Ok(response);
    }
}