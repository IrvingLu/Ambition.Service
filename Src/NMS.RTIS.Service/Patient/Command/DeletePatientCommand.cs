using MediatR;
using NMS.RTIS.Core.BaseDto;
using System;

namespace NMS.RTIS.Web.Application.Patient.Command
{
    public class DeletePatientCommand:EntityDto,IRequest
    {
        public DeletePatientCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
