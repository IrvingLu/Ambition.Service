using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Domain.Patient.Events;

namespace NMS.RTIS.Domain.Patient
{

    public class Patient : Entity, IAggregateRoot
    {
        /// <summary>
        /// 患者名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        public Patient(string name, string phone = null)
        {
            Name = name;
            Phone = phone;
            AddDomainEvent(new CreatePatientEvent(this));//举例
        }
    }
}
