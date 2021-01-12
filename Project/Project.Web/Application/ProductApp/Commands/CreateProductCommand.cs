

using MediatR;
using Project.Core.BaseDto;
using System;

namespace Project.Web.Application.ProductApp.Commands
{
    public class CreateProductCommand : EntityDto, IRequest 
    {
        public string Name { get; set; }
    }
}
