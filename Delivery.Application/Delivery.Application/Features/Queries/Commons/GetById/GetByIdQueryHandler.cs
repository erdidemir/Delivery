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

namespace Delivery.Application.Features.Queries.Commons.GetById
{
    public abstract class GetByIdQueryHandler<T> : IRequestHandler<GetByIdQuery<T>, ResponseViewModelBase<T>> where T : class
    {
        private readonly IMapper _mapper;
        protected EntityBase _baseEntity { get; set; }

        public GetByIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual async Task<ResponseViewModelBase<T>> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
        {
            return ResponseViewModelBase<T>.Success(_mapper.Map<T>(_baseEntity), 200);
        }
    }
}
