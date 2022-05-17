using Delivery.Domain.Enums.Commons;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delivery.Application.Models.Commons
{
    public class ResponseViewModelBase<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; }

        public ResultTypeEnum ResultType { get; set; }

        public static ResponseViewModelBase<T> Success(T Data, ResultTypeEnum resultType)
        {
            return new ResponseViewModelBase<T> { Data = Data, ResultType = resultType };
        }
        public static ResponseViewModelBase<T> Success(ResultTypeEnum resultType)
        {
            return new ResponseViewModelBase<T> { Data = default(T), ResultType = resultType };
        }

        public static ResponseViewModelBase<T> Fail(List<String> errors, ResultTypeEnum resultType)
        {
            return new ResponseViewModelBase<T> { Data = default(T), Errors = errors, ResultType = resultType };
        }

        public static ResponseViewModelBase<T> Fail(string error, ResultTypeEnum resultType)
        {
            return new ResponseViewModelBase<T> { Data = default(T), Errors = new List<string>() { error }, ResultType = resultType };
        }
    }
}
