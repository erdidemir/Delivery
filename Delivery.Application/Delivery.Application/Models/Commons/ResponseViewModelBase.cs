using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delivery.Application.Models.Commons
{
    public class ResponseViewModelBase<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseViewModelBase<T> Success(T Data, int statusCode = 0)
        {
            return new ResponseViewModelBase<T> { Data = Data, StatusCode = statusCode };
        }
        public static ResponseViewModelBase<T> Success(int statusCode = 0)
        {
            return new ResponseViewModelBase<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseViewModelBase<T> Fail(List<String> errors, int statusCode = 0)
        {
            return new ResponseViewModelBase<T> { Data = default(T), Errors = errors, StatusCode = statusCode };
        }

        public static ResponseViewModelBase<T> Fail(string error, int statusCode = 0)
        {
            return new ResponseViewModelBase<T> { Data = default(T), Errors = new List<string>() { error }, StatusCode = statusCode };
        }
    }
}
