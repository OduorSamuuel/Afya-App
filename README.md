# AfyaApp

A simplified hospital management system built to demonstrate core healthcare workflow design ; patient intake, doctor consultation, and record-keeping.

## What it does

AfyaApp lets hospital staff manage patients through two authenticated roles:

- **Receptionist** — registers new patients and manages the front-desk queue
- **Doctor** — views assigned patients, opens their records, and updates diagnosis, prescriptions, and notes

Patients themselves are not system users. They exist as records created by the Receptionist and maintained by the Doctor.

## Architecture

![System architecture](https://oduorsamuuel.github.io/storage/afya-app/architecture.png "AfyaApp actor flow")

Login splits into two role-based paths. The Doctor path handles clinical review and updates; the Receptionist path handles intake and queueing. Both converge on a shared `PatientRecord` entity, which is the single source of truth for patient data across the system.




## Tech stack

- Backend: C# / .NET



