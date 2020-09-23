using ClassTimeTable.Models.Domain;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCourses();
        Course GetCourse(int Id);
        bool CourseExist(int Id);

        bool Create(Course course);
        bool Update(Course course);
        bool Delete(Course course);
        bool Save();
    }
}
