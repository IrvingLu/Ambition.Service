using MediatR;
using Sfan.Core.Entities;
using System;

namespace Sfan.Web.Application.Command.Customer
{
    public class DeleteCustomerCommand : EntityDto, IRequest
    {

        public DeleteCustomerCommand(Guid id) {

            this.Id = id;
        }
    }
}
