namespace AfyaApp.Features.Patients.GetById
{
    public class GetPatientByIdRequest
    {
        public const string Route = "/patient/{Id}";
        public Guid Id { get; init; }
    }
}
