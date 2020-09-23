using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using ClassTimeTable.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class ClassRepository : IClassRepository
    {

        private readonly AppDbContext _context;
        private readonly IScheduleRepository _scheduleRepo;
        public ClassRepository(AppDbContext context, IScheduleRepository scheduleRepo)
        {
            _context = context;
            _scheduleRepo = scheduleRepo;
        }

        public bool ClassExist(int Id)
        {
            return _context.Classes.Any(c => c.Id == Id);
        }


        public List<ScheduleViewModel> Create(int size = 9)
        {
            List<ScheduleViewModel> schedules = new List<ScheduleViewModel>();

            for (int i = 0; i < size; i++)
            {
                Random random = new Random();

                var batches = _context.Batches.ToList();
                var batchess = _context.Batches.OrderBy(b => b.Name).ToList();
                var courses = _context.Courses.Include(c => c.Batch).Include(o => o.Instructor).ToList();

                int totalBatchesCount = _context.Batches.Count();
                int totalCoursesCount = _context.Courses.Count();
                int totalMeetingTimeCount = _context.MeetingTimes.Count();
                int totalRoomCount = _context.Rooms.Count();

                List<Class> classes = new List<Class>();
                var COUNT = 1;
                foreach (var courseItem in courses)
                {

                    int randomMeetingTime = random.Next(0, totalMeetingTimeCount);
                    var meetingTime = _context.MeetingTimes.Skip(randomMeetingTime).FirstOrDefault();

                    int randomRoom = random.Next(0, totalRoomCount);
                    var room = _context.Rooms.Skip(randomRoom).FirstOrDefault();

                    Class @class = new Class();
                    @class.Id = COUNT;
                    @class.Batch = courseItem.Batch;
                    @class.Course = courseItem;
                    @class.MeetingTime = meetingTime;
                    @class.Room = room;
                    @class.ScheduleId = i;
                    classes.Add(@class);
                    //_context.Add(@class);
                    COUNT = COUNT++;
                }

                //get class fit
                var fitList = _scheduleRepo.CalculateFinessAndNumberOfConflictsByInput(classes);

                schedules.Add(new ScheduleViewModel
                {
                    Id = i,
                    Fitness = fitList[0].Fitness,
                    ClassFits = fitList
                });

            }
            //  return Save();
            return schedules;
        }

        public bool Delete(Class cls)
        {
            _context.Remove(cls);
            return Save();
        }

        public Class GetClass(int Id)
        {
            Class cls = new Class();
            cls = _context.Classes
                    .Include(b => b.Batch)
                    .Include(c => c.Course)
                    .ThenInclude(i => i.Instructor)
                    .Include(m => m.MeetingTime)
                    .Include(r => r.Room)
                    .OrderBy(c => c.Id)
                    .Where(c => c.Id == Id)
                    .FirstOrDefault(c => c.Id == Id);

            return cls;
        }

        public ICollection<Class> GetClasses()
        {
            return _context.Classes.Include(b => b.Batch)
                    .Include(c => c.Course)
                    .ThenInclude(i => i.Instructor)
                    .Include(m => m.MeetingTime)
                    .Include(r => r.Room)
                    .OrderBy(c => c.ScheduleId)
                    .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Class cls)
        {
            _context.Update(cls);
            return Save();
        }
    }

    //public class Schedule
    //{
    //    public int Id { get; set; }
    //    public double Fitness { get; set; }
    //    public List<ClassFitnessViewModel> ClassFits { get; set; }

    //}
}
