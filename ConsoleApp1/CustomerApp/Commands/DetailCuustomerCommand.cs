using MediatR;
using Project.Core.Entities;
using Project.Web.Application.CustomerApp.Dto;
using System;

namespace Project.Web.Application.CustomerApp.Commands
{
    public class DetailCuustomerCommand : EntityDto, IRequest<CustomerDto>
    {

        public DetailCuustomerCommand(Guid id)
        {

            this.Id = id;
        }
    }
}
