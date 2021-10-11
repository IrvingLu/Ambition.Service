using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;

namespace NMS.RTIS.Domain.Patient
{
    public class PatientPlan:Entity
    {

        [Comment("计划名称")]
        public string PlanName { get; set; }
    }
}
