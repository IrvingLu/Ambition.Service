using MediatR;
using Project.Core.BaseDto;
using System;

namespace Project.Web.Application.ProductApp.Commands
{
    public class UpdateProductCommand : EntityDto, IRequest
    {
        public string Name { get;  set; }
    }
}
