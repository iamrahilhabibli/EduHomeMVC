namespace EduHome.Core.Entities
{
    public class CourseDetailsLanguage
    {
        public Guid Id { get; set; }
        public Guid CourseDetailsId { get; set; }
        public CourseDetails CourseDetails { get; set; }

        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
