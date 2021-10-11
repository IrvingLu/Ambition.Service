using MediatR;
using NMS.RTIS.Core.BaseDto;
using NMS.RTIS.Service.Patient.Dto;
using System;

namespace NMS.RTIS.Service.Patient.Command
{
    public class PatientDetailCommand : EntityDto, IRequest<PatientDetailDto>
    {
        public PatientDetailCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
