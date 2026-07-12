namespace AfyaApp.Features.Patients
{
    public sealed record PatientResponse(
      Guid Id,
      string FullName,
      DateTime DateOfBirth,
      string Gender,
      string PhoneNumber);
}
