using System.Diagnostics.CodeAnalysis;

namespace Pokedex.Core.Results
{
    public class ApiResult<T>
    {
        private enum ApiResponse
        {
            Success,
            Error,
            NotFound
        }

        private readonly ApiResponse _apiResponse;

        public T ApiValue;
        public Exception? Exception;

        [MemberNotNullWhen(false, nameof(Exception))]
        public bool IsValid
            => _apiResponse == ApiResponse.Success;

        [MemberNotNullWhen(true, nameof(Exception))]
        public bool IsNotFound
            => _apiResponse == ApiResponse.NotFound;

        public ApiResult()
        {
            ApiValue = default!;
            _apiResponse = ApiResponse.Error;
            Exception = null;
        }

        public ApiResult(T value)
        {
            ApiValue = value;
            _apiResponse = ApiResponse.Success;
            Exception = null;
        }

        public ApiResult(HttpRequestException httpRequestException)
        {
            ApiValue = default!;
            Exception = httpRequestException;
            _apiResponse = httpRequestException.StatusCode == System.Net.HttpStatusCode.NotFound ? ApiResponse.NotFound : ApiResponse.Error;
        }

        public ApiResult(Exception exception)
        {
            ApiValue = default!;
            Exception = exception;
            _apiResponse = ApiResponse.Error;
        }

        public static implicit operator ApiResult<T>(T? value)
        {
            if (value != null)
            {
                return new ApiResult<T>(value);
            }
            else
            {
                return new ApiResult<T>();
            }
        }

        public static implicit operator ApiResult<T>(Exception exception)
        {
            return new ApiResult<T>(exception);
        }
    }
}