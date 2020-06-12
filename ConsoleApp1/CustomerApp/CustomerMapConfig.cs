using AutoMapper;
using Project.Core.Domain;
using Project.Web.Application.CustomerApp.Commands;
using Project.Web.Application.CustomerApp.Dto;

namespace Project.Web.Application.CustomerApp
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
