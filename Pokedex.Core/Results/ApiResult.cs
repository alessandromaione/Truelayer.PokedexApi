using System.Diagnostics.CodeAnalysis;

namespace Pokedex.Core.Results
{
    public class ApiResult<T>
    {
        public enum ApiResponseType
        {
            Success,
            Error,
            NotFound
        }

        public ApiResponseType ApiResponse { get; set; }
        
        public T ApiValue;
        public Exception? Exception;

        [MemberNotNullWhen(false, nameof(Exception))]
        public bool IsValid
            => ApiResponse == ApiResponseType.Success;

        [MemberNotNullWhen(true, nameof(Exception))]
        public bool IsNotFound
            => ApiResponse == ApiResponseType.NotFound;

        public ApiResult()
        {
            ApiValue = default!;
            ApiResponse = ApiResponseType.Error;
            Exception = null;
        }

        public ApiResult(T value)
        {
            ApiValue = value;
            ApiResponse = ApiResponseType.Success;
            Exception = null;
        }

        public ApiResult(HttpRequestException httpRequestException)
        {
            ApiValue = default!;
            Exception = httpRequestException;
            ApiResponse = 
                httpRequestException.StatusCode == System.Net.HttpStatusCode.NotFound 
                ? ApiResponseType.NotFound 
                : ApiResponseType.Error;
        }

        public ApiResult(Exception exception)
        {
            ApiValue = default!;
            Exception = exception;
            ApiResponse = ApiResponseType.Error;
        }

        public static implicit operator ApiResult<T>(T? value)
        {
            return 
                value != null ? new ApiResult<T>(value) : new ApiResult<T>();
        }

        public static implicit operator ApiResult<T>(Exception exception) 
            => new(exception);

        public static implicit operator ApiResult<T>(HttpRequestException httpRequestException) 
            => new(httpRequestException);
    }
}