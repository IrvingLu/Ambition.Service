using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Domain.Patient.Events;

namespace NMS.RTIS.Domain.Patient
{

    public class Patient : Entity, IAggregateRoot
    {
        [Comment("患者姓名")]
        public string Name { get; set; }

        [Comment("联系方式")]
        public string Phone { get; set; }

        [Comment("性别")]
        public int Sex { get; set; }


        public Patient(string name, string phone = null)
        {
            Name = name;
            Phone = phone;
            AddDomainEvent(new CreatePatientEvent(this));//举例
        }
    }
}
