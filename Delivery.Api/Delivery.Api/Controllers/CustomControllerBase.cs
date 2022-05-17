using Delivery.Application.Features.Commands.Commons.Adds;
using Delivery.Application.Features.Commands.Commons.Deletes;
using Delivery.Application.Features.Queries.Commons.GetAll;
using Delivery.Application.Features.Queries.Commons.GetById;
using Delivery.Application.Features.Queries.Commons.GetBySearchKeyword;
using Delivery.Application.Models.Commons;
using Delivery.Domain.Enums.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Delivery.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomControllerBase<T, R> : ControllerBase
       where T : class
       where R : class
    {
        private readonly IMediator _mediator;

        public CustomControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllQuery<T>());
            return CreateActionResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdQuery<T>() { Id = id });
            return CreateActionResult(response);
        }

        [HttpGet("seachkeyword")]
        public async Task<IActionResult> GetByPage(string keyword)
        {
            var response = await _mediator.Send(new GetBySearchKeywordQuery<T>() { Keyword = keyword });
            return CreateActionResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommandBase<R> request)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new AddCommandBase<R>() { Entity = request.Entity });
                return CreateActionResult(response);
            }
            return CreateActionResult(ResponseViewModelBase<NoContent>.Fail("Inputs are not valid", ResultTypeEnum.Error));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCommandBase<T> request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(response);
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseViewModelBase<T> response)
        {
            //if (response.ResultType == ResultTypeEnum.Error)
            //    return new ObjectResult(null) { StatusCode = 404 };

            return new ObjectResult(response) {  StatusCode  = 200 };
        }
    }
}
