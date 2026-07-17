using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.Patients.Delete;

public sealed class DeletePatientHandler(IRepository<Patient> repository)
    : ICommandHandler<DeletePatientCommand, bool>
{
    public async Task<bool> ExecuteAsync(DeletePatientCommand command, CancellationToken ct)
    {
        var patient = await repository.GetByIdAsync(command.Id, ct);
        if (patient is null) return false;

        await repository.DeleteAsync(patient, ct);
        return true;
    }
}