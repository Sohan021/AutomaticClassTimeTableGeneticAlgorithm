using ClassTimeTable.Models.Domain;
using ClassTimeTable.ViewModels;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IScheduleRepository
    {
        ICollection<ScheduleViewModel> GetSchedules();
        ScheduleViewModel GetSchedule(int Id);
        bool ScheduleExist(int Id);

        bool Create(ScheduleViewModel schedule);
        bool Update(ScheduleViewModel schedule);
        bool Delete(ScheduleViewModel schedule);
        bool Save();


        List<ClassFitnessViewModel> GetFitness();

        List<ClassFitnessViewModel> CalculateFinessAndNumberOfConflicts();

        List<ClassFitnessViewModel> CalculateFinessAndNumberOfConflictsByInput(List<Class> classes);
    }
}
