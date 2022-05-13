﻿using AutoMapper;
using Delivery.Application.Models.Commons;
using Delivery.Domain.Entities.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Queries.Commons.GetBySearchKeyword
{
    public abstract class GetBySearchQueryHandler<T> : IRequestHandler<GetBySearchKeywordQuery<T>, ResponseModelBase<IReadOnlyList<T>>> where T : class
    {
        private readonly IMapper _mapper;
        protected IReadOnlyList<EntityBase> _baseEntities { get; set; }

        public GetBySearchQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual async Task<ResponseModelBase<IReadOnlyList<T>>> Handle(GetBySearchKeywordQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseModelBase<IReadOnlyList<T>>.Success(_mapper.Map<IReadOnlyList<T>>(_baseEntities), 200);
        }
    }
}