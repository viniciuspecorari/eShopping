﻿using Amazon.Runtime.Internal;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    internal class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypesRepository _typesRepository;

        public GetAllTypesHandler(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _typesRepository.GetTypes();
            var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
            return typesResponse;
        }
    }
}
