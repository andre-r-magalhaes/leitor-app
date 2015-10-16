namespace br.com.anddo.lector.api.Models
{
    public class ApiMessage
    {
        public bool IsError { get; set; }

        public string Message { get; set; }

        public ApiMessage(bool isError, string message)
        {
            IsError = isError;
            Message = message;
        }
    }
}