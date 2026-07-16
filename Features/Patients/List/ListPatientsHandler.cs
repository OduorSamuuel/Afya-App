using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.Patients.List;

public sealed class ListPatientsHandler(IReadRepository<Patient> repository)
    : ICommandHandler<ListPatientsCommand, List<PatientResponse>>
{
    public async Task<List<PatientResponse>> ExecuteAsync(ListPatientsCommand command, CancellationToken ct)
    {
        var patients = await repository.ListAsync(ct);

        return patients
            .Select(p => new PatientResponse(p.Id, p.FullName, p.DateOfBirth, p.Gender, p.PhoneNumber))
            .ToList();
    }
}