using Delivery.Application.Models.Commons;
using MediatR;

namespace Delivery.Application.Features.Commands.Commons.Updates
{
    public class UpdateCommandBase<T> : IRequest<ResponseViewModelBase<NoContent>> where T : class
    {
        public int Id { get; set; }
    }
}
