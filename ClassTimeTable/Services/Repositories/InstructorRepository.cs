using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Instructor instructor)
        {
            _context.Add(instructor);
            return Save();
        }

        public bool Delete(Instructor instructor)
        {
            _context.Remove(instructor);
            return Save();
        }

        public Instructor GetInstructor(int? Id)
        {
            //Instructor instructor = new Instructor();
            //instructor = _context.Instructors.Where(i => i.Id == Id).FirstOrDefault();
            var instructor = _context.Instructors.Find(Id);
            return instructor;
        }

        public ICollection<Instructor> GetInstructors()
        {
            return _context.Instructors.OrderBy(i => i.Name).ToList();
        }

        public bool InstructorExist(int Id)
        {
            return _context.Instructors.Any(i => i.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Instructor instructor)
        {
            _context.Update(instructor);
            return Save();
        }
    }
}
