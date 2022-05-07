using Delivery.Domain.Enums.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Responses
{
    public class ResponseBase
    {
        public ResultTypeEnum ResultType { get; }
        public string Message { get; }
        public string ResponseType { get; set; }

        public ResponseBase(string message, ResultTypeEnum resultType)
        {
            Message = message;
            ResultType = resultType;
            ResponseType = resultType.ToString();

        }
    }
}
