using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    internal class GetProductByBrandNameHandler : IRequestHandler<GetProductByBrandNameQuery, IList<ProductResponse>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductByBrandNameHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByBrandNameQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productsRepository.GetProductByBrand(request.BrandName);
            var productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
            return productResponseList;
        }
    }
}
