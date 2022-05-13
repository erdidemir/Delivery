using Delivery.Application.Models.Commons;
using MediatR;

namespace Delivery.Application.Features.Commands.Commons.Adds
{
    public class AddCommandBase<T> : IRequest<ResponseViewModelBase<NoContent>> where T : class
    {
        public T Entity { get; set; }
    }
}
