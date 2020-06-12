using MediatR;
using Project.Core.Entities;
using System;

namespace Project.Web.Application.CustomerApp.Commands
{
    public class DeleteCustomerCommand : EntityDto, IRequest
    {

        public DeleteCustomerCommand(Guid id) {

            this.Id = id;
        }
    }
}
