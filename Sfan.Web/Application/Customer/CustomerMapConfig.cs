using AutoMapper;
using Sfan.Core.Domain;
using Sfan.Web.Application.Command.Customer;
using Sfan.Web.Application.Command.Customer.Dto;
using Sfan.Web.Application.Commands.Customer.Dto;

namespace Sfan.Web.Application
{
    public class CustomerMapConfig : Profile
    {
        public CustomerMapConfig()
        {
            #region MyRegion
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, CustomersDto>().ForMember(f => f.Name, option => option.MapFrom(c => c.Name + "拼接"));
            CreateMap<Customer, CustomerDto>();
            #endregion

        }
    }
}
