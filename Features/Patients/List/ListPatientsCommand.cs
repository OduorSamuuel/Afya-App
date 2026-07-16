using FastEndpoints;

namespace AfyaApp.Features.Patients.List;

public sealed record ListPatientsCommand : ICommand<List<PatientResponse>>;