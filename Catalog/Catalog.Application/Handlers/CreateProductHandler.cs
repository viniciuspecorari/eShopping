﻿using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);
            if (productEntity is null)
            {
                throw new ApplicationException("Não foi possível realizar o mapeamento do novo produto para o modelo existente");
            }

            var newProduct = await _productsRepository.CreateProduct(productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
