using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.Patients.GetById;

public sealed class GetPatientByIdHandler(IReadRepository<Patient> repository)
    : ICommandHandler<GetPatientByIdCommand, PatientResponse?>
{
    public async Task<PatientResponse?> ExecuteAsync(GetPatientByIdCommand command, CancellationToken ct)
    {
        var patient = await repository.GetByIdAsync(command.Id, ct);

        return patient is null
            ? null
            : new PatientResponse(patient.Id, patient.FullName, patient.DateOfBirth, patient.Gender, patient.PhoneNumber);
    }
}