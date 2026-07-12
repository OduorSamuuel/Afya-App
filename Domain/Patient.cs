using Ardalis.SharedKernel;

namespace AfyaApp.Domain
{
    public class Patient(
        string fullName,
        DateTime dateOfBirth,
        string gender,
        string phoneNumber,
        string registeredById) : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = fullName;
        public DateTime DateOfBirth { get; private set; } = dateOfBirth;
        public string Gender { get; private set; } = gender;
        public string PhoneNumber { get; private set; } = phoneNumber;
        public string RegisteredById { get; private set; } = registeredById;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private Patient() : this(string.Empty, default, string.Empty, string.Empty, string.Empty) { }
    }
}