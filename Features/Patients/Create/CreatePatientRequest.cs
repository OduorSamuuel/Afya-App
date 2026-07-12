namespace AfyaApp.Features.Patients.Create
{
    public class CreatePatientRequest
    {
        public const string Route = "/patient";
        public string FullName { get; init; } = string.Empty;
        public DateTime DateOfBirth { get; init; }
        public string Gender { get; init; }= string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
    }
}
