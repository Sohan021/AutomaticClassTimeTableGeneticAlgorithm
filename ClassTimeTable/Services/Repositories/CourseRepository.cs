using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CourseExist(int Id)
        {
            return _context.Courses.Any(c => c.Id == Id);
        }

        public bool Create(Course course)
        {

            _context.Courses.Add(course);

            return Save();
        }

        public bool Delete(Course course)
        {
            _context.Courses.Remove(course);
            return Save();
        }

        public Course GetCourse(int Id)
        {
            Course course = new Course();
            course = _context.Courses.Include(i => i.Instructor).Include(b => b.Batch).Where(c => c.Id == Id).FirstOrDefault(c => c.Id == Id);
            return course;
        }

        public ICollection<Course> GetCourses()
        {
            return _context.Courses.Include(i => i.Instructor).Include(b => b.Batch).OrderBy(b => b.Batch.Name).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Course course)
        {
            _context.Update(course);
            return Save();
        }
    }
}
