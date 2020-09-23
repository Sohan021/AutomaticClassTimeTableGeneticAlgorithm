using ClassTimeTable.Models.Domain;
using ClassTimeTable.ViewModels;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IClassRepository
    {
        ICollection<Class> GetClasses();
        Class GetClass(int Id);
        bool ClassExist(int Id);

        List<ScheduleViewModel> Create(int size = 9);
        bool Update(Class cls);
        bool Delete(Class cls);
        bool Save();
    }
}
