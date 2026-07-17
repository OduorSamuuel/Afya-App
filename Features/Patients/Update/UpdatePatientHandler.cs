using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.Patients.Update;

public sealed class UpdatePatientHandler(IRepository<Patient> repository)
    : ICommandHandler<UpdatePatientCommand, PatientResponse?>
{
    public async Task<PatientResponse?> ExecuteAsync(UpdatePatientCommand command, CancellationToken ct)
    {
        var patient = await repository.GetByIdAsync(command.Id, ct);
        if (patient is null) return null;

        patient.UpdateDetails(command.FullName, command.DateOfBirth, command.Gender, command.PhoneNumber);
        await repository.UpdateAsync(patient, ct);

        return new PatientResponse(patient.Id, patient.FullName, patient.DateOfBirth, patient.Gender, patient.PhoneNumber);
    }
}