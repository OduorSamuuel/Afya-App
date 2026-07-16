using FastEndpoints;

namespace AfyaApp.Features.Patients.GetById
{
    public sealed record GetPatientByIdCommand(Guid Id) : ICommand<PatientResponse?>;
}
