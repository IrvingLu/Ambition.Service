using MediatR;
using Project.Infrastructure.Core.BaseDto;
using System;

namespace Project.Web.Application.ProductApp.Commands
{
    public class DeleteProductCommand : EntityDto, IRequest
    {

        public DeleteProductCommand(Guid id) {

            this.Id = id;
        }
    }
}
