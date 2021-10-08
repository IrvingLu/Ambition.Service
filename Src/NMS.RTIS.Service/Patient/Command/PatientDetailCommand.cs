using MediatR;
using NMS.RTIS.Core.BaseDto;
using NMS.RTIS.Web.Application.Patient.Dto;
using System;

namespace NMS.RTIS.Web.Application.Patient.Command
{
    public class PatientDetailCommand : EntityDto, IRequest<PatientDetailDto>
    {
        public PatientDetailCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
