using Project.Core.Entities;

namespace Project.Web.Application.CustomerApp.Dto
{
    //[AutoMap(typeof(Core.Domain.Customer))]
    public class CustomersDto:EntityDto
    {
        public string Name { get; set; }
    }
}
