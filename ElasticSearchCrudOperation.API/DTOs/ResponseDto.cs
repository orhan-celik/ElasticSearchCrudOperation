using System.Net;

namespace ElasticSearchCrudOperation.API.DTOs
{
    public record ResponseDto<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        // Static Factory Method
        public static ResponseDto<T> Success(T data, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = httpStatusCode };
        }

        // Static Factory Method
        public static ResponseDto<T> Fail(List<string> errors, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Errors = errors, StatusCode = httpStatusCode };
        }

        // Static Factory Method
        public static ResponseDto<T> Fail(string error, HttpStatusCode httpStatusCode)
        {
            return new ResponseDto<T> { Errors = new List<string> { error }, StatusCode = httpStatusCode };
        }


    }
}
