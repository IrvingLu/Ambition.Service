using MediatR;
using Project.Infrastructure.Core.BaseDto;
using Project.Web.Application.ProductApp.Dto;
using System;

namespace Project.Web.Application.ProductApp.Commands
{
    public class DetailCuustomerCommand : EntityDto, IRequest<ProductDto>
    {

        public DetailCuustomerCommand(Guid id)
        {

            this.Id = id;
        }
    }
}
