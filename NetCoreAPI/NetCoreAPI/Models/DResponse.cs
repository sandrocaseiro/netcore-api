using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NetCoreAPI.Models
{
    public class DResponse<T> where T : class
    {
        public T Data { get; set; }
        public IEnumerable<Error> Errors { get; set; } = Enumerable.Empty<Error>().ToList();
        public bool IsSuccess { get { return !Errors.Any() || !Errors.Any(e => e.Type == ErrorType.Error); } }

        public static DResponse<T> ToOk(T data, int code, string message) => 
            new DResponse<T> { Data = data, Errors = new List<Error> { Error.ToSuccess(code, message) } };

        public static DResponse<T> ToNotOk(int code, string message) => 
            new DResponse<T> { Data = null, Errors = new List<Error> { Error.ToError(code, message) } };

        public static DResponse<T> ToNotOk(IEnumerable<Error> errors) => new DResponse<T> { Data = null, Errors = errors };

        public class Error
        {
            public int Code { get; set; }
            public ErrorType Type { get; set; }
            public string Description { get; set; }

            public static Error ToError(int code, string description) => new Error { Code = code, Description = description, Type = ErrorType.Error };
            public static Error ToWarning(int code, string description) => new Error { Code = code, Description = description, Type = ErrorType.Warning };
            public static Error ToInformation(int code, string description) => new Error { Code = code, Description = description, Type = ErrorType.Information };
            public static Error ToSuccess(int code, string description) => new Error { Code = code, Description = description, Type = ErrorType.Success };
        }

        public enum ErrorType
        {
            [Description("E")]
            Error,
            [Description("W")]
            Warning,
            [Description("I")]
            Information,
            [Description("S")]
            Success
        }
    }
}
