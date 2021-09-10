using NMS.RTIS.Core.Abstractions;

namespace NMS.RTIS.Domain.Patient.Events
{

    public class CreatePatientEvent : IDomainEvent
    {
        public Patient Patient { get; private set; }
        public CreatePatientEvent(Patient patient)
        {
            this.Patient = patient;
        }
    }
}
