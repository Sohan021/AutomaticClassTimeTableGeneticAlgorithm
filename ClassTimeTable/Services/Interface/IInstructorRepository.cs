using ClassTimeTable.Models.Domain;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IInstructorRepository
    {
        ICollection<Instructor> GetInstructors();
        Instructor GetInstructor(int? Id);
        bool InstructorExist(int Id);

        bool Create(Instructor instructor);
        bool Update(Instructor instructor);
        bool Delete(Instructor instructor);
        bool Save();
    }
}
