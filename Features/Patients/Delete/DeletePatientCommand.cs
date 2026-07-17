using FastEndpoints;

namespace AfyaApp.Features.Patients.Delete;

public sealed record DeletePatientCommand(Guid Id) : ICommand<bool>;