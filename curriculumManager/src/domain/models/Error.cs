namespace curriculumManager.src.domain.models
{
    public class Error
    {
        public string statusCode {  get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public Error(string statusCode, string message, string details)
        {
            this.statusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
