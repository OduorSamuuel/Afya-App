

using FastEndpoints;

namespace AfyaApp.Features.Patients.Create
{
    public sealed record CreatePatientCommand
   ( string FullName,
        DateTime DateOfBirth,
        string Gender,
        string PhoneNumber,
        string RegisteredById)
        : ICommand<PatientResponse>

    {
    }
}
