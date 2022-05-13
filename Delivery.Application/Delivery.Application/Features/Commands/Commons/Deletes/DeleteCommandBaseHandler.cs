using AutoMapper;
using Delivery.Application.Models.Commons;
using Delivery.Application.Services.Commons;
using Delivery.Domain.Entities.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Commons.Deletes
{
    public class DeleteCommandBaseHandler<T> : IRequestHandler<DeleteCommandBase<T>, ResponseViewModelBase<NoContent>> where T : EntityBase
    {
        protected readonly IMapper _mapper;
        protected readonly IServiceBase<T> _service;

        public DeleteCommandBaseHandler(IMapper mapper,
            IServiceBase<T> service)
        {
            _service = service;
            _mapper = mapper;
        }

        public virtual async Task<ResponseViewModelBase<NoContent>> Handle(DeleteCommandBase<T> request, CancellationToken cancellationToken)
        {
            await _service.RemoveAsync(request.Entity);
            return ResponseViewModelBase<NoContent>.Success(204);
        }
    }
}
