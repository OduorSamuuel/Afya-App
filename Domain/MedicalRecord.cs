using Ardalis.SharedKernel;

namespace AfyaApp.Domain
{
    public class MedicalRecord(
        Guid patientId,
        string doctorId,
        DateTime visitDate,
        string diagnosis,
        string prescription,
        string notes) : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; } = patientId;
        public string DoctorId { get; private set; } = doctorId;
        public DateTime VisitDate { get; private set; } = visitDate;
        public string Diagnosis { get; private set; } = diagnosis;
        public string Prescription { get; private set; } = prescription;
        public string Notes { get; private set; } = notes;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private Patient? Patient { get; set; } // navigation property

        private MedicalRecord()
            : this(Guid.Empty, string.Empty, default, string.Empty, string.Empty, string.Empty) { }
        public void UpdateDetails(DateTime visitDate, string diagnosis, string prescription, string notes)
        {
            VisitDate = visitDate;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Notes = notes;
        }
    }

}