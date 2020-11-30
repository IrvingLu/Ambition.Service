using System;
using System.Collections.Generic;

namespace Project.Infrastructure.Core.BaseDto
{
    public class PagedResultDto
    {
        public int TotalCount { get; set; }

        public object Data { get; set; }

        public PagedResultDto()
        {

        }
        public PagedResultDto(int totalCount, object data)
        { 
            TotalCount = totalCount;
            Data = data;
        }
    }
}
