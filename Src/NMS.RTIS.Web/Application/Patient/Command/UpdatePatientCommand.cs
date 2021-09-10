using MediatR;
using NMS.RTIS.Core.BaseDto;

namespace NMS.RTIS.Web.Application.Patient.Command
{
    public class UpdatePatientCommand : EntityDto, IRequest
    {
        public string Name { get; set; }
    }
}
