using MediatR;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Core.BaseDto;

namespace NMS.RTIS.Web.Application.Patient.Command
{
    public class PatientsCommand : PageEntity, IRequest<PagedResultDto>
    {
    }
}
