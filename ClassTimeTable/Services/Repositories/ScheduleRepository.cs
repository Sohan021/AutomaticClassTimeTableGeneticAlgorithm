using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using ClassTimeTable.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;
        double fitness = -1;
        bool isFitnessChanged = true;
        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<ClassFitnessViewModel> CalculateFinessAndNumberOfConflicts()
        {
            var classes = _context.Classes
                           .Include(b => b.Batch)
                           .Include(r => r.Room)
                           .Include(c => c.Course)
                           .ThenInclude(i => i.Instructor)
                           .Include(m => m.MeetingTime)
                           .Select(x => new ClassFitnessViewModel
                           {
                               Class = new Class
                               {
                                   Id = x.Id,
                                   BatchId = x.BatchId,
                                   CourseId = x.CourseId,
                                   Course = x.Course,
                                   Batch = x.Batch,
                                   MeetingTime = x.MeetingTime,
                                   Room = x.Room,
                                   MeetingTimeId = x.MeetingTimeId,
                                   RoomId = x.RoomId,
                                   ScheduleId = x.ScheduleId,
                               },
                               Fitness = new double()
                           })
                           ///.Where(s => s.ScheduleId == 0)
                           .ToList();

            var finalClasses = new List<ClassFitnessViewModel>();
            for (int i = 0; i < 9; i++)
            {
                double numberOfConflicts = 0.0;
                var classGroup = classes.Where(x => x.Class.ScheduleId == i).ToList();
                foreach (var @class in classGroup)
                {
                    if (@class.Class.Room.StudentCapacity < @class.Class.Course.MaxNumOfStudents)
                    {
                        numberOfConflicts++;
                    }
                    foreach (var @class2 in classGroup)
                    {
                        if (classGroup.IndexOf(@class) >= classGroup.IndexOf(@class2))
                        {
                            if (@class.Class.MeetingTimeId == class2.Class.MeetingTimeId && @class.Class.Id != class2.Class.Id)
                            {
                                if (@class.Class.RoomId == @class2.Class.RoomId)
                                {
                                    numberOfConflicts++;
                                }
                                if (@class.Class.Course.InstructorId == @class2.Class.Course.InstructorId)
                                {
                                    numberOfConflicts++;
                                }
                            }
                        }
                    }
                }

                double fitnessValue = 1.0 / (numberOfConflicts + 1.0);
                foreach (var item in classGroup)
                {
                    item.Fitness = fitnessValue;
                }
                finalClasses.AddRange(classGroup);
            }

            return finalClasses;
        }


        public List<ClassFitnessViewModel> CalculateFinessAndNumberOfConflictsByInput(List<Class> classes)
        {
            var classList = classes
                           //.Include(b => b.Batch)
                           //.Include(r => r.Room)
                           //.Include(c => c.Course)
                           //.ThenInclude(i => i.Instructor)
                           //.Include(m => m.MeetingTime)
                           .Select(x => new ClassFitnessViewModel
                           {
                               Class = new Class
                               {
                                   Id = x.Id,
                                   BatchId = x.BatchId,
                                   CourseId = x.CourseId,
                                   Course = x.Course,
                                   Batch = x.Batch,
                                   MeetingTime = x.MeetingTime,
                                   Room = x.Room,
                                   MeetingTimeId = x.MeetingTimeId,
                                   RoomId = x.RoomId,
                                   ScheduleId = x.ScheduleId,
                               },
                               Fitness = new double()
                           }).ToList();


            var finalClasses = new List<ClassFitnessViewModel>();
            for (int i = 0; i < 9; i++)
            {
                double numberOfConflicts = 0.0;
                var classGroup = classList.Where(x => x.Class.ScheduleId == i).ToList();

                foreach (var @class in classGroup)
                {
                    if (@class.Class.Room.StudentCapacity < @class.Class.Course.MaxNumOfStudents)
                    {
                        numberOfConflicts++;
                    }
                    foreach (var @class2 in classGroup)
                    {
                        var test1 = classGroup.IndexOf(@class);
                        var test2 = classGroup.IndexOf(@class2);

                        if (classGroup.IndexOf(@class) >= classGroup.IndexOf(@class2))
                        {
                            var test3 = @class.Class.Id;
                            var test4 = @class2.Class.Id;

                            if (@class.Class.MeetingTime.Id == @class2.Class.MeetingTime.Id && classGroup.IndexOf(@class) != classGroup.IndexOf(@class2))
                            {
                                if (@class.Class.Room.Id == @class2.Class.Room.Id)
                                {
                                    numberOfConflicts++;
                                }
                                if (@class.Class.Course.Instructor.Id == @class2.Class.Course.Instructor.Id)
                                {
                                    numberOfConflicts++;
                                }
                            }
                        }
                    }
                }
                double fitnessValue = 1.0 / (numberOfConflicts + 1.0);
                foreach (var item in classGroup)
                {
                    item.Fitness = fitnessValue;
                }
                finalClasses.AddRange(classGroup);
            }
            return finalClasses;
        }
        public bool Create(ScheduleViewModel schedule)
        {
            throw new System.NotImplementedException();
        }
        public bool Delete(ScheduleViewModel schedule)
        {
            throw new System.NotImplementedException();
        }
        public List<ClassFitnessViewModel> GetFitness()
        {
            if (isFitnessChanged == true)
            {
                var fitness = CalculateFinessAndNumberOfConflicts();
                if (isFitnessChanged == false)
                    return fitness;
            }
            return new List<ClassFitnessViewModel>();
        }
        public ScheduleViewModel GetSchedule(int Id)
        {
            throw new System.NotImplementedException();
        }
        public ICollection<ScheduleViewModel> GetSchedules()
        {
            throw new System.NotImplementedException();
        }
        public bool Save()
        {
            throw new System.NotImplementedException();
        }
        public bool ScheduleExist(int Id)
        {
            throw new System.NotImplementedException();
        }
        public bool Update(ScheduleViewModel schedule)
        {
            throw new System.NotImplementedException();
        }
    }
    //public class ClassFit
    //{
    //    public Class Class { get; set; }
    //    public double Fitness { get; set; }
    //}
}
