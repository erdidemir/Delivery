using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delivery.Application.Models.Commons
{
    public class ResponseModelBase<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseModelBase<T> Success(T Data, int statusCode = 0)
        {
            return new ResponseModelBase<T> { Data = Data, StatusCode = statusCode };
        }
        public static ResponseModelBase<T> Success(int statusCode = 0)
        {
            return new ResponseModelBase<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseModelBase<T> Fail(List<String> errors, int statusCode = 0)
        {
            return new ResponseModelBase<T> { Data = default(T), Errors = errors, StatusCode = statusCode };
        }

        public static ResponseModelBase<T> Fail(string error, int statusCode = 0)
        {
            return new ResponseModelBase<T> { Data = default(T), Errors = new List<string>() { error }, StatusCode = statusCode };
        }
    }
}
