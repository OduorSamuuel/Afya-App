using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.Patients.Create
{
    public sealed class CreatePatientHandler(IRepository<Patient> repository)
        : ICommandHandler<CreatePatientCommand,PatientResponse>
    {
        public async Task<PatientResponse> ExecuteAsync(
            CreatePatientCommand command,
            CancellationToken cancellationToken)
        {
            var patient = new Patient(
             command.FullName,
             command.DateOfBirth,
             command.Gender,
             command.PhoneNumber,
             command.RegisteredById
         );

            patient = await repository.AddAsync(patient, cancellationToken);
            return new PatientResponse(
           patient.Id,
           patient.FullName,
           patient.DateOfBirth,
           patient.Gender,
           patient.PhoneNumber
       );
        }

    }
}