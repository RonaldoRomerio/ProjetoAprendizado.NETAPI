using curriculumManager.src.domain.models;

namespace curriculumManager.src.application.util
{
    public static class ValidTypeArchive
    {
        static readonly string[] imageTypes = new string[] {"jpeg", "png", "jpg" };

        public static string validImageType(String contentType)
        {
            String type = contentType.Split("/")[1];

            if (!imageTypes.Contains(type)) throw new Exception("contentType Not permitted");

            return type;
        }
    }
}
