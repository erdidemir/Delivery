using Delivery.Application.Models.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Queries.Commons.GetById
{
    public class GetByIdQuery<T> : IRequest<ResponseViewModelBase<T>> where T : class
    {
        public int Id { get; set; }
    }
}
