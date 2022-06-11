namespace API.Common
{
    public class ApiResponseOk<T> : ApiResponse
    {
        public T Result { get; }
        public ApiResponseOk(T result) : base(200)
        {
            Result = result;
        }
    }
}
