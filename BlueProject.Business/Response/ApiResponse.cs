namespace BlueProject.Business.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string? ErrorMessage { get; set; }

        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
            ErrorMessage = null;
        }

        public ApiResponse(string errorMessage)
        {
            Success = false;
            Data = default;
            ErrorMessage = errorMessage;
        }
    }
}
