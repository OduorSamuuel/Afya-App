using Ardalis.SharedKernel;

namespace AfyaApp.Domain
{
    public class Patient:IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;

        public int RegisteredById { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
