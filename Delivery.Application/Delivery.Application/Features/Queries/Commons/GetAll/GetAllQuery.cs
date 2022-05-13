using Delivery.Application.Models.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Queries.Commons.GetAll
{
    public class GetAllQuery<T> : IRequest<ResponseModelBase<IReadOnlyList<T>>> where T : class
    {
    }
}
