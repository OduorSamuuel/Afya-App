using FastEndpoints;

namespace AfyaApp.Features.Patients.Update;

public sealed record UpdatePatientCommand(
    Guid Id,
    string FullName,
    DateTime DateOfBirth,
    string Gender,
    string PhoneNumber) : ICommand<PatientResponse?>;