using Ardalis.SharedKernel;

namespace AfyaApp.Domain
{
    public class QueueEntry(
        Guid patientId,
        string assignedDoctorId) : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; } = patientId;
        public string AssignedDoctorId { get; private set; } = assignedDoctorId;
        public QueueStatus Status { get; private set; } = QueueStatus.Waiting;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        private QueueEntry() : this(Guid.Empty, string.Empty) { }

        public void UpdateStatus(QueueStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Reassign(string newDoctorId)
        {
            AssignedDoctorId = newDoctorId;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}