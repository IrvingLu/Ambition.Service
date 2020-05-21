using MediatR;
using Sfan.Core.Entities;
using Sfan.Web.Application.Commands.Customer.Dto;
using System;

namespace Sfan.Web.Application.Command.Customer.Dto
{
    public class DetailCuustomerCommand : EntityDto, IRequest<CustomerDto>
    {

        public DetailCuustomerCommand(Guid id)
        {

            this.Id = id;
        }
    }
}
