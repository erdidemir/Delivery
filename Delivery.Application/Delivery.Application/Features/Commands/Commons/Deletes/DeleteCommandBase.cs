using Delivery.Application.Models.Commons;
using MediatR;

namespace Delivery.Application.Features.Commands.Commons.Deletes
{
    public class DeleteCommandBase<T> : IRequest<ResponseViewModelBase<NoContent>> where T : class
    {
        public T Entity { get; set; }
    }
}
