using Sfan.Core.Entities;

namespace Sfan.Web.Application.Command.Customer.Dto
{
    //[AutoMap(typeof(Core.Domain.Customer))]
    public class CustomersDto:EntityDto
    {
        public string Name { get; set; }
    }

}
