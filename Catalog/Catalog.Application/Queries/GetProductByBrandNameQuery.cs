﻿using Amazon.Runtime.Internal;
using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductByBrandNameQuery : IRequest<IList<ProductResponse>>
    {
        public string BrandName { get; set; }

        public GetProductByBrandNameQuery(string brandName)
        {
            BrandName = brandName;
        }
    }
}
