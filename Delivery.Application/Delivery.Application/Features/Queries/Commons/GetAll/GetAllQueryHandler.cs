using AutoMapper;
using Delivery.Application.Models.Commons;
using Delivery.Domain.Entities.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Queries.Commons.GetAll
{
    public abstract class GetAllQueryHandler<T> : IRequestHandler<GetAllQuery<T>, ResponseModelBase<IReadOnlyList<T>>>
        where T : class
    {
        protected readonly IMapper _mapper;
        protected IReadOnlyList<EntityBase> _baseEntities { get; set; }

        public GetAllQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual async Task<ResponseModelBase<IReadOnlyList<T>>> Handle(GetAllQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseModelBase<IReadOnlyList<T>>.Success(_mapper.Map<IReadOnlyList<T>>(_baseEntities), 200);
        }
    }
}
