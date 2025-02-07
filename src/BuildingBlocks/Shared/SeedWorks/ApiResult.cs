using System.Text.Json.Serialization;

namespace Shared.SeedWorks
{
    public class ApiResult<T>
    {
        [JsonConstructor]
        public ApiResult(bool isSuccessed, string message = "")
        {
            Message = message;
            IsSucceeded = isSuccessed;
        }

        public ApiResult(bool isSucceeded, T data, string message = "")
        {
            IsSucceeded = isSucceeded;
            Message = message;
            Data = data;
        }

        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public T Data { get; }
    }
}
