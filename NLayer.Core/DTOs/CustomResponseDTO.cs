using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }


        public static CustomResponseDTO<T> Success(int statusCode, T data)
        {
            return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDTO<T> Fail(string errors, int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
