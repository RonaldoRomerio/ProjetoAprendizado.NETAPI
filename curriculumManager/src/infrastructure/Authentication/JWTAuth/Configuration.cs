namespace curriculumManager.src.infrastructure.Authentication.JWTAuth
{
    public static class Configuration
    {
        public static string secretKey { get; set; } = Environment.GetEnvironmentVariable("TokenSecret");
    }
}
