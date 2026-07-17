using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Delete;

public sealed class DeleteMedicalRecordHandler(IRepository<MedicalRecord> repository)
    : ICommandHandler<DeleteMedicalRecordCommand, bool>
{
    public async Task<bool> ExecuteAsync(DeleteMedicalRecordCommand command, CancellationToken ct)
    {
        var record = await repository.GetByIdAsync(command.Id, ct);
        if (record is null) return false;

        await repository.DeleteAsync(record, ct);
        return true;
    }
}