using ClassTimeTable.Models.Domain;

namespace ClassTimeTable.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public string CourseCode { get; set; }

        public int MaxNumOfStudents { get; set; }

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public int BatchId { get; set; }

        public Batch Batch { get; set; }
    }
}
